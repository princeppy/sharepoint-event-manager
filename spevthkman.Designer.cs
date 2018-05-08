using System.Windows.Forms;
namespace SPEventReceiverManager
{
    partial class spevthkman
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

        private ComboBox SiteComboBox;
        private GroupBox groupBox2;
        private TreeView ObjectsTreeView;
        private GroupBox groupBox3;
        private ToolStripContainer ToolStripContainer;
        private TreeView EventReceiverTreeView;
        private ToolStrip EventReceiverToolStrip;
        private ToolStripButton AddToolStripButton;
        private ToolStripButton DeleteToolStripButton;
        private Label label2;
        private ComboBox WebComboBox;
        private Label label1;
        private GroupBox groupBox1;


        private GroupBox groupBox4;
        private PropertyGrid EventReceiverPropertyGrid;
        private ToolStripButton RemoveInvalidToolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton DeleteAllToolStripButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton RefreshEventHooksToolStripButton;
        private ToolStripContainer toolStripContainer1;
        private ToolStrip SelectedObjectToolStrip;
        private ToolStripButton VerifyAllToolStripButton;
        private ImageList MainImageList;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(spevthkman));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WebComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SiteComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.ObjectsTreeView = new System.Windows.Forms.TreeView();
            this.MainImageList = new System.Windows.Forms.ImageList(this.components);
            this.SelectedObjectToolStrip = new System.Windows.Forms.ToolStrip();
            this.VerifyAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CopyHooksToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.EventReceiverTreeView = new System.Windows.Forms.TreeView();
            this.EventReceiverToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveInvalidToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshEventHooksToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EventReceiverFilterToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.EventReceiverPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.MainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.disableUpdateCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.SecondarySplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SelectedObjectToolStrip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.EventReceiverToolStrip.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.MainContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondarySplitContainer)).BeginInit();
            this.SecondarySplitContainer.Panel1.SuspendLayout();
            this.SecondarySplitContainer.Panel2.SuspendLayout();
            this.SecondarySplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.WebComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SiteComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(684, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SharePoint Site/Web";
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
            this.WebComboBox.Size = new System.Drawing.Size(638, 21);
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
            this.SiteComboBox.Size = new System.Drawing.Size(638, 21);
            this.SiteComboBox.TabIndex = 0;
            this.SiteComboBox.ValueMember = "SiteId";
            this.SiteComboBox.SelectedIndexChanged += new System.EventHandler(this.SiteComboBox_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toolStripContainer1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(217, 449);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected Web Objects";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.ObjectsTreeView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(211, 405);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 16);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(211, 430);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.SelectedObjectToolStrip);
            // 
            // ObjectsTreeView
            // 
            this.ObjectsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ObjectsTreeView.ImageIndex = 0;
            this.ObjectsTreeView.ImageList = this.MainImageList;
            this.ObjectsTreeView.Location = new System.Drawing.Point(0, 0);
            this.ObjectsTreeView.Name = "ObjectsTreeView";
            this.ObjectsTreeView.SelectedImageIndex = 0;
            this.ObjectsTreeView.Size = new System.Drawing.Size(211, 405);
            this.ObjectsTreeView.TabIndex = 0;
            this.ObjectsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ObjectsTreeView_AfterSelect);
            // 
            // MainImageList
            // 
            this.MainImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.MainImageList.ImageSize = new System.Drawing.Size(16, 16);
            this.MainImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SelectedObjectToolStrip
            // 
            this.SelectedObjectToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.SelectedObjectToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.SelectedObjectToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerifyAllToolStripButton,
            this.CopyHooksToolStripButton});
            this.SelectedObjectToolStrip.Location = new System.Drawing.Point(3, 0);
            this.SelectedObjectToolStrip.Name = "SelectedObjectToolStrip";
            this.SelectedObjectToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.SelectedObjectToolStrip.Size = new System.Drawing.Size(168, 25);
            this.SelectedObjectToolStrip.TabIndex = 0;
            // 
            // VerifyAllToolStripButton
            // 
            this.VerifyAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.VerifyAllToolStripButton.Enabled = false;
            this.VerifyAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("VerifyAllToolStripButton.Image")));
            this.VerifyAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.VerifyAllToolStripButton.Name = "VerifyAllToolStripButton";
            this.VerifyAllToolStripButton.Size = new System.Drawing.Size(89, 22);
            this.VerifyAllToolStripButton.Text = "Find All Invalid";
            this.VerifyAllToolStripButton.Click += new System.EventHandler(this.VerifyAllToolStripButton_Click);
            // 
            // CopyHooksToolStripButton
            // 
            this.CopyHooksToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CopyHooksToolStripButton.Enabled = false;
            this.CopyHooksToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CopyHooksToolStripButton.Image")));
            this.CopyHooksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyHooksToolStripButton.Name = "CopyHooksToolStripButton";
            this.CopyHooksToolStripButton.Size = new System.Drawing.Size(76, 22);
            this.CopyHooksToolStripButton.Text = "Copy Hooks";
            this.CopyHooksToolStripButton.Click += new System.EventHandler(this.CopyHooksToolStripButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ToolStripContainer);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(463, 207);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Event Receivers";
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.EventReceiverTreeView);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(457, 163);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer.Location = new System.Drawing.Point(3, 16);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(457, 188);
            this.ToolStripContainer.TabIndex = 1;
            this.ToolStripContainer.Text = "toolStripContainer1";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.EventReceiverToolStrip);
            // 
            // EventReceiverTreeView
            // 
            this.EventReceiverTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventReceiverTreeView.ImageIndex = 0;
            this.EventReceiverTreeView.ImageList = this.MainImageList;
            this.EventReceiverTreeView.Location = new System.Drawing.Point(0, 0);
            this.EventReceiverTreeView.Name = "EventReceiverTreeView";
            this.EventReceiverTreeView.SelectedImageIndex = 0;
            this.EventReceiverTreeView.Size = new System.Drawing.Size(457, 163);
            this.EventReceiverTreeView.TabIndex = 0;
            this.EventReceiverTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.EventReceiverTreeView_AfterSelect);
            // 
            // EventReceiverToolStrip
            // 
            this.EventReceiverToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.EventReceiverToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.EventReceiverToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripButton,
            this.toolStripSeparator1,
            this.DeleteToolStripButton,
            this.DeleteAllToolStripButton,
            this.RemoveInvalidToolStripButton,
            this.toolStripSeparator2,
            this.RefreshEventHooksToolStripButton,
            this.EventReceiverFilterToolStripComboBox});
            this.EventReceiverToolStrip.Location = new System.Drawing.Point(3, 0);
            this.EventReceiverToolStrip.Name = "EventReceiverToolStrip";
            this.EventReceiverToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.EventReceiverToolStrip.Size = new System.Drawing.Size(444, 25);
            this.EventReceiverToolStrip.TabIndex = 0;
            // 
            // AddToolStripButton
            // 
            this.AddToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddToolStripButton.Enabled = false;
            this.AddToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddToolStripButton.Image")));
            this.AddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolStripButton.Name = "AddToolStripButton";
            this.AddToolStripButton.Size = new System.Drawing.Size(33, 22);
            this.AddToolStripButton.Text = "Add";
            this.AddToolStripButton.Click += new System.EventHandler(this.AddToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // DeleteToolStripButton
            // 
            this.DeleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteToolStripButton.Enabled = false;
            this.DeleteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteToolStripButton.Image")));
            this.DeleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolStripButton.Name = "DeleteToolStripButton";
            this.DeleteToolStripButton.Size = new System.Drawing.Size(44, 22);
            this.DeleteToolStripButton.Text = "Delete";
            this.DeleteToolStripButton.Click += new System.EventHandler(this.DeleteToolStripButton_Click);
            // 
            // DeleteAllToolStripButton
            // 
            this.DeleteAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteAllToolStripButton.Enabled = false;
            this.DeleteAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteAllToolStripButton.Image")));
            this.DeleteAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteAllToolStripButton.Name = "DeleteAllToolStripButton";
            this.DeleteAllToolStripButton.Size = new System.Drawing.Size(61, 22);
            this.DeleteAllToolStripButton.Text = "Delete All";
            this.DeleteAllToolStripButton.Click += new System.EventHandler(this.DeleteAllToolStripButton_Click);
            // 
            // RemoveInvalidToolStripButton
            // 
            this.RemoveInvalidToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RemoveInvalidToolStripButton.Enabled = false;
            this.RemoveInvalidToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveInvalidToolStripButton.Image")));
            this.RemoveInvalidToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveInvalidToolStripButton.Name = "RemoveInvalidToolStripButton";
            this.RemoveInvalidToolStripButton.Size = new System.Drawing.Size(99, 22);
            this.RemoveInvalidToolStripButton.Text = "Delete All Invalid";
            this.RemoveInvalidToolStripButton.Click += new System.EventHandler(this.RemoveInvalidToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // RefreshEventHooksToolStripButton
            // 
            this.RefreshEventHooksToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RefreshEventHooksToolStripButton.Enabled = false;
            this.RefreshEventHooksToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshEventHooksToolStripButton.Image")));
            this.RefreshEventHooksToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshEventHooksToolStripButton.Name = "RefreshEventHooksToolStripButton";
            this.RefreshEventHooksToolStripButton.Size = new System.Drawing.Size(50, 22);
            this.RefreshEventHooksToolStripButton.Text = "Refresh";
            this.RefreshEventHooksToolStripButton.Click += new System.EventHandler(this.RefreshEventHooksToolStripButton_Click);
            // 
            // EventReceiverFilterToolStripComboBox
            // 
            this.EventReceiverFilterToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EventReceiverFilterToolStripComboBox.Items.AddRange(new object[] {
            "Show All Events",
            "Show Hooked Events",
            "Show Unhooked Events"});
            this.EventReceiverFilterToolStripComboBox.Name = "EventReceiverFilterToolStripComboBox";
            this.EventReceiverFilterToolStripComboBox.Size = new System.Drawing.Size(140, 25);
            this.EventReceiverFilterToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.ShoNodesToolStripComboBox_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.EventReceiverPropertyGrid);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(463, 238);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Event Receiver Details";
            // 
            // EventReceiverPropertyGrid
            // 
            this.EventReceiverPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EventReceiverPropertyGrid.HelpVisible = false;
            this.EventReceiverPropertyGrid.Location = new System.Drawing.Point(3, 16);
            this.EventReceiverPropertyGrid.Name = "EventReceiverPropertyGrid";
            this.EventReceiverPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.EventReceiverPropertyGrid.Size = new System.Drawing.Size(457, 219);
            this.EventReceiverPropertyGrid.TabIndex = 0;
            this.EventReceiverPropertyGrid.ToolbarVisible = false;
            this.EventReceiverPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.EventReceiverPropertyGrid_PropertyValueChanged);
            // 
            // MainContextMenuStrip
            // 
            this.MainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disableUpdateCheckToolStripMenuItem});
            this.MainContextMenuStrip.Name = "MainContextMenuStrip";
            this.MainContextMenuStrip.Size = new System.Drawing.Size(190, 26);
            // 
            // disableUpdateCheckToolStripMenuItem
            // 
            this.disableUpdateCheckToolStripMenuItem.Name = "disableUpdateCheckToolStripMenuItem";
            this.disableUpdateCheckToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.disableUpdateCheckToolStripMenuItem.Text = "Disable Update Check";
            this.disableUpdateCheckToolStripMenuItem.Click += new System.EventHandler(this.disableUpdateCheckToolStripMenuItem_Click);
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainSplitContainer.Location = new System.Drawing.Point(12, 94);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.groupBox2);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.SecondarySplitContainer);
            this.MainSplitContainer.Size = new System.Drawing.Size(684, 449);
            this.MainSplitContainer.SplitterDistance = 217;
            this.MainSplitContainer.TabIndex = 4;
            // 
            // SecondarySplitContainer
            // 
            this.SecondarySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecondarySplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SecondarySplitContainer.Name = "SecondarySplitContainer";
            this.SecondarySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SecondarySplitContainer.Panel1
            // 
            this.SecondarySplitContainer.Panel1.Controls.Add(this.groupBox3);
            // 
            // SecondarySplitContainer.Panel2
            // 
            this.SecondarySplitContainer.Panel2.Controls.Add(this.groupBox4);
            this.SecondarySplitContainer.Size = new System.Drawing.Size(463, 449);
            this.SecondarySplitContainer.SplitterDistance = 207;
            this.SecondarySplitContainer.TabIndex = 0;
            // 
            // spevthkman
            // 
            this.ClientSize = new System.Drawing.Size(708, 555);
            this.ContextMenuStrip = this.MainContextMenuStrip;
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.groupBox1);
            this.Name = "spevthkman";
            this.Text = "SharePoint 2016 Event Receiver Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.SelectedObjectToolStrip.ResumeLayout(false);
            this.SelectedObjectToolStrip.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.EventReceiverToolStrip.ResumeLayout(false);
            this.EventReceiverToolStrip.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.MainContextMenuStrip.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.SecondarySplitContainer.Panel1.ResumeLayout(false);
            this.SecondarySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SecondarySplitContainer)).EndInit();
            this.SecondarySplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStripButton CopyHooksToolStripButton;
        private ContextMenuStrip MainContextMenuStrip;
        private ToolStripMenuItem disableUpdateCheckToolStripMenuItem;
        private SplitContainer MainSplitContainer;
        private SplitContainer SecondarySplitContainer;
        private ToolStripComboBox EventReceiverFilterToolStripComboBox;
    }
}