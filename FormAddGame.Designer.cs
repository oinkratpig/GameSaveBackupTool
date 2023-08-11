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
            labelFilesToBackup = new Label();
            listBoxFiles = new ListBox();
            labelGameName = new Label();
            textBoxGameName = new TextBox();
            buttonAddGame = new Button();
            buttonRemoveFile = new Button();
            buttonAddFiles = new Button();
            SuspendLayout();
            // 
            // labelFilesToBackup
            // 
            labelFilesToBackup.AutoSize = true;
            labelFilesToBackup.Location = new Point(12, 63);
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
            listBoxFiles.Location = new Point(12, 81);
            listBoxFiles.Name = "listBoxFiles";
            listBoxFiles.Size = new Size(320, 139);
            listBoxFiles.TabIndex = 8;
            // 
            // labelGameName
            // 
            labelGameName.AutoSize = true;
            labelGameName.Location = new Point(12, 9);
            labelGameName.Name = "labelGameName";
            labelGameName.Size = new Size(151, 15);
            labelGameName.TabIndex = 10;
            labelGameName.Text = "Game Backup Folder Name";
            // 
            // textBoxGameName
            // 
            textBoxGameName.Location = new Point(12, 27);
            textBoxGameName.Name = "textBoxGameName";
            textBoxGameName.Size = new Size(221, 23);
            textBoxGameName.TabIndex = 11;
            // 
            // buttonAddGame
            // 
            buttonAddGame.BackColor = Color.MediumAquamarine;
            buttonAddGame.ForeColor = SystemColors.ControlText;
            buttonAddGame.Location = new Point(239, 26);
            buttonAddGame.Name = "buttonAddGame";
            buttonAddGame.Size = new Size(93, 24);
            buttonAddGame.TabIndex = 12;
            buttonAddGame.Text = "Add Game";
            buttonAddGame.UseVisualStyleBackColor = false;
            buttonAddGame.Click += buttonAddGame_Click;
            // 
            // buttonRemoveFile
            // 
            buttonRemoveFile.Location = new Point(12, 226);
            buttonRemoveFile.Name = "buttonRemoveFile";
            buttonRemoveFile.Size = new Size(151, 23);
            buttonRemoveFile.TabIndex = 14;
            buttonRemoveFile.Text = "Remove Selected File";
            buttonRemoveFile.UseVisualStyleBackColor = true;
            buttonRemoveFile.Click += buttonRemoveFile_Click;
            // 
            // buttonAddFiles
            // 
            buttonAddFiles.Location = new Point(181, 226);
            buttonAddFiles.Name = "buttonAddFiles";
            buttonAddFiles.Size = new Size(151, 23);
            buttonAddFiles.TabIndex = 15;
            buttonAddFiles.Text = "Add File(s)";
            buttonAddFiles.UseVisualStyleBackColor = true;
            buttonAddFiles.Click += buttonAddFiles_Click;
            // 
            // FormAddGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 262);
            Controls.Add(buttonAddFiles);
            Controls.Add(buttonRemoveFile);
            Controls.Add(buttonAddGame);
            Controls.Add(textBoxGameName);
            Controls.Add(labelGameName);
            Controls.Add(labelFilesToBackup);
            Controls.Add(listBoxFiles);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormAddGame";
            Text = "Add Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelFilesToBackup;
        private ListBox listBoxFiles;
        private Label labelGameName;
        private TextBox textBoxGameName;
        private Button buttonAddGame;
        private Button buttonRemoveFile;
        private Button buttonAddFiles;
    }
}