using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.SharePoint;
using System.Reflection;
using System.Text;

namespace SPEventReceiverManager
{
    public partial class CopyDialog : Form
    {       
        #region Fields

        private readonly spevthkman m_ParentForm;
        private  SPSite m_DestinationSite;
        private SPWeb m_DestinationWeb;
        private SPList m_DestinationList;

        #endregion

        #region Constructors

        public CopyDialog(spevthkman parentForm, SPWeb web, ISecurableObject selectedObject)
            : base()
        {
            this.m_ParentForm = parentForm;

            InitializeComponent();

            this.Web = web;
            this.SelectedObject = selectedObject;
        }

        #endregion

        #region Properties

        internal SPWeb Web
        {
            get;
            private set;
        }

        internal ISecurableObject SelectedObject
        {
            get;
            private set;
        }

        #endregion
        
        #region Methods

        private void HandleException(Exception ex)
        {
            MessageBox.Show(this, ex.ToString(), "An unexpected errror has occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CopyDialog_Load(object sender, EventArgs e)
        {
            try
            {
                this.SourceSiteLabel.Text = this.Web.Site.Url;
                this.SourceWebLabel.Text = this.Web.Title;

                SPList list = this.SelectedObject as SPList;
                
                this.SourceListLabel.Text = list.Title;

                foreach (SPEventReceiverDefinition def in list.EventReceivers)
                {
                    this.EventReceiverCheckedListBox.Items.Add(def, true); 
                }

                Utility.GetSitesOnLocalServer(this.SiteComboBox.Items);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void SiteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SiteItem siteItem = this.SiteComboBox.SelectedItem as SiteItem;

                if (siteItem != null)
                {
                    this.m_DestinationSite = new SPSite(siteItem.SiteId);
                    this.WebComboBox.Items.Clear();

                    foreach (SPWeb web in this.m_DestinationSite.AllWebs)
                    {
                        this.WebComboBox.Items.Add(new SiteItem((web.IsRootWeb ? "[Root Web]" : web.Name), web.ID));
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

                SiteItem webItem = this.WebComboBox.SelectedItem as SiteItem;

                this.m_DestinationWeb = this.m_DestinationSite.OpenWeb(webItem.SiteId);

                foreach (SPList list in this.m_DestinationWeb.Lists)
                {
                    this.ListComboBox.Items.Add(new SecurableObjectItem(list.Title, list.ID));
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

        private void ListComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecurableObjectItem listItem = this.ListComboBox.SelectedItem as SecurableObjectItem;

                this.m_DestinationList = this.m_DestinationWeb.Lists[listItem.ObjectId];
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

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (SPEventReceiverDefinition definition in this.EventReceiverCheckedListBox.CheckedItems)
                {
                    MethodInfo hook = Utility.ResolveEventHook(definition.Assembly, definition.Class, definition.Type);

                    if (hook == null)
                    {
                        StringBuilder message = new StringBuilder();
                        message.AppendLine("The event receiver listed below cannot be copied because the referenced assembly or type cannot be resolved.");
                        message.AppendFormat("[{0}, {1}] [{2}]", definition.Class, definition.Assembly, definition.ContextItemUrl);

                        MessageBox.Show(this, message.ToString(), "Invalid Event hook Search Result", MessageBoxButtons.OK);
                    }
                    else
                    {
                        Utility.ProcessEventHookAction(this, this.m_DestinationList, definition.Type.ToString(), hook.Module.Assembly, hook.ReflectedType, true);
                    }
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        #endregion
    }
}
