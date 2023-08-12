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
            textBoxOutput = new TextBox();
            textBoxSaveName = new TextBox();
            labelSaveName = new Label();
            buttonEditGame = new Button();
            checkBoxSaveNumberedPrefix = new CheckBox();
            label1 = new Label();
            checkBoxSaveNumberedPostfix = new CheckBox();
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
            buttonAddGame.Location = new Point(230, 27);
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
            labelDirectory.Location = new Point(12, 53);
            labelDirectory.Name = "labelDirectory";
            labelDirectory.Size = new Size(97, 15);
            labelDirectory.TabIndex = 8;
            labelDirectory.Text = "Backup Directory";
            // 
            // textBoxDirectory
            // 
            textBoxDirectory.Location = new Point(12, 71);
            textBoxDirectory.Name = "textBoxDirectory";
            textBoxDirectory.ReadOnly = true;
            textBoxDirectory.Size = new Size(236, 23);
            textBoxDirectory.TabIndex = 7;
            // 
            // buttonBrowseDirectory
            // 
            buttonBrowseDirectory.Location = new Point(254, 71);
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
            buttonBackup.Location = new Point(209, 244);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(120, 23);
            buttonBackup.TabIndex = 13;
            buttonBackup.Text = "Backup";
            buttonBackup.UseVisualStyleBackColor = false;
            buttonBackup.Click += buttonBackup_Click;
            // 
            // buttonOpenBackups
            // 
            buttonOpenBackups.Location = new Point(174, 100);
            buttonOpenBackups.Name = "buttonOpenBackups";
            buttonOpenBackups.Size = new Size(155, 23);
            buttonOpenBackups.TabIndex = 14;
            buttonOpenBackups.Text = "Open Backups Folder";
            buttonOpenBackups.UseVisualStyleBackColor = true;
            buttonOpenBackups.Click += buttonOpenBackups_Click;
            // 
            // buttonResetDirectory
            // 
            buttonResetDirectory.BackColor = Color.Salmon;
            buttonResetDirectory.Location = new Point(12, 100);
            buttonResetDirectory.Name = "buttonResetDirectory";
            buttonResetDirectory.Size = new Size(155, 23);
            buttonResetDirectory.TabIndex = 15;
            buttonResetDirectory.Text = "Reset Backup Directory";
            buttonResetDirectory.UseVisualStyleBackColor = false;
            buttonResetDirectory.Click += buttonResetDirectory_Click;
            // 
            // textBoxOutput
            // 
            textBoxOutput.Location = new Point(12, 129);
            textBoxOutput.Multiline = true;
            textBoxOutput.Name = "textBoxOutput";
            textBoxOutput.ReadOnly = true;
            textBoxOutput.ScrollBars = ScrollBars.Both;
            textBoxOutput.Size = new Size(317, 84);
            textBoxOutput.TabIndex = 17;
            textBoxOutput.WordWrap = false;
            // 
            // textBoxSaveName
            // 
            textBoxSaveName.Location = new Point(12, 244);
            textBoxSaveName.Name = "textBoxSaveName";
            textBoxSaveName.PlaceholderText = "save <date time>.zip";
            textBoxSaveName.Size = new Size(191, 23);
            textBoxSaveName.TabIndex = 18;
            // 
            // labelSaveName
            // 
            labelSaveName.AutoSize = true;
            labelSaveName.Location = new Point(12, 226);
            labelSaveName.Name = "labelSaveName";
            labelSaveName.Size = new Size(66, 15);
            labelSaveName.TabIndex = 19;
            labelSaveName.Text = "Save Name";
            // 
            // buttonEditGame
            // 
            buttonEditGame.Location = new Point(189, 27);
            buttonEditGame.Name = "buttonEditGame";
            buttonEditGame.Size = new Size(35, 23);
            buttonEditGame.TabIndex = 20;
            buttonEditGame.Text = "Edit";
            buttonEditGame.UseVisualStyleBackColor = true;
            buttonEditGame.Click += buttonEditGame_Click;
            // 
            // checkBoxSaveNumberedPrefix
            // 
            checkBoxSaveNumberedPrefix.AutoSize = true;
            checkBoxSaveNumberedPrefix.Location = new Point(147, 273);
            checkBoxSaveNumberedPrefix.Name = "checkBoxSaveNumberedPrefix";
            checkBoxSaveNumberedPrefix.Size = new Size(60, 19);
            checkBoxSaveNumberedPrefix.TabIndex = 21;
            checkBoxSaveNumberedPrefix.Text = "Before";
            checkBoxSaveNumberedPrefix.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 273);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 22;
            label1.Text = "Add Save File Numbers";
            // 
            // checkBoxSaveNumberedPostfix
            // 
            checkBoxSaveNumberedPostfix.AutoSize = true;
            checkBoxSaveNumberedPostfix.Location = new Point(210, 273);
            checkBoxSaveNumberedPostfix.Name = "checkBoxSaveNumberedPostfix";
            checkBoxSaveNumberedPostfix.Size = new Size(52, 19);
            checkBoxSaveNumberedPostfix.TabIndex = 23;
            checkBoxSaveNumberedPostfix.Text = "After";
            checkBoxSaveNumberedPostfix.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 305);
            Controls.Add(checkBoxSaveNumberedPostfix);
            Controls.Add(label1);
            Controls.Add(checkBoxSaveNumberedPrefix);
            Controls.Add(buttonEditGame);
            Controls.Add(labelSaveName);
            Controls.Add(textBoxSaveName);
            Controls.Add(textBoxOutput);
            Controls.Add(buttonResetDirectory);
            Controls.Add(buttonOpenBackups);
            Controls.Add(buttonBackup);
            Controls.Add(labelDirectory);
            Controls.Add(textBoxDirectory);
            Controls.Add(buttonBrowseDirectory);
            Controls.Add(buttonAddGame);
            Controls.Add(labelGame);
            Controls.Add(comboBoxGames);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
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
        private TextBox textBoxOutput;
        private TextBox textBoxSaveName;
        private Label labelSaveName;
        private Button buttonEditGame;
        private CheckBox checkBoxSaveNumberedPrefix;
        private Label label1;
        private CheckBox checkBoxSaveNumberedPostfix;
    }
}