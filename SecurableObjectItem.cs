using System;

namespace SPEventReceiverManager
{
    public class SecurableObjectItem
    {
        public SecurableObjectItem(string title, Guid objectId)
        {
            this.Title = title;
            this.ObjectId = objectId;
        }

        public string Title
        {
            get;
            protected set;
        }

        public Guid ObjectId
        {
            get;
            protected set;
        }
    }
}
