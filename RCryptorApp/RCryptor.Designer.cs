namespace RCryptorApp
{
    partial class RCryptor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileButton = new Button();
            fileDialog = new OpenFileDialog();
            saveFileTextBox = new TextBox();
            outputDirTextBox = new TextBox();
            openOutputFileButton = new Button();
            encryptButton = new Button();
            decryptButton = new Button();
            dirDialog = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // openFileButton
            // 
            openFileButton.Location = new Point(267, 32);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new Size(105, 24);
            openFileButton.TabIndex = 0;
            openFileButton.Text = "Browse";
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += openFileButtonClick;
            // 
            // fileDialog
            // 
            fileDialog.ShowHiddenFiles = true;
            // 
            // saveFileTextBox
            // 
            saveFileTextBox.Location = new Point(12, 32);
            saveFileTextBox.Name = "saveFileTextBox";
            saveFileTextBox.PlaceholderText = "REPO save file (*.es3)...";
            saveFileTextBox.Size = new Size(239, 23);
            saveFileTextBox.TabIndex = 1;
            // 
            // outputDirTextBox
            // 
            outputDirTextBox.Location = new Point(12, 75);
            outputDirTextBox.Name = "outputDirTextBox";
            outputDirTextBox.PlaceholderText = "Output folder...";
            outputDirTextBox.Size = new Size(239, 23);
            outputDirTextBox.TabIndex = 3;
            // 
            // openOutputFileButton
            // 
            openOutputFileButton.Location = new Point(267, 75);
            openOutputFileButton.Name = "openOutputFileButton";
            openOutputFileButton.Size = new Size(105, 24);
            openOutputFileButton.TabIndex = 2;
            openOutputFileButton.Text = "Browse";
            openOutputFileButton.UseVisualStyleBackColor = true;
            openOutputFileButton.Click += openOutFileButtonClick;
            // 
            // encryptButton
            // 
            encryptButton.Location = new Point(99, 163);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(75, 23);
            encryptButton.TabIndex = 4;
            encryptButton.Text = "Encrypt";
            encryptButton.UseVisualStyleBackColor = true;
            encryptButton.Click += onEncrypt;
            // 
            // decryptButton
            // 
            decryptButton.Location = new Point(229, 163);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(75, 23);
            decryptButton.TabIndex = 5;
            decryptButton.Text = "Decrypt";
            decryptButton.UseVisualStyleBackColor = true;
            decryptButton.Click += onDecrypt;
            // 
            // dirDialog
            // 
            dirDialog.ShowHiddenFiles = true;
            // 
            // RCryptor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 271);
            Controls.Add(decryptButton);
            Controls.Add(encryptButton);
            Controls.Add(outputDirTextBox);
            Controls.Add(openOutputFileButton);
            Controls.Add(saveFileTextBox);
            Controls.Add(openFileButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RCryptor";
            Text = "RCryptor";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button openFileButton;
        private OpenFileDialog fileDialog;
        private TextBox saveFileTextBox;
        private TextBox outputDirTextBox;
        private Button openOutputFileButton;
        private Button encryptButton;
        private Button decryptButton;
        private FolderBrowserDialog dirDialog;
    }
}
