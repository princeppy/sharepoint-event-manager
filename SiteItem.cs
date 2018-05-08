using System;

namespace SPEventReceiverManager
{
    public class SiteItem
    {
        public SiteItem(string displayName, Guid siteId)
        {
            this.DisplayName = displayName;
            this.SiteId = siteId;
        }

        public string DisplayName
        {
            get;
            protected set;
        }

        public Guid SiteId
        {
            get;
            protected set;
        }
    }
}
