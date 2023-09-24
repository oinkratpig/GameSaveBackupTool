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

        public static List<GameProfile> Profiles { get; set; }

        /// <summary>
        /// Root folders for all game profiles.<br/>
        /// Key: Game profile name<br/>
        /// Value: Root folder save data
        /// </summary>
        public static Dictionary<string, FolderData> ProfileRoots { get; set; }

        public static string? outputText;

        /* Constructor */
        static FormMain()
        {
            Profiles = new List<GameProfile>();
            ProfileRoots = new Dictionary<string, FolderData>();

        } // end constructor

        /* Constructor */
        public FormMain()
        {
            InitializeComponent();

            // Load program save file
            GameProfile.BackupDirectory = GameProfile.GetDefaultBackupDirectory();
            ProgramSave.Init();
            textBoxDirectory.Text = GameProfile.BackupDirectory;
            //ProgramSave.Save();
            OnGameAdded(this, EventArgs.Empty);

            // Set game profile if one exists
            if (comboBoxGames.Items.Count > 0)
                comboBoxGames.SelectedIndex = 0;

        } // end constructor

        /* Event called when new game is added */
        public void OnGameAdded(object? sender, EventArgs e)
        {
            comboBoxGames.Items.Clear();
            foreach (string gameName in ProfileRoots.Keys)
                comboBoxGames.Items.Add(gameName);

            // Set game profile if one exists and one not selected
            if (comboBoxGames.SelectedIndex == -1 && comboBoxGames.Items.Count > 0)
                comboBoxGames.SelectedIndex = 0;

            UpdateOutputTextBox();

        } // end OnGameAdded

        /* Update output text box */
        public void UpdateOutputTextBox()
        {
            textBoxOutput.Text = outputText;

        } // end UpdateOutputTextBox

        /* Add new game profile */
        private void buttonAddGame_Click(object sender, EventArgs e)
        {
            if (FormAddGameInstance == null)
            {
                FormAddGameInstance = new FormAddGame();
                FormAddGameInstance.GameAdded += OnGameAdded;
                FormAddGameInstance.Show();
            }

        } // end buttonAddGame_Click

        /* Browse backup directory */
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
                        GameProfile.BackupDirectory = directory;
                        textBoxDirectory.Text = directory;
                    }
                }
            }

        } // end buttonBrowseDirectory_Click

        /* Backup */
        private void buttonBackup_Click(object sender, EventArgs e)
        {
            if (Profiles == null) return;

            foreach (GameProfile save in Profiles)
            {
                if (save.GameName == comboBoxGames.Text)
                {
                    //save.Backup(textBoxSaveName.Text, checkBoxSaveNumberedPrefix.Checked, checkBoxSaveNumberedPostfix.Checked);
                    textBoxSaveName.Text = "";
                    break;
                }
            }

            UpdateOutputTextBox();

        } // end buttonBackup_Click

        /* Open backups folder */
        private void buttonOpenBackups_Click(object sender, EventArgs e)
        {
            if (GameProfile.BackupDirectory == null) return;
            Directory.CreateDirectory(GameProfile.BackupDirectory);
            Process.Start("explorer.exe", GameProfile.BackupDirectory);

        } // end buttonOpenBackups_Click

        private void buttonResetDirectory_Click(object sender, EventArgs e)
        {
            GameProfile.BackupDirectory = GameProfile.GetDefaultBackupDirectory();
            textBoxDirectory.Text = GameProfile.BackupDirectory;
            //ProgramSave.Save();

            outputText = $"({DateTime.Now}) Reset backup directory.";
            UpdateOutputTextBox();

        } // end buttonResetDirectory_Click

        /*
        // Delete game
        private void buttonDeleteGame_Click(object sender, EventArgs e)
        {
            if (Saves == null) return;

            string gameName = comboBoxGames.Text;

            foreach (SaveFiles save in Saves)
                if (save.GameName == gameName)
                {
                    Saves.Remove(save);
                    OnGameAdded(this, EventArgs.Empty);
                    ProgramSave.Save();
                    break;
                }

            outputText = $"({DateTime.Now}) Deleted game profile \"{gameName}\".";
            UpdateOutputTextBox();

        } // end buttonDeleteGame_Click
        */

        /* Edit game */
        private void buttonEditGame_Click(object sender, EventArgs e)
        {
            // Find game to edit
            FolderData? root = null;
            string gameName = comboBoxGames.Text;
            foreach (KeyValuePair<string, FolderData> kvp in ProfileRoots)
                if (kvp.Key == gameName)
                    root = kvp.Value;

            // No existing game
            if (root == null) return;

            // Open add game window
            if (FormAddGameInstance == null)
            {
                FormAddGameInstance = new FormAddGame(gameName, root);
                FormAddGameInstance.GameAdded += OnGameAdded;
                FormAddGameInstance.Show();
            }

        } // end buttonEditGame_Click

    } // end class FormMain

} // end namespace