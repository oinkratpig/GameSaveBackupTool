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
            comboBoxGames = new ComboBox();
            labelGame = new Label();
            buttonAddGame = new Button();
            labelDirectory = new Label();
            textBoxDirectory = new TextBox();
            buttonBrowseDirectory = new Button();
            buttonBackup = new Button();
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
            buttonBackup.Location = new Point(108, 131);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(75, 23);
            buttonBackup.TabIndex = 13;
            buttonBackup.Text = "Backup";
            buttonBackup.UseVisualStyleBackColor = false;
            buttonBackup.Click += buttonBackup_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(299, 190);
            Controls.Add(buttonBackup);
            Controls.Add(labelDirectory);
            Controls.Add(textBoxDirectory);
            Controls.Add(buttonBrowseDirectory);
            Controls.Add(buttonAddGame);
            Controls.Add(labelGame);
            Controls.Add(comboBoxGames);
            Name = "FormMain";
            Text = "Backup Tool";
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
    }
}