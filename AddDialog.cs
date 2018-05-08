using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Microsoft.SharePoint;

namespace SPEventReceiverManager
{
    public partial class AddDialog : Form
    {
        #region Fields

        private readonly List<string> m_TypeNames;
        private readonly spevthkman m_ParentForm;

        #endregion

        #region Constructors

        public AddDialog(spevthkman parentForm, SPWeb web, ISecurableObject selectedObject)
            : base()
        {
            this.m_ParentForm = parentForm;

            InitializeComponent();

            this.m_TypeNames = new List<string>();

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

        internal Assembly SelectedAssembly
        {
            get
            {
                Assembly assembly = null;

                if (this.AssemblyComboBox.SelectedItem != null)
                {
                    FileInfo assemblyFile = (FileInfo)this.AssemblyComboBox.SelectedItem;

                    if (assemblyFile.Exists)
                    {
                        try
                        {
                            assembly = Assembly.LoadFile(assemblyFile.FullName);
                        }
                        catch (BadImageFormatException)
                        {
                            MessageBox.Show(this, "The selected assembly is not a .NET assembly and cannot be loaded.", "Invalid Assembly", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "The selected assembly cannot be found.", "Invalid Assembly", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                return assembly;
            }
        }

        internal Type SelectedType
        {
            get
            {
                Type type = null;

                if (this.ClassComboBox.SelectedItem != null)
                {
                    type = (Type)this.ClassComboBox.SelectedItem;
                }

                return type;
            }
        }

        #endregion

        #region Methods

        private void HandleException(Exception ex)
        {
            StringBuilder message = new StringBuilder(ex.ToString());

            ReflectionTypeLoadException tex = ex as ReflectionTypeLoadException;

            if (tex != null)
            {
                foreach (Exception o in tex.LoaderExceptions)
                {
                    message.AppendLine();
                    message.AppendLine("Loader Exception:");
                    message.AppendLine(o.ToString());
                }
            }

            MessageBox.Show(this, message.ToString(), "An unexpected errror has occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SetUIState(bool enabled)
        {
            this.AssemblyComboBox.Enabled = enabled;
            this.ClassComboBox.Enabled = enabled;
            this.BrowseFilesButton.Enabled = enabled;
            this.BrowseGACButton.Enabled = enabled;
            this.TypesCheckedListBox.Enabled = enabled;
            this.OkButton.Enabled = enabled;
            this.CloseButton.Enabled = enabled;
        }

        private void AddDialog_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (string str in Enum.GetNames(typeof(SPEventReceiverType)))
                {
                    this.m_TypeNames.Add(str);
                }

                if (this.m_ParentForm.GACCache.Count > 0)
                {
                    foreach (FileInfo assembly in this.m_ParentForm.GACCache)
                    {
                        this.AssemblyComboBox.Items.Add(assembly);
                    }

                    int selectedIndex = -1;

                    if (this.m_ParentForm.LastSelectedGACObjectType != null)
                    {
                        FileInfo file = new FileInfo(this.m_ParentForm.LastSelectedGACObjectType.Assembly.Location);

                        foreach (FileInfo assembly in this.AssemblyComboBox.Items)
                        {
                            if (selectedIndex == -1)
                            {
                                if (string.Equals(assembly.Name, file.Name, StringComparison.OrdinalIgnoreCase))
                                {
                                    selectedIndex = this.AssemblyComboBox.Items.IndexOf(assembly);
                                    break;
                                }
                            }
                        }
                    }

                    this.AssemblyComboBox.SelectedIndex = selectedIndex;
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void BrowseGACButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetUIState(false);
                this.AssemblyComboBox.Items.Clear();
                this.ClassComboBox.Items.Clear();
                this.TypesCheckedListBox.Items.Clear();

                DirectoryInfo gac = new DirectoryInfo(@"c:\windows\assembly\GAC_MSIL");

                this.m_ParentForm.GACCache.Clear();

                FileInfo[] files = gac.GetFiles("*.dll", SearchOption.AllDirectories);

                foreach (FileInfo file in files)
                {
                    this.m_ParentForm.GACCache.Add(file);
                }

                this.AssemblyComboBox.Items.AddRange(this.m_ParentForm.GACCache.ToArray());

                this.SetUIState(true);

                MessageBox.Show(this, "The GAC has been loaded. If you're adding additional event receiver hooks, you will not need to reload assemblies in the GAC. Please select an assembly.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void BrowseFilesButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetUIState(false);

                DialogResult result = this.BrowseFilesDialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    this.AssemblyComboBox.Items.Clear();
                    this.ClassComboBox.Items.Clear();
                    this.TypesCheckedListBox.Items.Clear();

                    string selectedFile = this.BrowseFilesDialog.FileName;

                    FileInfo assemblyFile = new FileInfo(selectedFile);

                    DirectoryInfo gac = new DirectoryInfo(@"c:\windows\assembly\GAC_MSIL");

                    FileInfo[] results = gac.GetFiles(assemblyFile.Name, SearchOption.AllDirectories);

                    if (MessageBox.Show(this, string.Format("The selected assembly was {0} in the GAC. Event receivers must be registered in the GAC and do not require Safe Control entries. Do you want to register the selected copy of this assembly?", (results.Length > 0 ? "found" : "not found")), "Register Selected Assembly in GAC?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Assembly assembly = Assembly.LoadFile(assemblyFile.FullName);

                        FUSION_INSTALL_REFERENCE[] gacSettings = new FUSION_INSTALL_REFERENCE[1];
                        gacSettings[0].dwFlags = 0;
                        gacSettings[0].guidScheme = AssemblyCache.FUSION_REFCOUNT_OPAQUE_STRING_GUID;
                        gacSettings[0].szIdentifier = assembly.GetName().Name;
                        gacSettings[0].szNonCannonicalData = assembly.FullName;

                        IAssemblyCache cache = AssemblyCache.CreateAssemblyCache();

                        cache.InstallAssembly(0, assemblyFile.FullName, gacSettings);
                    }

                    this.AssemblyComboBox.Items.Add(assemblyFile);

                    this.AssemblyComboBox.SelectedIndex = 1;
                }

                this.SetUIState(true);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void AssemblyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ClassComboBox.Items.Clear();
                this.TypesCheckedListBox.Items.Clear();

                Assembly selectedAssembly = this.SelectedAssembly;

                if (selectedAssembly != null)
                {
                    this.TypesCheckedListBox.Items.Clear();

                    Type[] types = selectedAssembly.GetTypes();

                    foreach (Type type in types)
                    {
                        if (typeof(SPItemEventReceiver).IsAssignableFrom(type))
                        {
                            this.ClassComboBox.Items.Add(type);
                        }
                    }

                    if (this.ClassComboBox.Items.Count == 0)
                    {
                        MessageBox.Show(this, "The selected assembly does not contain any event receivers. Please choose a different assembly.", "Invalid Assembly", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ClassComboBox.SelectedItem != null)
                {
                    this.TypesCheckedListBox.Items.Clear();

                    Type selectedType = this.SelectedType;

                    MethodInfo[] methods = selectedType.GetMethods();

                    foreach (MethodInfo method in methods)
                    {
                        if (this.m_TypeNames.Contains(method.Name))
                        {
                            if (method.DeclaringType == selectedType)
                            {
                                this.TypesCheckedListBox.Items.Add(method.Name, false);
                            }
                        }
                    }

                    if (this.TypesCheckedListBox.Items.Count == 0)
                    {
                        MessageBox.Show(this, "The selected class does not contain any event hooks. Please choose a different class.", "Invalid Assembly", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string typeName in this.TypesCheckedListBox.CheckedItems)
                {
                    try
                    {
                        Type selectedObjectType = this.SelectedObject.GetType();

                        SPEventReceiverType eventType = (SPEventReceiverType)Enum.Parse(typeof(SPEventReceiverType), typeName);

                        int maxSequence = 9999;

                        SPEventReceiverDefinitionCollection definitions = null;

                        string parentName = string.Empty;

                        if (typeof(SPWeb).IsAssignableFrom(selectedObjectType))
                        {
                            SPWeb web = (SPWeb)this.SelectedObject;

                            parentName = web.Name;
                            definitions = web.EventReceivers;
                        }
                        else if (typeof(SPList).IsAssignableFrom(selectedObjectType))
                        {
                            SPList list = (SPList)this.SelectedObject;

                            parentName = list.Title;
                            definitions = list.EventReceivers;
                        }
                        else
                        {
                            throw new NotSupportedException("The selected object type is not supported.");
                        }

                        if (definitions != null)
                        {
                            this.m_ParentForm.LastSelectedGACObjectType = this.SelectedType;

                            Utility.ProcessEventHookAction(this, this.SelectedObject, typeName, this.SelectedAssembly, this.SelectedType, this.UseNextSequenceNumberCheckBox.Checked);
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }

                MessageBox.Show(this, "The selected events have been hooked. The event sequence should be reviewed to ensure that events execute in the expected order.", "Event Hooks Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
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
