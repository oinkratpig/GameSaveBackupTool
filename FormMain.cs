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
    public partial class FormMain : Form
    {
        public static FormAddGame? FormAddGameInstance;

        public static List<SaveFiles>? Saves { get; set; }

        public FormMain()
        {
            InitializeComponent();
            Saves = new List<SaveFiles>();

        } // end constructor

        public void OnGameAdded(object? sender, EventArgs e)
        {
            if (Saves == null) return;

            comboBoxGames.Items.Clear();
            foreach (SaveFiles save in Saves)
            {
                comboBoxGames.Items.Add(save.GameName);
            }

        } // end OnGameAdded

        private void buttonAddGame_Click(object sender, EventArgs e)
        {
            if (FormAddGameInstance == null)
            {
                FormAddGameInstance = new FormAddGame();
                FormAddGameInstance.GameAdded += OnGameAdded;
                FormAddGameInstance.Show();
            }

        } // end buttonAddGame_Click

        private void buttonBrowseDirectory_Click(object sender, EventArgs e)
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

                // Get folder
                if (result == DialogResult.OK)
                {
                    string? directory = Path.GetDirectoryName(dialog.FileName);
                    if (!string.IsNullOrWhiteSpace(directory) && Directory.Exists(directory))
                    {
                        SaveFiles.BackupDirectory = directory;
                        textBoxDirectory.Text = directory;
                    }
                }
            }

        } // end buttonBrowseDirectory_Click

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            if (Saves == null) return;

            foreach (SaveFiles save in Saves)
            {
                if (save.GameName == comboBoxGames.Text)
                {
                    save.Backup();
                    break;
                }
            }

        } // end buttonBackup_Click

    } // end class FormMain

} // end namespace