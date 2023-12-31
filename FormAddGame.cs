﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameSaveBackupTool
{
    public partial class FormAddGame : Form
    {
        public event EventHandler? GameAdded;

        private List<string> _files;
        private string? _saveDirectory;
        private bool _editMode;

        public FormAddGame()
        {
            InitializeComponent();
            FormMain.FormAddGameInstance = this;
            Disposed += OnDispose;

            _files = new List<string>();
            _editMode = false;

        } // end constructor

        public FormAddGame(GameProfile game) : this()
        {
            _files = game.FileNames;
            _saveDirectory = game.SaveDirectory;

            textBoxGameName.Text = game.GameName;
            textBoxGameName.Enabled = false;
            buttonDeleteProfile.Visible = true;
            this.Text = "Edit Game Profile";

            buttonAddGame.Text = "Update Game";

            _editMode = true;

            UpdateFilesList();

        } // end constructor

        public void OnDispose(object? sender, EventArgs e)
        {
            FormMain.FormAddGameInstance = null;

        } // end OnDispose

        /*
        private void buttonBrowseSaveDirectory_Click(object sender, EventArgs e)
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
                if (result == DialogResult.OK)
                {
                    string? directory = Path.GetDirectoryName(dialog.FileName);
                    if (!string.IsNullOrWhiteSpace(directory) && Directory.Exists(directory))
                    {
                        _files.Clear();
                        _saveDirectory = directory;
                        //textBoxSaveDirectory.Text = _saveDirectory;

                        string[] files = Directory.GetFiles(_saveDirectory);
                        foreach (string file in files)
                            if (File.Exists(file))
                            {
                                _files.Add(file);
                                listBoxFiles.Items.Add(file);
                            }
                    }
                }
            }

        } // end buttonBrowseSaveDirectory_Click
        */

        /* Add files */
        private void buttonAddFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.InitialDirectory = _saveDirectory;
                DialogResult result = dialog.ShowDialog();

                // Get list of files
                if (result == DialogResult.OK)
                {
                    string[] paths = dialog.FileNames;
                    foreach (string path in paths)
                        if (!string.IsNullOrEmpty(path) && File.Exists(path))
                        {
                            _files.Add(path);
                            // Most recent file added is default save directory
                            _saveDirectory = Path.GetDirectoryName(path);
                        }
                }

                UpdateFilesList();
            }
        } // end buttonAddFiles_Click

        /* Remove file from profile */
        private void buttonRemoveFile_Click(object sender, EventArgs e)
        {
            if (listBoxFiles.SelectedIndex != -1)
            {
                string? filePath = listBoxFiles.SelectedItem.ToString();
                if (filePath != null)
                {
                    _files.Remove(filePath);
                    UpdateFilesList();
                }
            }

        } // end buttonRemoveFile_Click

        /* Update files list */
        private void UpdateFilesList()
        {
            listBoxFiles.Items.Clear();
            foreach (string file in _files)
                listBoxFiles.Items.Add(file);

        } // end UpdateFilesList

        /* Add / Edit game profile */
        private void buttonAddGame_Click(object sender, EventArgs e)
        {
            string? error = null;

            // Invalid save directory
            if (_saveDirectory == null || !Directory.Exists(_saveDirectory))
                error = "Save directory does not exist.";

            // Game name invalid
            else if (string.IsNullOrWhiteSpace(textBoxGameName.Text))
                error = "Game folder name cannot be empty";
            else
                foreach (char ch in Path.GetInvalidFileNameChars())
                    if (textBoxGameName.Text.Contains(ch))
                        error = "Invalid game folder name";

            // Game name taken
            if (FormMain.Saves != null)
                foreach (GameProfile save in FormMain.Saves)
                    if (save.GameName == textBoxGameName.Text)
                        error = "Game folder name already taken";

            // Any files invalid
            foreach (string file in _files)
                if (!File.Exists(file))
                {
                    error = "One of the save files does not exist.";
                    break;
                }

            // Show error and stop creating game
            if (error != null)
            {
                MessageBox.Show($"Error: {error}");
                return;
            }

            // If in edit mode, remove game before adding it
            if (_editMode && FormMain.Saves != null)
                foreach (GameProfile game in FormMain.Saves)
                    if (game.GameName == textBoxGameName.Text)
                    {
                        FormMain.Saves.Remove(game);
                        break;
                    }

            // No error - create new game
            FormMain.Saves.Add(new GameProfile(_saveDirectory, textBoxGameName.Text, _files));
            FormMain.outputText = $"({DateTime.Now}) {((_editMode) ? "Updated" : "Added")} game profile \"{textBoxGameName.Text}\".";
            GameAdded.Invoke(this, EventArgs.Empty);
            ProgramSave.Save();
            Close();

        } // end buttonAddGame_Click

        /* Delete game profile */
        private void buttonDeleteProfile_Click(object sender, EventArgs e)
        {
            if (!_editMode || FormMain.Saves == null)
                return;

            string gameName = textBoxGameName.Text;
            foreach (GameProfile save in FormMain.Saves)
                if (save.GameName == gameName)
                {
                    FormMain.Saves.Remove(save);
                    ProgramSave.Save();
                    FormMain.outputText = $"({DateTime.Now}) Deleted game profile \"{gameName}\".";
                    GameAdded.Invoke(this, EventArgs.Empty);
                    Close();
                    break;
                }

        } // end buttonDeleteProfile_Click

    } // end class FormAddGame

} // end namespace