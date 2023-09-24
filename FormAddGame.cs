using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GameSaveBackupTool
{
    public partial class FormAddGame : Form
    {
        /// <summary>
        /// Current selected <see cref="TreeNodeFolder"/>.
        /// Null if currently-selected node isn't a folder.
        /// </summary>
        public TreeNodeFolder SelectedFolderNode
        {
            get
            {
                TreeNodeFolder selectedNode = _rootFolderNode;
                if (treeViewBackup.SelectedNode is TreeNodeFolder)
                    selectedNode = (TreeNodeFolder)treeViewBackup.SelectedNode;
                return selectedNode;
            }
        }

        /// <summary>
        /// Current selected <see cref="TreeNodeFile"/>.
        /// Null if currently-selected node isn't a file.
        /// </summary>
        public TreeNodeFile? SelectedFileNode
        {
            get
            {
                TreeNodeFile? selectedNode = null;
                if (treeViewBackup.SelectedNode is TreeNodeFile)
                    selectedNode = (TreeNodeFile)treeViewBackup.SelectedNode;
                return selectedNode;
            }
        }

        public event EventHandler? GameAdded;

        private TreeNodeFolder _rootFolderNode;
        private List<string> _files;
        private bool _editMode;

        /* Constructor */
        public FormAddGame()
        {
            InitializeComponent();
            FormMain.FormAddGameInstance = this;
            Disposed += OnDispose;

            _files = new List<string>();
            _editMode = false;

            treeViewBackup.TreeViewNodeSorter = new BackupTreeViewSorter();

            // Root folder
            _rootFolderNode = new TreeNodeFolder("Backup");
            _rootFolderNode.Text = _rootFolderNode.FolderName;
            treeViewBackup.Nodes.Add(_rootFolderNode);

        } // end constructor

        /* Constructor - Edit existing game */
        public FormAddGame(string gameName, FolderData rootFolder) : this()
        {
            textBoxGameName.Text = gameName;
            textBoxGameName.Enabled = false;
            buttonDeleteProfile.Visible = true;
            this.Text = "Edit Game Profile";
            buttonAddGame.Text = "Update Game";
            _editMode = true;

            // Create nodes from folder data
            treeViewBackup.Nodes.Clear();
            _rootFolderNode = rootFolder.ConvertToTreeNode(ref treeViewBackup);
            treeViewBackup.Nodes.Add(_rootFolderNode);
            treeViewBackup.ExpandAll();

            // Remove existing folder data
            Save.ProfileRootFolders.Remove(gameName);


        } // end constructor

        public void OnDispose(object? sender, EventArgs e)
        {
            FormMain.FormAddGameInstance = null;

        } // end OnDispose

        /// <summary>
        /// Creates a new folder for organizing the backup archive.
        /// </summary>
        /// <param name="parent">Parent <see cref="Folder"/>. Null if no parent.</param>
        private void CreateFolder(TreeNodeFolder? parent)
        {
            if (parent == null) parent = _rootFolderNode;

            // Get name of new folder
            string name = textBoxCreateFolder.Text;
            textBoxCreateFolder.Text = string.Empty;
            // Empty name
            if (name == string.Empty)
            {
                MessageBox.Show("Folder name cannot be empty.");
                return;
            }
            // Check for error
            foreach (char c in Path.GetInvalidFileNameChars())
                if (name.Contains(c))
                {
                    // Invalid folder name
                    MessageBox.Show("Invalid folder name.");
                    return;
                }
            foreach (TreeNode node in parent.Nodes)
                if (node is TreeNodeFolder && ((TreeNodeFolder)node).FolderName == name)
                {
                    // Name already taken inside parent
                    MessageBox.Show("Folder name is duplicate.");
                    return;
                }

            // Create folder
            TreeNodeFolder newFolder = new TreeNodeFolder(name);
            newFolder.Text = name;
            parent.Nodes.Add(newFolder);
            parent.Expand();

            // Sort
            treeViewBackup.Sort();

        } // end CreateFolder

        /* Add files */
        private void buttonAddFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                DialogResult result = dialog.ShowDialog();

                // Get list of files
                List<string> filePaths = new List<string>();
                if (result == DialogResult.OK)
                {
                    string[] paths = dialog.FileNames;
                    foreach (string path in paths)
                        if (!string.IsNullOrEmpty(path) && File.Exists(path))
                            filePaths.Add(path);
                }

                // Add files to folder
                foreach (string path in filePaths)
                {
                    // Skip file if already in folder
                    bool skip = false;
                    foreach (TreeNode node in SelectedFolderNode.Nodes)
                        if (node is TreeNodeFile && ((TreeNodeFile)node).FilePath == path)
                            skip = true;
                    if (skip) continue;

                    // Add file
                    TreeNodeFile fileNode = new TreeNodeFile(path);
                    SelectedFolderNode.Nodes.Add(fileNode);
                }
                SelectedFolderNode.Expand();
            }

            // Sort
            treeViewBackup.Sort();

        } // end buttonAddFiles_Click

        /* Add save folder */
        private void buttonAddFolder_Click(object sender, EventArgs e)
        {
            // Create file choice dialog
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                // Fake folder selection
                dialog.ValidateNames = false;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.FileName = "Select folder";

                DialogResult result = dialog.ShowDialog();

                // Get list of files
                List<string> filePaths = new List<string>();
                string? directory = string.Empty;
                if (result == DialogResult.OK)
                {
                    directory = Path.GetDirectoryName(dialog.FileName);
                    if (!string.IsNullOrWhiteSpace(directory) && Directory.Exists(directory))
                    {
                        string[] files = Directory.GetFiles(directory);
                        foreach (string file in files)
                            if (File.Exists(file))
                                filePaths.Add(file);
                    }
                    // Invalid folder
                    else return;
                }

                // Add folder node
                TreeNodeFolder folder = new TreeNodeFolder(Path.GetFileName(directory));
                folder.Text = folder.FolderName;
                SelectedFolderNode.Nodes.Add(folder);
                SelectedFolderNode.Expand();

                // Add files
                foreach (string path in filePaths)
                {
                    TreeNodeFile file = new TreeNodeFile(path);
                    folder.Nodes.Add(file);
                }
            }

            // Sort
            treeViewBackup.Sort();

        } // end buttonAddFolder_Click

        /* Add / Edit game profile */
        private void buttonAddGame_Click(object sender, EventArgs e)
        {
            string? error = null;

            // Game name invalid
            if (string.IsNullOrWhiteSpace(textBoxGameName.Text))
                error = "Game folder name cannot be empty";
            else
                foreach (char ch in Path.GetInvalidFileNameChars())
                    if (textBoxGameName.Text.Contains(ch))
                        error = "Invalid game folder name";

            // Game name taken
            if (FormMain.Profiles != null && !_editMode)
                foreach (GameProfile save in FormMain.Profiles)
                    if (save.GameName == textBoxGameName.Text)
                        error = "Game folder name already taken";

            // Show error and stop creating game
            if (error != null)
            {
                MessageBox.Show($"Error: {error}");
                return;
            }

            // Any files invalid - does NOT prevent updating the profile
            foreach (string file in _files)
                if (!File.Exists(file))
                {
                    MessageBox.Show($"One or more files do not exist. Continuing anyways.");
                    break;
                }

            // If in edit mode, remove game before adding it
            if (_editMode)
                Save.ProfileRootFolders.Remove(textBoxGameName.Text);

            // Add game
            Save.ProfileRootFolders.Add(textBoxGameName.Text, FolderData.ConvertFromFolderNode(_rootFolderNode));
            FormMain.outputText = $"({DateTime.Now}) {((_editMode) ? "Updated" : "Added")} game profile \"{textBoxGameName.Text}\".";
            GameAdded?.Invoke(this, EventArgs.Empty);
            Close();

        } // end buttonAddGame_Click

        /* Delete game profile */
        private void buttonDeleteProfile_Click(object sender, EventArgs e)
        {
            if (!_editMode)
                return;

            string gameName = textBoxGameName.Text;
            if(Save.ProfileRootFolders.Remove(gameName))
            {
                FormMain.outputText = $"({DateTime.Now}) Deleted game profile \"{gameName}\".";
                GameAdded?.Invoke(this, EventArgs.Empty);
                Save.CreateSave();
                Close();
            }

        } // end buttonDeleteProfile_Click

        /* Create folder button */
        private void buttonCreateFolder_Click(object sender, EventArgs e)
        {
            // Create folder
            CreateFolder(SelectedFolderNode);

        } // end buttonCreateFolder_Click

        /* Remove selected */
        private void buttonRemoveSelected_Click(object sender, EventArgs e)
        {
            TreeNode? nodeToDelete = null;

            // File
            if (SelectedFileNode != null)
                nodeToDelete = SelectedFileNode;
            // Folder
            else if (SelectedFolderNode != _rootFolderNode)
                nodeToDelete = SelectedFolderNode;

            // Undeletable
            if (nodeToDelete == null) return;

            // Delete node
            nodeToDelete.Remove();

        } // end buttonRemoveSelected_Click

    } // end class FormAddGame

} // end namespace