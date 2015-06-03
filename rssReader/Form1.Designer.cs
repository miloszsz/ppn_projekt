namespace rssReader
{
    partial class Form1
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
            this.refreshButton = new System.Windows.Forms.Button();
            this.titlesComboBox = new System.Windows.Forms.ComboBox();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.channelTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.savedLabel = new System.Windows.Forms.Label();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(262, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // titlesComboBox
            // 
            this.titlesComboBox.FormattingEnabled = true;
            this.titlesComboBox.Location = new System.Drawing.Point(12, 41);
            this.titlesComboBox.Name = "titlesComboBox";
            this.titlesComboBox.Size = new System.Drawing.Size(225, 21);
            this.titlesComboBox.TabIndex = 1;
            this.titlesComboBox.Text = "Titles";
            this.titlesComboBox.SelectedIndexChanged += new System.EventHandler(this.titlesComboBox_SelectedIndexChanged);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(12, 445);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(71, 13);
            this.linkLabel.TabIndex = 2;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Go to source:";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // channelTextBox
            // 
            this.channelTextBox.Location = new System.Drawing.Point(12, 12);
            this.channelTextBox.Name = "channelTextBox";
            this.channelTextBox.Size = new System.Drawing.Size(225, 20);
            this.channelTextBox.TabIndex = 3;
            this.channelTextBox.Text = "http://sport.wp.pl/kat,1786,rss.xml";
            this.channelTextBox.Click += new System.EventHandler(this.channelTextBox_Click);
            this.channelTextBox.TextChanged += new System.EventHandler(this.channelTextBox_TextChanged);
            this.channelTextBox.Enter += new System.EventHandler(this.channelTextBox_Enter);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(262, 41);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // savedLabel
            // 
            this.savedLabel.AutoSize = true;
            this.savedLabel.Location = new System.Drawing.Point(343, 44);
            this.savedLabel.Name = "savedLabel";
            this.savedLabel.Size = new System.Drawing.Size(0, 13);
            this.savedLabel.TabIndex = 6;
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(12, 68);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(644, 347);
            this.webBrowser.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 511);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.savedLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.channelTextBox);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.titlesComboBox);
            this.Controls.Add(this.refreshButton);
            this.Name = "Form1";
            this.Text = "RSS Reader by miloszsz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ComboBox titlesComboBox;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.TextBox channelTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label savedLabel;
        private System.Windows.Forms.WebBrowser webBrowser;
    }
}

