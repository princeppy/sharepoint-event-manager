namespace SPEventReceiverManager
{
    partial class CopyDialog
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DestinationGroupBox = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ListComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WebComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SiteComboBox = new System.Windows.Forms.ComboBox();
            this.EventReceiverCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SourceGroupBox = new System.Windows.Forms.GroupBox();
            this.SourceWebLabel = new System.Windows.Forms.Label();
            this.SourceListLabel = new System.Windows.Forms.Label();
            this.SourceSiteLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DestinationGroupBox.SuspendLayout();
            this.SourceGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(439, 338);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 8;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(358, 338);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 7;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(505, 48);
            this.label4.TabIndex = 13;
            this.label4.Text = "Select the destination site, web, and list to copy the selected event(s) to.";
            // 
            // DestinationGroupBox
            // 
            this.DestinationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationGroupBox.Controls.Add(this.label8);
            this.DestinationGroupBox.Controls.Add(this.ListComboBox);
            this.DestinationGroupBox.Controls.Add(this.label2);
            this.DestinationGroupBox.Controls.Add(this.WebComboBox);
            this.DestinationGroupBox.Controls.Add(this.label1);
            this.DestinationGroupBox.Controls.Add(this.SiteComboBox);
            this.DestinationGroupBox.Location = new System.Drawing.Point(10, 234);
            this.DestinationGroupBox.Name = "DestinationGroupBox";
            this.DestinationGroupBox.Size = new System.Drawing.Size(504, 98);
            this.DestinationGroupBox.TabIndex = 14;
            this.DestinationGroupBox.TabStop = false;
            this.DestinationGroupBox.Text = "Destination SharePoint Site/Web";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(6, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "List:";
            // 
            // ListComboBox
            // 
            this.ListComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListComboBox.DisplayMember = "Title";
            this.ListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListComboBox.FormattingEnabled = true;
            this.ListComboBox.Location = new System.Drawing.Point(40, 71);
            this.ListComboBox.MaxDropDownItems = 100;
            this.ListComboBox.Name = "ListComboBox";
            this.ListComboBox.Size = new System.Drawing.Size(458, 21);
            this.ListComboBox.TabIndex = 5;
            this.ListComboBox.ValueMember = "ObjectId";
            this.ListComboBox.SelectedIndexChanged += new System.EventHandler(this.ListComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Web:";
            // 
            // WebComboBox
            // 
            this.WebComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebComboBox.DisplayMember = "DisplayName";
            this.WebComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WebComboBox.FormattingEnabled = true;
            this.WebComboBox.Location = new System.Drawing.Point(40, 46);
            this.WebComboBox.MaxDropDownItems = 100;
            this.WebComboBox.Name = "WebComboBox";
            this.WebComboBox.Size = new System.Drawing.Size(458, 21);
            this.WebComboBox.TabIndex = 3;
            this.WebComboBox.ValueMember = "SiteId";
            this.WebComboBox.SelectedIndexChanged += new System.EventHandler(this.WebComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Site:";
            // 
            // SiteComboBox
            // 
            this.SiteComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SiteComboBox.DisplayMember = "DisplayName";
            this.SiteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SiteComboBox.FormattingEnabled = true;
            this.SiteComboBox.Location = new System.Drawing.Point(40, 19);
            this.SiteComboBox.Name = "SiteComboBox";
            this.SiteComboBox.Size = new System.Drawing.Size(458, 21);
            this.SiteComboBox.TabIndex = 0;
            this.SiteComboBox.ValueMember = "SiteId";
            this.SiteComboBox.SelectedIndexChanged += new System.EventHandler(this.SiteComboBox_SelectedIndexChanged);
            // 
            // EventReceiverCheckedListBox
            // 
            this.EventReceiverCheckedListBox.FormattingEnabled = true;
            this.EventReceiverCheckedListBox.Location = new System.Drawing.Point(7, 103);
            this.EventReceiverCheckedListBox.Name = "EventReceiverCheckedListBox";
            this.EventReceiverCheckedListBox.Size = new System.Drawing.Size(489, 79);
            this.EventReceiverCheckedListBox.TabIndex = 15;
            // 
            // SourceGroupBox
            // 
            this.SourceGroupBox.Controls.Add(this.SourceWebLabel);
            this.SourceGroupBox.Controls.Add(this.SourceListLabel);
            this.SourceGroupBox.Controls.Add(this.SourceSiteLabel);
            this.SourceGroupBox.Controls.Add(this.label7);
            this.SourceGroupBox.Controls.Add(this.label6);
            this.SourceGroupBox.Controls.Add(this.label5);
            this.SourceGroupBox.Controls.Add(this.EventReceiverCheckedListBox);
            this.SourceGroupBox.Controls.Add(this.label3);
            this.SourceGroupBox.Location = new System.Drawing.Point(12, 30);
            this.SourceGroupBox.Name = "SourceGroupBox";
            this.SourceGroupBox.Size = new System.Drawing.Size(502, 198);
            this.SourceGroupBox.TabIndex = 16;
            this.SourceGroupBox.TabStop = false;
            this.SourceGroupBox.Text = "Source";
            // 
            // SourceWebLabel
            // 
            this.SourceWebLabel.AutoSize = true;
            this.SourceWebLabel.Location = new System.Drawing.Point(97, 37);
            this.SourceWebLabel.Name = "SourceWebLabel";
            this.SourceWebLabel.Size = new System.Drawing.Size(59, 13);
            this.SourceWebLabel.TabIndex = 21;
            this.SourceWebLabel.Text = "[Unknown]";
            // 
            // SourceListLabel
            // 
            this.SourceListLabel.AutoSize = true;
            this.SourceListLabel.Location = new System.Drawing.Point(97, 59);
            this.SourceListLabel.Name = "SourceListLabel";
            this.SourceListLabel.Size = new System.Drawing.Size(59, 13);
            this.SourceListLabel.TabIndex = 20;
            this.SourceListLabel.Text = "[Unknown]";
            // 
            // SourceSiteLabel
            // 
            this.SourceSiteLabel.AutoSize = true;
            this.SourceSiteLabel.Location = new System.Drawing.Point(97, 16);
            this.SourceSiteLabel.Name = "SourceSiteLabel";
            this.SourceSiteLabel.Size = new System.Drawing.Size(59, 13);
            this.SourceSiteLabel.TabIndex = 18;
            this.SourceSiteLabel.Text = "[Unknown]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(4, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Hooked Events:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(4, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "List:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(4, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Web:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Site:";
            // 
            // CopyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(524, 373);
            this.ControlBox = false;
            this.Controls.Add(this.SourceGroupBox);
            this.Controls.Add(this.DestinationGroupBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CopyDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Copy Event Receiver Binding(s)";
            this.Load += new System.EventHandler(this.CopyDialog_Load);
            this.DestinationGroupBox.ResumeLayout(false);
            this.DestinationGroupBox.PerformLayout();
            this.SourceGroupBox.ResumeLayout(false);
            this.SourceGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox DestinationGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox WebComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SiteComboBox;
        private System.Windows.Forms.CheckedListBox EventReceiverCheckedListBox;
        private System.Windows.Forms.GroupBox SourceGroupBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ListComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SourceWebLabel;
        private System.Windows.Forms.Label SourceListLabel;
        private System.Windows.Forms.Label SourceSiteLabel;
    }
}