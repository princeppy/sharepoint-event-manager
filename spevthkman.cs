using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using SPEventReceiverManager.Properties;
using SPEventReceiverManager.AutoUpdater;

namespace SPEventReceiverManager
{
    public partial class spevthkman : Form
    {
        #region Fields

        private SPSite m_Site;
        private SPWeb m_Web;
        private ISecurableObject m_SelectedObject;
        private readonly List<FileInfo> m_GACCache;

        #endregion

        #region Constructors

        public spevthkman()
        {
            this.InitializeComponent();
            this.m_GACCache = new List<FileInfo>();

            this.MainImageList.Images.Add(Resources.Lists);
            this.MainImageList.Images.Add(Resources.List);

            this.MainImageList.Images.Add(Resources.Libraries);
            this.MainImageList.Images.Add(Resources.Library);

            this.MainImageList.Images.Add(Resources.Webs);
            this.MainImageList.Images.Add(Resources.Web);

            this.MainImageList.Images.Add(Resources.Events);
            this.MainImageList.Images.Add(Resources.Event);
        }

        #endregion

        #region Properties

        internal TreeNode SelectedEventReceiverParent
        {
            get;
            private set;
        }

        internal List<FileInfo> GACCache
        {
            get
            {
                return this.m_GACCache;
            }
        }

        public System.Type LastSelectedGACObjectType { get; internal set; }

        #endregion

        #region Methods

