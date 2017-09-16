using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("notificationTargetMgmtPolicyRef","ntpr")]
    public partial class OM2MNotificationTargetMgmtPolicyRef : OM2MRegularResource
    {
        [OM2MXmlElement("notificationTargetURI", typeof(OM2MListOfURIsDescription))]
        public List<string> NotificationTargetURI
        {
            get;
            set;
        }
        [OM2MXmlElement("notificationlPolicyID")]
        public string NotificationlPolicyID
        {
            get;
            set;
        }
        [OM2MXmlElement("childResource", typeof(OM2MChildResourceRef))]
        public List<OM2MChildResourceRef> ChildResource
        {
            get;
            set;
        }
        [OM2MXmlElement("subscription", "sub", typeof(OM2MSubscription))]
        public List<OM2MSubscription> Subscription
        {
            get;
            set;
        }
    }
}
