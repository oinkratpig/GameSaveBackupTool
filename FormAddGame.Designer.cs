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
            labelGameName = new Label();
            textBoxGameName = new TextBox();
            buttonAddGame = new Button();
            buttonDeleteProfile = new Button();
            treeViewBackup = new TreeView();
            buttonAddFolder = new Button();
            buttonRemoveSelected = new Button();
            buttonCreateFolder = new Button();
            buttonAddFiles = new Button();
            textBoxCreateFolder = new TextBox();
            SuspendLayout();
            // 
            // labelFilesToBackup
            // 
            labelFilesToBackup.AutoSize = true;
            labelFilesToBackup.Location = new Point(12, 63);
            labelFilesToBackup.Name = "labelFilesToBackup";
            labelFilesToBackup.Size = new Size(130, 15);
            labelFilesToBackup.TabIndex = 9;
            labelFilesToBackup.Text = "Backup folder structure";
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
            buttonAddGame.Location = new Point(181, 290);
            buttonAddGame.Name = "buttonAddGame";
            buttonAddGame.Size = new Size(151, 24);
            buttonAddGame.TabIndex = 12;
            buttonAddGame.Text = "Add Profile";
            buttonAddGame.UseVisualStyleBackColor = false;
            buttonAddGame.Click += buttonAddGame_Click;
            // 
            // buttonDeleteProfile
            // 
            buttonDeleteProfile.BackColor = Color.Salmon;
            buttonDeleteProfile.Location = new Point(239, 27);
            buttonDeleteProfile.Name = "buttonDeleteProfile";
            buttonDeleteProfile.Size = new Size(93, 23);
            buttonDeleteProfile.TabIndex = 16;
            buttonDeleteProfile.Text = "Delete Profile";
            buttonDeleteProfile.UseVisualStyleBackColor = false;
            buttonDeleteProfile.Visible = false;
            buttonDeleteProfile.Click += buttonDeleteProfile_Click;
            // 
            // treeViewBackup
            // 
            treeViewBackup.Location = new Point(12, 82);
            treeViewBackup.Name = "treeViewBackup";
            treeViewBackup.ShowNodeToolTips = true;
            treeViewBackup.ShowRootLines = false;
            treeViewBackup.Size = new Size(320, 117);
            treeViewBackup.TabIndex = 17;
            // 
            // buttonAddFolder
            // 
            buttonAddFolder.BackColor = Color.Transparent;
            buttonAddFolder.Location = new Point(12, 205);
            buttonAddFolder.Name = "buttonAddFolder";
            buttonAddFolder.Size = new Size(151, 23);
            buttonAddFolder.TabIndex = 18;
            buttonAddFolder.Text = "Add Folder Link";
            buttonAddFolder.UseVisualStyleBackColor = false;
            buttonAddFolder.Click += buttonAddFolder_Click;
            // 
            // buttonRemoveSelected
            // 
            buttonRemoveSelected.BackColor = Color.Salmon;
            buttonRemoveSelected.Location = new Point(12, 291);
            buttonRemoveSelected.Name = "buttonRemoveSelected";
            buttonRemoveSelected.Size = new Size(151, 23);
            buttonRemoveSelected.TabIndex = 19;
            buttonRemoveSelected.Text = "Remove Selected";
            buttonRemoveSelected.UseVisualStyleBackColor = false;
            buttonRemoveSelected.Click += buttonRemoveSelected_Click;
            // 
            // buttonCreateFolder
            // 
            buttonCreateFolder.Location = new Point(181, 234);
            buttonCreateFolder.Name = "buttonCreateFolder";
            buttonCreateFolder.Size = new Size(151, 23);
            buttonCreateFolder.TabIndex = 20;
            buttonCreateFolder.Text = "Create Folder";
            buttonCreateFolder.UseVisualStyleBackColor = true;
            buttonCreateFolder.Click += buttonCreateFolder_Click;
            // 
            // buttonAddFiles
            // 
            buttonAddFiles.BackColor = Color.Transparent;
            buttonAddFiles.Location = new Point(181, 205);
            buttonAddFiles.Name = "buttonAddFiles";
            buttonAddFiles.Size = new Size(151, 23);
            buttonAddFiles.TabIndex = 21;
            buttonAddFiles.Text = "Add Save File(s)";
            buttonAddFiles.UseVisualStyleBackColor = false;
            buttonAddFiles.Click += buttonAddFiles_Click;
            // 
            // textBoxCreateFolder
            // 
            textBoxCreateFolder.Location = new Point(12, 234);
            textBoxCreateFolder.Name = "textBoxCreateFolder";
            textBoxCreateFolder.PlaceholderText = "New folder name...";
            textBoxCreateFolder.Size = new Size(151, 23);
            textBoxCreateFolder.TabIndex = 22;
            // 
            // FormAddGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 326);
            Controls.Add(textBoxCreateFolder);
            Controls.Add(buttonAddFiles);
            Controls.Add(buttonCreateFolder);
            Controls.Add(buttonRemoveSelected);
            Controls.Add(buttonAddFolder);
            Controls.Add(treeViewBackup);
            Controls.Add(buttonDeleteProfile);
            Controls.Add(buttonAddGame);
            Controls.Add(textBoxGameName);
            Controls.Add(labelGameName);
            Controls.Add(labelFilesToBackup);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormAddGame";
            Text = "Add Game Profile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelFilesToBackup;
        private Label labelGameName;
        private TextBox textBoxGameName;
        private Button buttonAddGame;
        private Button buttonDeleteProfile;
        private TreeView treeViewBackup;
        private Button buttonAddFolder;
        private Button buttonRemoveSelected;
        private Button buttonCreateFolder;
        private Button buttonAddFiles;
        private TextBox textBoxCreateFolder;
    }
}