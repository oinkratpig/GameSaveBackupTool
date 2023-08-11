using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

            // Load program save file
            SaveFiles.BackupDirectory = SaveFiles.GetDefaultBackupDirectory();
            ProgramSave.Init();
            textBoxDirectory.Text = SaveFiles.BackupDirectory;
            ProgramSave.Save();
            OnGameAdded(this, EventArgs.Empty);

            // Set game profile if one exists
            if(comboBoxGames.Items.Count > 0)
                comboBoxGames.SelectedIndex = 0;

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

        private void buttonOpenBackups_Click(object sender, EventArgs e)
        {
            if (SaveFiles.BackupDirectory == null) return;
            Directory.CreateDirectory(SaveFiles.BackupDirectory);
            Process.Start("explorer.exe", SaveFiles.BackupDirectory);

        } // end buttonOpenBackups_Click

        private void buttonResetDirectory_Click(object sender, EventArgs e)
        {
            SaveFiles.BackupDirectory = SaveFiles.GetDefaultBackupDirectory();
            textBoxDirectory.Text = SaveFiles.BackupDirectory;

        } // end buttonResetDirectory_Click

        private void buttonDeleteGame_Click(object sender, EventArgs e)
        {
            if (Saves == null) return;

            foreach (SaveFiles save in Saves)
                if (save.GameName == comboBoxGames.Text)
                {
                    Saves.Remove(save);
                    OnGameAdded(this, EventArgs.Empty);
                    ProgramSave.Save();
                    break;
                }

        } // end buttonDeleteGame_Click

    } // end class FormMain

} // end namespace