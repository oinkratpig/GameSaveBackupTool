namespace GameSaveBackupTool
{
    partial class FormAddGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddGame));
            labelDirectory = new Label();
            textBoxSaveDirectory = new TextBox();
            labelFilesToBackup = new Label();
            listBoxFiles = new ListBox();
            labelGameName = new Label();
            textBoxGameName = new TextBox();
            buttonBrowseSaveDirectory = new Button();
            buttonAddGame = new Button();
            SuspendLayout();
            // 
            // labelDirectory
            // 
            labelDirectory.AutoSize = true;
            labelDirectory.Location = new Point(12, 9);
            labelDirectory.Name = "labelDirectory";
            labelDirectory.Size = new Size(116, 15);
            labelDirectory.TabIndex = 5;
            labelDirectory.Text = "Game Save Directory";
            // 
            // textBoxSaveDirectory
            // 
            textBoxSaveDirectory.Location = new Point(12, 27);
            textBoxSaveDirectory.Name = "textBoxSaveDirectory";
            textBoxSaveDirectory.ReadOnly = true;
            textBoxSaveDirectory.Size = new Size(239, 23);
            textBoxSaveDirectory.TabIndex = 4;
            // 
            // labelFilesToBackup
            // 
            labelFilesToBackup.AutoSize = true;
            labelFilesToBackup.Location = new Point(12, 122);
            labelFilesToBackup.Name = "labelFilesToBackup";
            labelFilesToBackup.Size = new Size(86, 15);
            labelFilesToBackup.TabIndex = 9;
            labelFilesToBackup.Text = "Files to Backup";
            // 
            // listBoxFiles
            // 
            listBoxFiles.BackColor = SystemColors.Control;
            listBoxFiles.FormattingEnabled = true;
            listBoxFiles.HorizontalScrollbar = true;
            listBoxFiles.ItemHeight = 15;
            listBoxFiles.Location = new Point(12, 140);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(320, 139);
            listBoxFiles.TabIndex = 8;
            // 
            // labelGameName
            // 
            labelGameName.AutoSize = true;
            labelGameName.Location = new Point(12, 65);
            labelGameName.Name = "labelGameName";
            labelGameName.Size = new Size(151, 15);
            labelGameName.TabIndex = 10;
            labelGameName.Text = "Game Backup Folder Name";
            // 
            // textBoxGameName
            // 
            textBoxGameName.Location = new Point(12, 83);
            textBoxGameName.Name = "textBoxGameName";
            textBoxGameName.Size = new Size(221, 23);
            textBoxGameName.TabIndex = 11;
            // 
            // buttonBrowseSaveDirectory
            // 
            buttonBrowseSaveDirectory.Location = new Point(257, 27);
            buttonBrowseSaveDirectory.Name = "buttonBrowseSaveDirectory";
            buttonBrowseSaveDirectory.Size = new Size(75, 23);
            buttonBrowseSaveDirectory.TabIndex = 3;
            buttonBrowseSaveDirectory.Text = "Browse";
            buttonBrowseSaveDirectory.UseVisualStyleBackColor = true;
            buttonBrowseSaveDirectory.Click += buttonBrowseSaveDirectory_Click;
            // 
            // buttonAddGame
            // 
            buttonAddGame.BackColor = Color.MediumAquamarine;
            buttonAddGame.ForeColor = SystemColors.ControlText;
            buttonAddGame.Location = new Point(239, 82);
            buttonAddGame.Name = "buttonAddGame";
            buttonAddGame.Size = new Size(93, 24);
            buttonAddGame.TabIndex = 12;
            buttonAddGame.Text = "Add Game";
            buttonAddGame.UseVisualStyleBackColor = false;
            buttonAddGame.Click += buttonAddGame_Click;
            // 
            // FormAddGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 290);
            Controls.Add(buttonAddGame);
            Controls.Add(textBoxGameName);
            Controls.Add(labelGameName);
            Controls.Add(labelFilesToBackup);
            Controls.Add(listBoxFiles);
            Controls.Add(labelDirectory);
            Controls.Add(textBoxSaveDirectory);
            Controls.Add(buttonBrowseSaveDirectory);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormAddGame";
            Text = "Add Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelDirectory;
        private TextBox textBoxSaveDirectory;
        private Label labelFilesToBackup;
        private ListBox listBoxFiles;
        private Label labelGameName;
        private TextBox textBoxGameName;
        private Button buttonBrowseSaveDirectory;
        private Button buttonAddGame;
    }
}