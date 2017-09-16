using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("reboot","rbo")]
    public partial class OM2MReboot : OM2MMgmtResource
    {
        [OM2MXmlElement("reboot", "rbo")]
        public bool? Reboot
        {
            get;
            set;
        }
        [OM2MXmlElement("factoryReset", "far")]
        public bool? FactoryReset
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
    [OM2MXmlRoot("rebootAnnc","rboA")]
    public partial class OM2MRebootAnnc : OM2MAnnouncedMgmtResource
    {
        [OM2MXmlElement("reboot", "rbo")]
        public bool? Reboot
        {
            get;
            set;
        }
        [OM2MXmlElement("factoryReset", "far")]
        public bool? FactoryReset
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
