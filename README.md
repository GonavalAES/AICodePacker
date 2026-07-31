# AICodePacker
A small WinForms utility that packs selected files from one or more Visual Studio solution folders into a single, clearly-delimited .txt file, ready to paste into an AI chat as project context.

## Features
- Browse & filter: point it at a solution folder and it lists every file matching the selected extensions, automatically skipping \bin, \obj, .vs, .git, and .md.
- Multi-folder selection: browse to a folder, pick files, then browse to another folder and pick more. The selection list persists across folders instead of resetting, so a single compiled file can pull from several projects at once.
- Extension checkboxes + custom extensions: toggle .cs, .csv, .xaml, .csproj, .json out of the box, or type any others into the custom field (comma or space separated, leading dot optional — e.g. md, txt, .yaml).
- Refresh without re-browsing: re-apply filter changes to the folder already loaded, without reopening the folder dialog.
- Live stats: running file count and a rough token estimate for the current selection.
- One-click compile: generates "Code_Compilation.txt" in the last browsed folder, clears the selection, and reports the output path on the status bar (no dialog to dismiss).

## Requirements
Windows
Visual Studio 2026, or the .NET 10 SDK with the Windows Desktop workload
.NET 10 (net10.0-windows)
Build & Run

## Open AICodePacker.sln in Visual Studio 2026 and press F5, or from the command line:

bash
dotnet build
dotnet run --project AICodePacker

## Usage
1. Browse to a solution folder. Matching files appear in 'Available Files'.
2. Adjust extension checkboxes and/or the custom-extensions field, then Browse/Refresh to re-scan.
3. Select files and click '>>' (or 'Select All') to move them into 'Selected Files'.
4. Repeat steps 1–3 for any additional folders, previously selected files stay put.
5. Click 'GENERATE!' to write "Code_Compilation.txt" into the last browsed folder. The selection list clears automatically, ready for the next batch.

Each entry in the lists is shown as <folder name>\<relative path> so files from different folders never get confused with one another, even if two projects share a file name.

## Output format
Each file is wrapped like this, so an AI reading the compiled output can tell where one file ends and the next begins:

== FILE: MyProject\Form1.cs ==
...file contents...
== END OF MyProject\Form1.cs ==

## Project structure
AICodePacker/
├── AICodePacker.csproj
├── Program.cs
├── Form1.cs              # UI logic
├── Form1.Designer.cs     # Generated layout
└── Model/
    └── SourceFile.cs      # Full path + relative path per list entry

## Notes
The 'Available Files' list always reflects a live scan of the currently browsed folder.
Removing an item from 'Selected Files' only returns it to 'Available Files' if it belongs to the folder currently loaded, otherwise it's simply dropped, and re-browsing that original folder brings it back into view.
The token count is a rough estimate (characters ÷ 3.8), not an exact tokenizer count.
