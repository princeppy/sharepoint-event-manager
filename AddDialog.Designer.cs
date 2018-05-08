namespace SPEventReceiverManager
{
    partial class AddDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDialog));
            this.OkButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.BrowseGACButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClassComboBox = new System.Windows.Forms.ComboBox();
            this.BrowseFilesButton = new System.Windows.Forms.Button();
            this.BrowseFilesDialog = new System.Windows.Forms.OpenFileDialog();
            this.AssemblyComboBox = new System.Windows.Forms.ComboBox();
            this.TypesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.UseNextSequenceNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(356, 203);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(437, 203);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BrowseGACButton
            // 
            this.BrowseGACButton.Location = new System.Drawing.Point(437, 47);
            this.BrowseGACButton.Name = "BrowseGACButton";
            this.BrowseGACButton.Size = new System.Drawing.Size(37, 23);
            this.BrowseGACButton.TabIndex = 3;
            this.BrowseGACButton.Text = "GAC";
            this.BrowseGACButton.UseVisualStyleBackColor = true;
            this.BrowseGACButton.Click += new System.EventHandler(this.BrowseGACButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Assembly:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Class:";
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.DisplayMember = "Name";
            this.ClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassComboBox.FormattingEnabled = true;
            this.ClassComboBox.Location = new System.Drawing.Point(77, 76);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(440, 21);
            this.ClassComboBox.Sorted = true;
            this.ClassComboBox.TabIndex = 2;
            this.ClassComboBox.SelectedIndexChanged += new System.EventHandler(this.ClassComboBox_SelectedIndexChanged);
            // 
            // BrowseFilesButton
            // 
            this.BrowseFilesButton.Location = new System.Drawing.Point(480, 47);
            this.BrowseFilesButton.Name = "BrowseFilesButton";
            this.BrowseFilesButton.Size = new System.Drawing.Size(37, 23);
            this.BrowseFilesButton.TabIndex = 11;
            this.BrowseFilesButton.Text = "File";
            this.BrowseFilesButton.UseVisualStyleBackColor = true;
            this.BrowseFilesButton.Click += new System.EventHandler(this.BrowseFilesButton_Click);
            // 
            // BrowseFilesDialog
            // 
            this.BrowseFilesDialog.FileName = "*dll";
            this.BrowseFilesDialog.Filter = "Assemblies|*.dll";
            // 
            // AssemblyComboBox
            // 
            this.AssemblyComboBox.DisplayMember = "Name";
            this.AssemblyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssemblyComboBox.FormattingEnabled = true;
            this.AssemblyComboBox.IntegralHeight = false;
            this.AssemblyComboBox.Location = new System.Drawing.Point(77, 49);
            this.AssemblyComboBox.MaxDropDownItems = 25;
            this.AssemblyComboBox.Name = "AssemblyComboBox";
            this.AssemblyComboBox.Size = new System.Drawing.Size(354, 21);
            this.AssemblyComboBox.Sorted = true;
            this.AssemblyComboBox.TabIndex = 1;
            this.AssemblyComboBox.SelectedIndexChanged += new System.EventHandler(this.AssemblyComboBox_SelectedIndexChanged);
            // 
            // TypesCheckedListBox
            // 
            this.TypesCheckedListBox.CheckOnClick = true;
            this.TypesCheckedListBox.FormattingEnabled = true;
            this.TypesCheckedListBox.Location = new System.Drawing.Point(77, 103);
            this.TypesCheckedListBox.Name = "TypesCheckedListBox";
            this.TypesCheckedListBox.Size = new System.Drawing.Size(440, 94);
            this.TypesCheckedListBox.TabIndex = 3;
            this.TypesCheckedListBox.ThreeDCheckBoxes = true;
            // 
            // UseNextSequenceNumberCheckBox
            // 
            this.UseNextSequenceNumberCheckBox.AutoSize = true;
            this.UseNextSequenceNumberCheckBox.Checked = true;
            this.UseNextSequenceNumberCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseNextSequenceNumberCheckBox.Location = new System.Drawing.Point(77, 207);
            this.UseNextSequenceNumberCheckBox.Name = "UseNextSequenceNumberCheckBox";
            this.UseNextSequenceNumberCheckBox.Size = new System.Drawing.Size(162, 17);
            this.UseNextSequenceNumberCheckBox.TabIndex = 4;
            this.UseNextSequenceNumberCheckBox.Text = "Use Next Sequence Number";
            this.UseNextSequenceNumberCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Location = new System.Drawing.Point(12, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(505, 48);
            this.label4.TabIndex = 12;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // AddDialog
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(524, 242);
            this.ControlBox = false;
            this.Controls.Add(this.AssemblyComboBox);
            this.Controls.Add(this.BrowseFilesButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrowseGACButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UseNextSequenceNumberCheckBox);
            this.Controls.Add(this.TypesCheckedListBox);
            this.Controls.Add(this.ClassComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Add New Event Receiver Binding";
            this.Load += new System.EventHandler(this.AddDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button BrowseGACButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ClassComboBox;
        private System.Windows.Forms.Button BrowseFilesButton;
        private System.Windows.Forms.OpenFileDialog BrowseFilesDialog;
        private System.Windows.Forms.ComboBox AssemblyComboBox;
        private System.Windows.Forms.CheckedListBox TypesCheckedListBox;
        private System.Windows.Forms.CheckBox UseNextSequenceNumberCheckBox;
        private System.Windows.Forms.Label label4;
    }
}