using AICodePacker.Model;

using System.Text;

namespace AICodePacker;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        ConfigureListView(lstAvailableFiles, "Available Files");
        ConfigureListView(lstSelectedFiles, "Selected Files");
        SetStatus("Ready. Browse to a solution folder to begin.");
    }

    private void ConfigureListView(ListView lv, string title)
    {
        lv.Clear();
        lv.View = View.Details;
        lv.FullRowSelect = true;
        lv.MultiSelect = true;
        lv.GridLines = true;
        lv.Columns.Add(title, 500);
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
        using FolderBrowserDialog dlg = new();
        if (dlg.ShowDialog() != DialogResult.OK) return;
        txtFolder.Text = dlg.SelectedPath;
        ScanFiles();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        // Re-applies the current extension filters (checkboxes + custom field)
        // to the folder already shown in txtFolder, without reopening the dialog.
        ScanFiles();
    }

    private void ScanFiles()
    {
        lstAvailableFiles.Items.Clear();

        string folder = txtFolder.Text;
        if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder))
        {
            SetStatus($"Folder not found: {folder}");
            return;
        }

        var extensions = GetSelectedExtensions();
        var alreadySelected = GetFullPaths(lstSelectedFiles);
        string folderLabel = new DirectoryInfo(folder).Name;

        List<string> files;
        try
        {
            // Materializing with ToList() forces enumeration now, inside the try block,
            // so a locked/inaccessible subfolder reports to the ToolStrip instead of crashing.
            files = Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories).ToList();
        }
        catch (Exception ex)
        {
            SetStatus($"Could not read folder: {ex.Message}");
            return;
        }

        int found = 0;
        foreach (string file in files)
        {
            if (ShouldIgnore(file)) continue;
            string ext = Path.GetExtension(file).ToLowerInvariant();
            if (!extensions.Contains(ext)) continue;
            if (alreadySelected.Contains(file)) continue; // already picked from this or another folder

            string relative = Path.Combine(folderLabel, Path.GetRelativePath(folder, file));
            var sourceFile = new SourceFile { FullPath = file, RelativePath = relative };
            lstAvailableFiles.Items.Add(new ListViewItem(relative) { Tag = sourceFile });
            found++;
        }

        UpdateStats();
        SetStatus($"Folder: {folder}   ({found} file(s) available)");
    }

    private HashSet<string> GetSelectedExtensions()
    {
        HashSet<string> ext = [];
        if (chkCS.Checked) ext.Add(".cs");
        if (chkCSV.Checked) ext.Add(".csv");
        if (chkXAML.Checked) ext.Add(".xaml");
        if (chkCSPROJ.Checked) ext.Add(".csproj");
        if (chkJSON.Checked) ext.Add(".json");

        foreach (string token in txtCustomExt.Text.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries))
        {
            string extension = token.Trim().ToLowerInvariant();
            if (!extension.StartsWith('.')) extension = "." + extension;
            if (extension.Length > 1) ext.Add(extension);
        }

        return ext;
    }

    private bool ShouldIgnore(string file)
    {
        string lower = file.ToLowerInvariant();
        return lower.Contains(@"\bin\")
               || lower.Contains(@"\obj\")
               || lower.Contains(@"\.vs\")
               || lower.Contains(@"\.git\")
               || lower.Contains(@"\.md\")
               || lower.Contains(@"\.txt\");
    }

    // Full paths of every item currently sitting in a list, read from each item's SourceFile tag.
    private static HashSet<string> GetFullPaths(ListView lv)
    {
        HashSet<string> paths = new(StringComparer.OrdinalIgnoreCase);
        foreach (ListViewItem item in lv.Items)
        {
            if (item.Tag is SourceFile { FullPath: not null } sf) paths.Add(sf.FullPath);
        }
        return paths;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var items = lstAvailableFiles.SelectedItems.Cast<ListViewItem>().ToList();
        foreach (ListViewItem item in items)
        {
            lstAvailableFiles.Items.Remove(item);
            lstSelectedFiles.Items.Add(item);
        }
        UpdateStats();
    }

    private void btnSelectAll_Click(object sender, EventArgs e)
    {
        var items = lstAvailableFiles.Items.Cast<ListViewItem>().ToList();
        foreach (ListViewItem item in items)
        {
            lstAvailableFiles.Items.Remove(item);
            lstSelectedFiles.Items.Add(item);
        }
        UpdateStats();
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        var items = lstSelectedFiles.SelectedItems.Cast<ListViewItem>().ToList();
        MoveBackToAvailableIfCurrentFolder(items);
        UpdateStats();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        var items = lstSelectedFiles.Items.Cast<ListViewItem>().ToList();
        MoveBackToAvailableIfCurrentFolder(items);
        UpdateStats();
    }

    // Removes items from Selected. An item only reappears in Available if it belongs to the folder currently shownin txtFolder.
    // Available always reflects that one folder, so an item picked from a different folder is simply dropped.
    // Re-browsing that folder brings it back.
    private void MoveBackToAvailableIfCurrentFolder(List<ListViewItem> items)
    {
        string currentFolder = txtFolder.Text;
        foreach (ListViewItem item in items)
        {
            lstSelectedFiles.Items.Remove(item);
            if (item.Tag is SourceFile sf && IsUnderFolder(sf.FullPath, currentFolder)) lstAvailableFiles.Items.Add(item);
        }
    }

    private static bool IsUnderFolder(string? fullPath, string folder)
    {
        if (string.IsNullOrEmpty(fullPath) || string.IsNullOrEmpty(folder) || !Directory.Exists(folder)) return false;
        string normalizedFolder = Path.GetFullPath(folder).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
        string normalizedFile = Path.GetFullPath(fullPath);
        return normalizedFile.StartsWith(normalizedFolder, StringComparison.OrdinalIgnoreCase);
    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
        if (lstSelectedFiles.Items.Count == 0)
        {
            SetStatus("No files selected — add files before generating."); return;
        }
        if (string.IsNullOrWhiteSpace(txtFolder.Text) || !Directory.Exists(txtFolder.Text))
        {
            SetStatus("Browse to a folder first — the compiled file is saved there."); return;
        }

        StringBuilder sb = new();
        foreach (ListViewItem item in lstSelectedFiles.Items)
        {
            if (item.Tag is not SourceFile { FullPath: not null } sf) continue;
            string label = sf.RelativePath ?? Path.GetFileName(sf.FullPath);
            sb.AppendLine($"== FILE: {label} ==");
            sb.AppendLine(File.ReadAllText(sf.FullPath));
            sb.AppendLine($"== END OF {label} ==");
            sb.AppendLine();
            sb.AppendLine();
        }

        string output = Path.Combine(txtFolder.Text, "Code_Compilation.txt");
        File.WriteAllText(output, sb.ToString(), Encoding.UTF8);

        lstSelectedFiles.Items.Clear();
        UpdateStats();
        SetStatus($"Compiled file created: {output}");
    }

    private void UpdateStats()
    {
        lblFiles.Text = lstSelectedFiles.Items.Count.ToString();
        long chars = 0;
        foreach (ListViewItem item in lstSelectedFiles.Items)
        {
            if (item.Tag is SourceFile { FullPath: not null } sf && File.Exists(sf.FullPath))
                chars += File.ReadAllText(sf.FullPath).Length;
        }
        lblTokens.Text = Math.Round(chars / 3.8).ToString();
    }

    private void SetStatus(string message) => lblStatus.Text = message;
}
