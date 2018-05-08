using System;
using System.Reflection;
using Microsoft.SharePoint;

namespace SPEventReceiverManager
{
    public class EventHook
    {
        public EventHook(SPEventReceiverDefinition definition, MethodInfo info)
        {
            this.EventDefinition = definition;
            this.MethodInfo = info;
        }

        public SPEventReceiverDefinition EventDefinition
        {
            get;
            private set;
        }

        public MethodInfo MethodInfo
        {
            get;
            private set;
        }
    }
}
