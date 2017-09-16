using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("accessControlPolicy","acp")]
    public partial class OM2MAccessControlPolicy : OM2MAnnounceableSubordinateResource
    {
        [OM2MXmlElement("privileges", "pv")]
        public OM2MSetOfAcrs Privileges
        {
            get;
            set;
        }
        [OM2MXmlElement("selfPrivileges", "pvs")]
        public OM2MSetOfAcrs SelfPrivileges
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
    [OM2MXmlRoot("accessControlPolicyAnnc","acpA")]
    public partial class OM2MAccessControlPolicyAnnc : OM2MAnnouncedSubordinateResource
    {
        [OM2MXmlElement("privileges", "pv")]
        public OM2MSetOfAcrs Privileges
        {
            get;
            set;
        }
        [OM2MXmlElement("selfPrivileges", "pvs")]
        public OM2MSetOfAcrs SelfPrivileges
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