        private void HandleException(Exception ex)
        {
            MessageBox.Show(this, ex.ToString(), "An unexpected errror has occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ResetObjectTreeView()
        {
            this.ObjectsTreeView.Nodes.Clear();
            this.ObjectsTreeView.Nodes.Add(ParentType.Lists.ToString(), ParentType.Lists.ToString(), 0, 0);
            this.ObjectsTreeView.Nodes.Add(ParentType.Libraries.ToString(), ParentType.Libraries.ToString(), 2, 2);
            this.ObjectsTreeView.Nodes.Add(ParentType.Websites.ToString(), ParentType.Websites.ToString(), 4, 4);
            this.ObjectsTreeView.Nodes.Add(ParentType.ContentTypes.ToString(), ParentType.ContentTypes.ToString(), 0, 0);

            this.SelectedEventReceiverParent = null;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.disableUpdateCheckToolStripMenuItem.Text = Settings.Default.EnableAutoUpdate ? "Disable Auto Update" : "Enable Auto Update";

                // Check for update if it's been more than one full day since the last update check.
                if ((DateTime.Today - Settings.Default.LastUpdateCheckDate).TotalMinutes >= 1440)
                {
                    UpdaterService service = new UpdaterService();
                    service.UpdateAvailable += new EventHandler<UpdateReaultEventArgs>(this.Service_UpdateAvailable);
                    service.CheckForUpdatesAsync();

                    Settings.Default.LastUpdateCheckDate = DateTime.Today;
                    Settings.Default.Save();
                }

                this.EventReceiverFilterToolStripComboBox.SelectedIndex = 0;

                Utility.GetSitesOnLocalServer(this.SiteComboBox.Items);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(this, "You do not have permission to access the selected site.", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void Service_UpdateAvailable(object sender, UpdateReaultEventArgs e)
        {
            if (MessageBox.Show("An updated version of this tool is available. Do you want to download the updated version?", "An Update is Available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(e.DownloadUrl);
            }
        }

        private void SiteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.ResetObjectTreeView();
                this.EventReceiverTreeView.Nodes.Clear();
                this.EventReceiverPropertyGrid.SelectedObject = null;
                this.AddToolStripButton.Enabled = false;
                this.DeleteToolStripButton.Enabled = false;
                this.DeleteAllToolStripButton.Enabled = false;
                this.RemoveInvalidToolStripButton.Enabled = false;
                this.RefreshEventHooksToolStripButton.Enabled = false;
                this.VerifyAllToolStripButton.Enabled = false;
                this.CopyHooksToolStripButton.Enabled = false;

                SiteItem siteItem = this.SiteComboBox.SelectedItem as SiteItem;

                if (siteItem != null)
                {
                    this.m_Site = new SPSite(siteItem.SiteId);
                    this.WebComboBox.Items.Clear();

                    foreach (SPWeb web in this.m_Site.AllWebs)
                    {
                        this.WebComboBox.Items.Add(new SiteItem((web.IsRootWeb ? "[Root Web]" : web.Name), web.ID));
                    }

                    foreach (SPContentType ct in this.m_Site.RootWeb.ContentTypes)
                    {
                        this.ObjectsTreeView.Nodes[1].Nodes.Add(ct.Id.ToString().ToUpper(), ct.Name, 3, 3);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(this, "You do not have permission to access the selected site.", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void WebComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.VerifyAllToolStripButton.Enabled = false;
                this.CopyHooksToolStripButton.Enabled = false;
                this.ResetObjectTreeView();
                this.EventReceiverTreeView.Nodes.Clear();
                this.EventReceiverPropertyGrid.SelectedObject = null;
                this.AddToolStripButton.Enabled = false;
                this.DeleteToolStripButton.Enabled = false;
                this.DeleteAllToolStripButton.Enabled = false;
                this.RemoveInvalidToolStripButton.Enabled = false;
                this.RefreshEventHooksToolStripButton.Enabled = false;

                SiteItem webItem = this.WebComboBox.SelectedItem as SiteItem;

                this.m_Web = this.m_Site.OpenWeb(webItem.SiteId);

                foreach (SPList list in this.m_Web.Lists)
                {
                    if (SPBaseType.DocumentLibrary == list.BaseType)
                    {
                        this.ObjectsTreeView.Nodes[1].Nodes.Add(list.ID.ToString("B").ToUpper(), list.Title, 3, 3);
                    }
                    else
                    {
                        this.ObjectsTreeView.Nodes[0].Nodes.Add(list.ID.ToString("B").ToUpper(), list.Title, 1, 1);
                    }
                }

                foreach (SPWeb childWeb in this.m_Web.Webs)
                {
                    this.ObjectsTreeView.Nodes[2].Nodes.Add(childWeb.ID.ToString("B").ToUpper(), childWeb.Title, 5, 5);
                }

                foreach (SPContentType ct in this.m_Site.RootWeb.ContentTypes)
                {
                    this.ObjectsTreeView.Nodes[3].Nodes.Add(ct.Id.ToString().ToUpper(), ct.Name, 3, 3);
                }

                this.ObjectsTreeView.ExpandAll();

                if (this.ObjectsTreeView.Nodes.Count > 0)
                {
                    this.ObjectsTreeView.SelectedNode = this.ObjectsTreeView.Nodes[0];
                }

                this.VerifyAllToolStripButton.Enabled = true;
                this.CopyHooksToolStripButton.Enabled = true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(this, "You do not have permission to access the selected site.", "Unauthorized Access", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private EventReceiverFilter GetEventReceiverFilter()
        {
            EventReceiverFilter filter = EventReceiverFilter.ShowAllEvents;

            switch (this.EventReceiverFilterToolStripComboBox.Text.Replace(" ", string.Empty))
            {
                case "ShowHookedEvents":
                    {
                        filter = EventReceiverFilter.ShowHookedEvents;
                        break;
                    }
                case "ShowUnhookedEvents":
                    {
                        filter = EventReceiverFilter.ShowUnhookedEvents;
                        break;
                    }
                default:
                    {
                        filter = EventReceiverFilter.ShowAllEvents;
                        break;
                    }
            }

            return filter;
        }

        private void ObjectsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.OnObjectSelected();
        }

        private void OnObjectSelected()
        {
            try
            {
                if ((this.ObjectsTreeView.SelectedNode != null) && (this.ObjectsTreeView.SelectedNode.Parent != null))
                {
                    this.EventReceiverTreeView.Nodes.Clear();
                    this.EventReceiverPropertyGrid.SelectedObject = null;
                    this.m_SelectedObject = null;

                    if (this.ObjectsTreeView.SelectedNode != null)
                    {
                        ParentType parentType = (ParentType)Enum.Parse(typeof(ParentType), this.ObjectsTreeView.SelectedNode.Parent.Name, false);
                        
                        this.LoadObjectEventReceivers(parentType, this.ObjectsTreeView.SelectedNode.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void LoadObjectEventReceivers(ParentType parentType, string name)
        {
            switch (parentType)
            {
                case ParentType.Lists:
                case ParentType.Libraries:
                    {
                        this.m_SelectedObject = this.m_Web.Lists[name];
                        break;
                    }

                //case ParentType.ContentTypes:
                //    {
                //        this.m_SelectedObject = this.m_Site.RootWeb.ContentTypes[name];
                //        break;
                //    }
                case ParentType.Websites:
                    {
                        this.m_SelectedObject = this.m_Web.Webs[name];
                        break;
                    }
                default:
                    {
                        MessageBox.Show(this, "The current type is not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }

            this.LoadEventReceivers();
        }

        private void EventReceiverTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if ((this.EventReceiverTreeView.SelectedNode) != null && (this.EventReceiverTreeView.SelectedNode.Parent != null))
                {
                    this.SelectedEventReceiverParent = this.EventReceiverTreeView.SelectedNode.Parent;

                    Guid defID = new Guid(this.EventReceiverTreeView.SelectedNode.Name);

                    if (this.m_SelectedObject != null)
                    {
                        if (typeof(SPWeb).IsAssignableFrom(this.m_SelectedObject.GetType()))
                        {
                            SPWeb web = (SPWeb)this.m_SelectedObject;

                            this.EventReceiverPropertyGrid.SelectedObject = web.EventReceivers[defID];
                        }
                        else if (typeof(SPList).IsAssignableFrom(this.m_SelectedObject.GetType()))
                        {
                            SPList list = (SPList)this.m_SelectedObject;

                            this.EventReceiverPropertyGrid.SelectedObject = list.EventReceivers[defID];
                        }
                        else
                        {
                            MessageBox.Show(this, "The current type is not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (AddDialog add = new AddDialog(this, this.m_Web, this.m_SelectedObject))
                {
                    add.ShowDialog(this);

                    this.LoadEventReceivers();
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void DeleteToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete the selected event hook?", "Confirm", MessageBoxButtons.YesNo))
                {
                    Guid guid = new Guid(this.EventReceiverTreeView.SelectedNode.Name);

                    if (this.m_SelectedObject != null)
                    {
                        this.DeleteEventReceiverHook(guid, this.m_SelectedObject);
                        this.LoadEventReceivers();
                    }
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void DeleteEventReceiverHook(Guid guid, ISecurableObject eventContiner)
        {
            SPEventReceiverDefinitionCollection definitions = null;

            if (typeof(SPWeb).IsAssignableFrom(eventContiner.GetType()))
            {
                SPWeb web = (SPWeb)eventContiner;

                definitions = web.EventReceivers;
            }
            else if (typeof(SPList).IsAssignableFrom(eventContiner.GetType()))
            {
                SPList list = (SPList)eventContiner;

                definitions = list.EventReceivers;
            }
            else
            {
                MessageBox.Show(this, "The current type is not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (definitions != null)
            {
                foreach (SPEventReceiverDefinition definition in definitions)
                {
                    if (guid == definition.Id)
                    {
                        string type = definition.Type.ToString();
                        string name = definition.Class;
                        definition.Delete();
                        MessageBox.Show(this, string.Format("The event hook [{0}] to class [{1}] was deleted.", type, name), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
        }

        private void LoadEventReceivers()
        {
            EventReceiverFilter filter = this.GetEventReceiverFilter();

            this.Cursor = Cursors.WaitCursor;
            this.EventReceiverTreeView.Nodes.Clear();
            this.EventReceiverPropertyGrid.SelectedObject = null;
            string[] names = Enum.GetNames(typeof(SPEventReceiverType));
            SortedDictionary<string, List<EventHook>> dictionary = new SortedDictionary<string, List<EventHook>>();

            foreach (string name in names)
            {
                dictionary.Add(name, new List<EventHook>());
            }

            if (this.m_SelectedObject != null)
            {
                SPEventReceiverDefinitionCollection definitions = null;

                if (typeof(SPWeb).IsAssignableFrom(this.m_SelectedObject.GetType()))
                {
                    SPWeb web = (SPWeb)this.m_SelectedObject;

                    definitions = web.EventReceivers;
                }
                else if (typeof(SPList).IsAssignableFrom(this.m_SelectedObject.GetType()))
                {
                    SPList list = (SPList)this.m_SelectedObject;

                    definitions = list.EventReceivers;
                }
                else
                {
                    MessageBox.Show(this, "The current type is not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (definitions != null)
                {
                    foreach (SPEventReceiverDefinition definition in definitions)
                    {
                        string eventName = definition.Id.ToString("B").ToUpper();

                        MethodInfo methodHook = null;

                        try
                        {
                            methodHook = Utility.ResolveEventHook(definition.Assembly, definition.Class, definition.Type);
                        }
                        catch
                        {
                            //Ignore Errror
                        }

                        EventHook hook = new EventHook(definition, methodHook);

                        dictionary[eventName].Add(hook);
                    }
                }

                foreach (KeyValuePair<string, List<EventHook>> pair in dictionary)
                {
                    bool show = true;

                    switch (filter)
                    {
                        case EventReceiverFilter.ShowHookedEvents:
                            {
                                if (pair.Value.Count == 0)
                                    show = false;
                                break;
                            }
                        case EventReceiverFilter.ShowUnhookedEvents:
                            {
                                if (pair.Value.Count > 0)
                                    show = false;
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }

                    if (show)
                    {
                        this.EventReceiverTreeView.Nodes.Add(pair.Key, pair.Key, 6, 6);
                    }

                    foreach (EventHook hook in pair.Value)
                    {
                        string typeName = hook.EventDefinition.Type.ToString();
                        string eventName = hook.EventDefinition.Id.ToString("B").ToUpper();

                        this.EventReceiverTreeView.Nodes[typeName].Nodes.Add(eventName, hook.EventDefinition.Class, 7, 7);

                        if (hook.MethodInfo == null)
                        {
                            this.EventReceiverTreeView.Nodes[typeName].Nodes[eventName].ForeColor = Color.Red;
                            this.EventReceiverTreeView.Nodes[typeName].Nodes[eventName].ToolTipText = "Invalid Event Receiver. The specified type could not be resolved.";
                        }
                    }
                }

                this.EventReceiverTreeView.ExpandAll();

                if (this.EventReceiverTreeView.Nodes.Count > 0)
                {
                    this.EventReceiverTreeView.SelectedNode = this.EventReceiverTreeView.Nodes[0];
                }
            }

            this.AddToolStripButton.Enabled = true;
            this.DeleteToolStripButton.Enabled = true;
            this.DeleteAllToolStripButton.Enabled = true;
            this.RemoveInvalidToolStripButton.Enabled = true;
            this.RefreshEventHooksToolStripButton.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void EventReceiverPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            try
            {
                if (this.EventReceiverPropertyGrid.SelectedObject != null)
                {
                    SPEventReceiverDefinition definition = (SPEventReceiverDefinition)this.EventReceiverPropertyGrid.SelectedObject;

                    definition.Update();
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void RemoveInvalidToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TreeNode node in this.EventReceiverTreeView.Nodes)
                {
                    if (node.Nodes.Count > 0)
                    {
                        foreach (TreeNode childNode in node.Nodes)
                        {
                            if (childNode.ForeColor == Color.Red)
                            {
                                Guid guid = new Guid(childNode.Name);

                                if (this.m_SelectedObject != null)
                                {
                                    this.DeleteEventReceiverHook(guid, this.m_SelectedObject);
                                }
                            }
                        }
                    }
                }

                this.LoadEventReceivers();
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void DeleteAllToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (TreeNode node in this.EventReceiverTreeView.Nodes)
                {
                    if (node.Nodes.Count > 0)
                    {
                        foreach (TreeNode childNode in node.Nodes)
                        {
                            Guid guid = new Guid(childNode.Name);

                            if (this.m_SelectedObject != null)
                            {
                                this.DeleteEventReceiverHook(guid, this.m_SelectedObject);
                            }
                        }
                    }
                }

                this.LoadEventReceivers();
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void RefreshEventHooksToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.LoadEventReceivers();
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void VerifyAllToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<SPEventReceiverDefinition> invalidDefinitions = new List<SPEventReceiverDefinition>();

                foreach (TreeNode objectNode in this.ObjectsTreeView.Nodes)
                {
                    ParentType parentType = (ParentType)Enum.Parse(typeof(ParentType), objectNode.Name, false);

                    foreach (TreeNode eventContainerNode in objectNode.Nodes)
                    {
                        Guid eventContainerId = new Guid(eventContainerNode.Name);

                        SPEventReceiverDefinitionCollection definitions = null;

                        switch (parentType)
                        {
                            case ParentType.Libraries:
                            case ParentType.Lists:
                                {
                                    definitions = this.m_Web.Lists[eventContainerId].EventReceivers;
                                    break;
                                }
                            case ParentType.Websites:
                                {
                                    definitions = this.m_Web.Webs[eventContainerId].EventReceivers;
                                    break;
                                }
                            default:
                                {
                                    throw new NotSupportedException("The specified parent type is not valid.");
                                }
                        }

                        if (definitions != null)
                        {
                            foreach (SPEventReceiverDefinition definition in definitions)
                            {
                                MethodInfo methodHook = null;

                                try
                                {
                                    methodHook = Utility.ResolveEventHook(definition.Assembly, definition.Class, definition.Type);
                                }
                                catch
                                {
                                    //Ignore Error
                                }

                                if (methodHook == null)
                                {
                                    invalidDefinitions.Add(definition);
                                }
                            }
                        }
                    }
                }

                StringBuilder message = new StringBuilder();

                MessageBoxButtons buttons = MessageBoxButtons.OK;

                if (invalidDefinitions.Count > 0)
                {
                    buttons = MessageBoxButtons.YesNo;
                    message.Append("The event hooks listed below in the current site are invalid. Do you want to remove these event hooks?");
                    message.Append(Environment.NewLine);

                    foreach (SPEventReceiverDefinition definition in invalidDefinitions)
                    {
                        message.AppendFormat("[{0}, {1}] [{2}]{3}", definition.Class, definition.Assembly, definition.ContextItemUrl, Environment.NewLine);
                    }
                }
                else
                {
                    message.Append("No invalid event hooks were found in the current site.");
                }

                if (DialogResult.Yes == MessageBox.Show(this, message.ToString(), "Invalid Event hook Search Result", buttons))
                {
                    foreach (SPEventReceiverDefinition definition in invalidDefinitions)
                    {
                        definition.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void CopyHooksToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.m_SelectedObject == null)
            {
                MessageBox.Show(this, "Please select a source list or library.", "Source Unknown", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!typeof(SPList).IsAssignableFrom(this.m_SelectedObject.GetType()))
            {
                MessageBox.Show(this, "The copy feature currently only supports duplicating event reciever hooks for lists and libraries.", "Webs Not Supported", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (CopyDialog dialog = new CopyDialog(this, this.m_Web ,this.m_SelectedObject))
            {
                dialog.ShowDialog();
            }
        }

        private void disableUpdateCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Disable Auto Update";
            bool enabled = false;
            
            if (this.disableUpdateCheckToolStripMenuItem.Text == text)
            {
                text = "Enable Auto Update";
            }
            else
            {
                enabled = true;
            }

            Settings.Default.EnableAutoUpdate = enabled;
            Settings.Default.Save();

            this.disableUpdateCheckToolStripMenuItem.Text = text; 
        }        
        
        private void ShoNodesToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OnObjectSelected();
        }

        #endregion
     }
}

