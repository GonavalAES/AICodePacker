namespace AICodePacker;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support.
    ///  Do not modify the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        txtFolder = new TextBox();
        label1 = new Label();
        btnBrowse = new Button();
        label2 = new Label();
        chkCS = new CheckBox();
        chkCSV = new CheckBox();
        chkXAML = new CheckBox();
        chkCSPROJ = new CheckBox();
        chkJSON = new CheckBox();
        lblCustomExt = new Label();
        txtCustomExt = new TextBox();
        btnRefresh = new Button();
        lstAvailableFiles = new ListView();
        lstSelectedFiles = new ListView();
        label3 = new Label();
        btnAdd = new Button();
        btnSelectAll = new Button();
        btnClear = new Button();
        btnRemove = new Button();
        label4 = new Label();
        label5 = new Label();
        lblTokens = new Label();
        lblFiles = new Label();
        btnGenerate = new Button();
        statusStrip1 = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        toolTip1 = new ToolTip(components);
        statusStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // txtFolder
        // 
        txtFolder.Location = new Point(12, 37);
        txtFolder.Name = "txtFolder";
        txtFolder.Size = new Size(357, 23);
        txtFolder.TabIndex = 0;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(90, 15);
        label1.TabIndex = 1;
        label1.Text = "Solution Folder:";
        // 
        // btnBrowse
        // 
        btnBrowse.Location = new Point(375, 36);
        btnBrowse.Name = "btnBrowse";
        btnBrowse.Size = new Size(75, 23);
        btnBrowse.TabIndex = 2;
        btnBrowse.Text = "Browse...";
        btnBrowse.UseVisualStyleBackColor = true;
        btnBrowse.Click += btnBrowse_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 86);
        label2.Name = "label2";
        label2.Size = new Size(100, 15);
        label2.TabIndex = 3;
        label2.Text = "Select Extensions:";
        // 
        // chkCS
        // 
        chkCS.AutoSize = true;
        chkCS.Checked = true;
        chkCS.CheckState = CheckState.Checked;
        chkCS.Location = new Point(12, 117);
        chkCS.Name = "chkCS";
        chkCS.Size = new Size(40, 19);
        chkCS.TabIndex = 4;
        chkCS.Text = ".cs";
        chkCS.UseVisualStyleBackColor = true;
        // 
        // chkCSV
        // 
        chkCSV.AutoSize = true;
        chkCSV.Checked = true;
        chkCSV.CheckState = CheckState.Checked;
        chkCSV.Location = new Point(66, 117);
        chkCSV.Name = "chkCSV";
        chkCSV.Size = new Size(46, 19);
        chkCSV.TabIndex = 5;
        chkCSV.Text = ".csv";
        chkCSV.UseVisualStyleBackColor = true;
        // 
        // chkXAML
        // 
        chkXAML.AutoSize = true;
        chkXAML.Checked = true;
        chkXAML.CheckState = CheckState.Checked;
        chkXAML.Location = new Point(131, 117);
        chkXAML.Name = "chkXAML";
        chkXAML.Size = new Size(55, 19);
        chkXAML.TabIndex = 6;
        chkXAML.Text = ".xaml";
        chkXAML.UseVisualStyleBackColor = true;
        // 
        // chkCSPROJ
        // 
        chkCSPROJ.AutoSize = true;
        chkCSPROJ.Checked = true;
        chkCSPROJ.CheckState = CheckState.Checked;
        chkCSPROJ.Location = new Point(207, 117);
        chkCSPROJ.Name = "chkCSPROJ";
        chkCSPROJ.Size = new Size(61, 19);
        chkCSPROJ.TabIndex = 7;
        chkCSPROJ.Text = ".csproj";
        chkCSPROJ.UseVisualStyleBackColor = true;
        // 
        // chkJSON
        // 
        chkJSON.AutoSize = true;
        chkJSON.Location = new Point(291, 117);
        chkJSON.Name = "chkJSON";
        chkJSON.Size = new Size(51, 19);
        chkJSON.TabIndex = 8;
        chkJSON.Text = ".json";
        chkJSON.UseVisualStyleBackColor = true;
        // 
        // lblCustomExt
        // 
        lblCustomExt.AutoSize = true;
        lblCustomExt.Location = new Point(357, 121);
        lblCustomExt.Name = "lblCustomExt";
        lblCustomExt.Size = new Size(71, 15);
        lblCustomExt.TabIndex = 9;
        lblCustomExt.Text = "Custom ext:";
        // 
        // txtCustomExt
        // 
        txtCustomExt.Location = new Point(440, 115);
        txtCustomExt.Multiline = true;
        txtCustomExt.Name = "txtCustomExt";
        txtCustomExt.Size = new Size(136, 23);
        txtCustomExt.TabIndex = 10;
        toolTip1.SetToolTip(txtCustomExt, "Extra extensions to include, comma or space separated, e.g. .md, .txt, yaml (leading dot optional).");
        // 
        // btnRefresh
        // 
        btnRefresh.Location = new Point(582, 113);
        btnRefresh.Name = "btnRefresh";
        btnRefresh.Size = new Size(75, 23);
        btnRefresh.TabIndex = 11;
        btnRefresh.Text = "Refresh";
        toolTip1.SetToolTip(btnRefresh, "Re-scan the folder above using the current extension filters.");
        btnRefresh.UseVisualStyleBackColor = true;
        btnRefresh.Click += btnRefresh_Click;
        // 
        // lstAvailableFiles
        // 
        lstAvailableFiles.FullRowSelect = true;
        lstAvailableFiles.GridLines = true;
        lstAvailableFiles.Location = new Point(12, 168);
        lstAvailableFiles.Name = "lstAvailableFiles";
        lstAvailableFiles.Size = new Size(237, 387);
        lstAvailableFiles.TabIndex = 12;
        lstAvailableFiles.UseCompatibleStateImageBehavior = false;
        lstAvailableFiles.View = View.Details;
        // 
        // lstSelectedFiles
        // 
        lstSelectedFiles.Activation = ItemActivation.OneClick;
        lstSelectedFiles.FullRowSelect = true;
        lstSelectedFiles.GridLines = true;
        lstSelectedFiles.HotTracking = true;
        lstSelectedFiles.HoverSelection = true;
        lstSelectedFiles.Location = new Point(375, 168);
        lstSelectedFiles.Name = "lstSelectedFiles";
        lstSelectedFiles.Size = new Size(237, 387);
        lstSelectedFiles.TabIndex = 13;
        lstSelectedFiles.UseCompatibleStateImageBehavior = false;
        lstSelectedFiles.View = View.Details;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 150);
        label3.Name = "label3";
        label3.Size = new Size(33, 15);
        label3.TabIndex = 14;
        label3.Text = "Files:";
        // 
        // btnAdd
        // 
        btnAdd.Location = new Point(276, 260);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(75, 23);
        btnAdd.TabIndex = 15;
        btnAdd.Text = ">>";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnSelectAll
        // 
        btnSelectAll.Location = new Point(276, 311);
        btnSelectAll.Name = "btnSelectAll";
        btnSelectAll.Size = new Size(75, 23);
        btnSelectAll.TabIndex = 16;
        btnSelectAll.Text = "Select All";
        btnSelectAll.UseVisualStyleBackColor = true;
        btnSelectAll.Click += btnSelectAll_Click;
        // 
        // btnClear
        // 
        btnClear.Location = new Point(276, 352);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(75, 23);
        btnClear.TabIndex = 17;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        // 
        // btnRemove
        // 
        btnRemove.Location = new Point(276, 398);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new Size(75, 23);
        btnRemove.TabIndex = 18;
        btnRemove.Text = "<<";
        btnRemove.UseVisualStyleBackColor = true;
        btnRemove.Click += btnRemove_Click;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(637, 402);
        label4.Name = "label4";
        label4.Size = new Size(61, 15);
        label4.TabIndex = 19;
        label4.Text = "Total Files:";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(637, 434);
        label5.Name = "label5";
        label5.Size = new Size(46, 15);
        label5.TabIndex = 20;
        label5.Text = "Tokens:";
        // 
        // lblTokens
        // 
        lblTokens.AutoSize = true;
        lblTokens.Location = new Point(704, 434);
        lblTokens.Name = "lblTokens";
        lblTokens.Size = new Size(12, 15);
        lblTokens.TabIndex = 21;
        lblTokens.Text = "-";
        // 
        // lblFiles
        // 
        lblFiles.AutoSize = true;
        lblFiles.Location = new Point(704, 402);
        lblFiles.Name = "lblFiles";
        lblFiles.Size = new Size(12, 15);
        lblFiles.TabIndex = 22;
        lblFiles.Text = "-";
        // 
        // btnGenerate
        // 
        btnGenerate.Location = new Point(658, 507);
        btnGenerate.Name = "btnGenerate";
        btnGenerate.Size = new Size(75, 23);
        btnGenerate.TabIndex = 23;
        btnGenerate.Text = "GENERATE!";
        btnGenerate.UseVisualStyleBackColor = true;
        btnGenerate.Click += btnGenerate_Click;
        // 
        // statusStrip1
        // 
        statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
        statusStrip1.Location = new Point(0, 558);
        statusStrip1.Name = "statusStrip1";
        statusStrip1.Size = new Size(770, 22);
        statusStrip1.TabIndex = 24;
        statusStrip1.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(42, 17);
        lblStatus.Text = "Ready.";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(770, 580);
        Controls.Add(statusStrip1);
        Controls.Add(btnGenerate);
        Controls.Add(lblTokens);
        Controls.Add(lblFiles);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(btnRemove);
        Controls.Add(btnClear);
        Controls.Add(btnSelectAll);
        Controls.Add(btnAdd);
        Controls.Add(label3);
        Controls.Add(lstSelectedFiles);
        Controls.Add(lstAvailableFiles);
        Controls.Add(btnRefresh);
        Controls.Add(txtCustomExt);
        Controls.Add(lblCustomExt);
        Controls.Add(chkJSON);
        Controls.Add(chkCSPROJ);
        Controls.Add(chkXAML);
        Controls.Add(chkCSV);
        Controls.Add(chkCS);
        Controls.Add(label2);
        Controls.Add(btnBrowse);
        Controls.Add(label1);
        Controls.Add(txtFolder);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        SizeGripStyle = SizeGripStyle.Hide;
        Text = "Code Packer for AI";
        Load += Form1_Load;
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtFolder;
    private Label label1;
    private Button btnBrowse;
    private Label label2;
    private CheckBox chkCS;
    private CheckBox chkCSV;
    private CheckBox chkXAML;
    private CheckBox chkCSPROJ;
    private CheckBox chkJSON;
    private Label lblCustomExt;
    private TextBox txtCustomExt;
    private Button btnRefresh;
    private ListView lstAvailableFiles;
    private ListView lstSelectedFiles;

    private Label label3;
    private Button btnAdd;
    private Button btnSelectAll;
    private Button btnClear;
    private Button btnRemove;
    private Label label4;
    private Label label5;
    private Label lblTokens;
    private Label lblFiles;
    private Button btnGenerate;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatus;
    private ToolTip toolTip1;
}
