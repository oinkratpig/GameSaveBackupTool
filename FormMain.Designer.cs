namespace GameSaveBackupTool
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            comboBoxGames = new ComboBox();
            labelGame = new Label();
            buttonAddGame = new Button();
            labelDirectory = new Label();
            textBoxDirectory = new TextBox();
            buttonBrowseDirectory = new Button();
            buttonBackup = new Button();
            buttonOpenBackups = new Button();
            buttonResetDirectory = new Button();
            buttonDeleteGame = new Button();
            SuspendLayout();
            // 
            // comboBoxGames
            // 
            comboBoxGames.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGames.FormattingEnabled = true;
            comboBoxGames.Location = new Point(12, 27);
            comboBoxGames.Name = "comboBoxGames";
            comboBoxGames.Size = new Size(171, 23);
            comboBoxGames.TabIndex = 0;
            // 
            // labelGame
            // 
            labelGame.AutoSize = true;
            labelGame.Location = new Point(12, 9);
            labelGame.Name = "labelGame";
            labelGame.Size = new Size(38, 15);
            labelGame.TabIndex = 1;
            labelGame.Text = "Game";
            // 
            // buttonAddGame
            // 
            buttonAddGame.Location = new Point(189, 27);
            buttonAddGame.Name = "buttonAddGame";
            buttonAddGame.Size = new Size(99, 23);
            buttonAddGame.TabIndex = 2;
            buttonAddGame.Text = "Add New Game";
            buttonAddGame.UseVisualStyleBackColor = true;
            buttonAddGame.Click += buttonAddGame_Click;
            // 
            // labelDirectory
            // 
            labelDirectory.AutoSize = true;
            labelDirectory.Location = new Point(12, 63);
            labelDirectory.Name = "labelDirectory";
            labelDirectory.Size = new Size(97, 15);
            labelDirectory.TabIndex = 8;
            labelDirectory.Text = "Backup Directory";
            // 
            // textBoxDirectory
            // 
            textBoxDirectory.Location = new Point(12, 81);
            textBoxDirectory.Name = "textBoxDirectory";
            textBoxDirectory.ReadOnly = true;
            textBoxDirectory.Size = new Size(195, 23);
            textBoxDirectory.TabIndex = 7;
            // 
            // buttonBrowseDirectory
            // 
            buttonBrowseDirectory.Location = new Point(213, 81);
            buttonBrowseDirectory.Name = "buttonBrowseDirectory";
            buttonBrowseDirectory.Size = new Size(75, 23);
            buttonBrowseDirectory.TabIndex = 6;
            buttonBrowseDirectory.Text = "Browse";
            buttonBrowseDirectory.UseVisualStyleBackColor = true;
            buttonBrowseDirectory.Click += buttonBrowseDirectory_Click;
            // 
            // buttonBackup
            // 
            buttonBackup.BackColor = Color.MediumAquamarine;
            buttonBackup.ForeColor = SystemColors.ControlText;
            buttonBackup.Location = new Point(161, 152);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(127, 23);
            buttonBackup.TabIndex = 13;
            buttonBackup.Text = "Backup";
            buttonBackup.UseVisualStyleBackColor = false;
            buttonBackup.Click += buttonBackup_Click;
            // 
            // buttonOpenBackups
            // 
            buttonOpenBackups.Location = new Point(161, 123);
            buttonOpenBackups.Name = "buttonOpenBackups";
            buttonOpenBackups.Size = new Size(127, 23);
            buttonOpenBackups.TabIndex = 14;
            buttonOpenBackups.Text = "Open Backups Folder";
            buttonOpenBackups.UseVisualStyleBackColor = true;
            buttonOpenBackups.Click += buttonOpenBackups_Click;
            // 
            // buttonResetDirectory
            // 
            buttonResetDirectory.BackColor = Color.Salmon;
            buttonResetDirectory.Location = new Point(12, 152);
            buttonResetDirectory.Name = "buttonResetDirectory";
            buttonResetDirectory.Size = new Size(143, 23);
            buttonResetDirectory.TabIndex = 15;
            buttonResetDirectory.Text = "Reset Backup Directory";
            buttonResetDirectory.UseVisualStyleBackColor = false;
            buttonResetDirectory.Click += buttonResetDirectory_Click;
            // 
            // buttonDeleteGame
            // 
            buttonDeleteGame.BackColor = Color.Salmon;
            buttonDeleteGame.Location = new Point(12, 123);
            buttonDeleteGame.Name = "buttonDeleteGame";
            buttonDeleteGame.Size = new Size(143, 23);
            buttonDeleteGame.TabIndex = 16;
            buttonDeleteGame.Text = "Delete Game Profile";
            buttonDeleteGame.UseVisualStyleBackColor = false;
            buttonDeleteGame.Click += buttonDeleteGame_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 187);
            Controls.Add(buttonDeleteGame);
            Controls.Add(buttonResetDirectory);
            Controls.Add(buttonOpenBackups);
            Controls.Add(buttonBackup);
            Controls.Add(labelDirectory);
            Controls.Add(textBoxDirectory);
            Controls.Add(buttonBrowseDirectory);
            Controls.Add(buttonAddGame);
            Controls.Add(labelGame);
            Controls.Add(comboBoxGames);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormMain";
            Text = "Save Backup Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxGames;
        private Label labelGame;
        private Button buttonAddGame;
        private Label labelDirectory;
        private TextBox textBoxDirectory;
        private Button buttonBrowseDirectory;
        private Button buttonBackup;
        private Button buttonOpenBackups;
        private Button buttonResetDirectory;
        private Button buttonDeleteGame;
    }
}