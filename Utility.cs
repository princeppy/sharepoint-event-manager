using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace SPEventReceiverManager
{
    public static class Utility
    {
        public static MethodInfo ResolveEventHook(string assemblyFullName, string classFullName, SPEventReceiverType eventType)
        {
            MethodInfo method = null;

            Assembly assembly = Assembly.LoadWithPartialName(assemblyFullName);

            if (assembly != null)
            {
                Type type = assembly.GetType(classFullName);

                if (type != null)
                {
                    MethodInfo tempMethod = type.GetMethod(eventType.ToString());

                    if ((tempMethod != null) && (tempMethod.DeclaringType == type))
                    {
                        method = tempMethod;
                    }
                }
            }

            return method;
        }

        public static void GetSitesOnLocalServer(IList output) 
        {
            foreach (SPServiceInstance instance in SPServer.Local.ServiceInstances)
            {
                SPWebService service = instance.Service as SPWebService;

                if (service != null)
                {
                    foreach (SPWebApplication application in service.WebApplications)
                    {
                        foreach (SPSite site in application.Sites)
                        {
                            output.Add(new SiteItem(site.Url, site.ID));
                        }
                    }
                }
            }
        }

        public static void ProcessEventHookAction(Form parent, ISecurableObject obj, string typeName, Assembly selectedAssembly, Type selectedType, bool useNextSequenceNumber)
        {
            Type selectedObjectType = obj.GetType();

            SPEventReceiverType eventType = (SPEventReceiverType)Enum.Parse(typeof(SPEventReceiverType), typeName);

            int maxSequence = 9999;

            SPEventReceiverDefinitionCollection definitions = null;

            string parentName = string.Empty;

            if (typeof(SPWeb).IsAssignableFrom(selectedObjectType))
            {
                SPWeb web = (SPWeb)obj;

                parentName = web.Name;
                definitions = web.EventReceivers;
            }
            else if (typeof(SPList).IsAssignableFrom(selectedObjectType))
            {
                SPList list = (SPList)obj;

                parentName = list.Title;
                definitions = list.EventReceivers;
            }
            else
            {
                throw new NotSupportedException("The selected object type is not supported.");
            }

            if (definitions != null)
            {
                bool cancel = false;

                List<SPEventReceiverDefinition> pendingDelete = new List<SPEventReceiverDefinition>();

                foreach (SPEventReceiverDefinition definition in definitions)
                {
                    if ((definition.Type == eventType) && string.Equals(definition.Assembly, selectedAssembly.FullName) && string.Equals(definition.Class, selectedType.FullName))
                    {
                        if (MessageBox.Show(parent, string.Format("The selected event receiver has already been hooked to the [{0}] objects [{1}] event. Do you wish to overwrite the existing event hook?", parentName, eventType), "Event Already Hooked", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            pendingDelete.Add(definition);
                        }
                        else
                        {
                            cancel = true;
                            break;
                        }
                    }

                    if (definition.SequenceNumber > maxSequence)
                    {
                        maxSequence = definition.SequenceNumber;
                    }
                }

                foreach (SPEventReceiverDefinition definition in pendingDelete)
                {
                    definition.Delete();
                }

                if (cancel)
                {
                    return;
                }

                definitions.Add(eventType, selectedAssembly.FullName, selectedType.FullName);

                if (useNextSequenceNumber)
                {
                    foreach (SPEventReceiverDefinition definition in definitions)
                    {
                        if ((definition.Type == eventType) && string.Equals(definition.Assembly, selectedAssembly.FullName) && string.Equals(definition.Class, selectedType.FullName))
                        {
                            definition.SequenceNumber = (maxSequence + 1);
                            definition.Update();
                            break;
                        }
                    }
                }
            }
        }
    }
}
