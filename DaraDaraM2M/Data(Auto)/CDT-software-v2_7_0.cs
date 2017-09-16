using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("software","swr")]
    public partial class OM2MSoftware : OM2MMgmtResource
    {
        [OM2MXmlElement("version", "vr")]
        public string Version
        {
            get;
            set;
        }
        [OM2MXmlElement("softwareName", "swn")]
        public string SoftwareName
        {
            get;
            set;
        }
        [OM2MXmlElement("URL", "url")]
        public string URL
        {
            get;
            set;
        }
        [OM2MXmlElement("install", "in")]
        public bool? Install
        {
            get;
            set;
        }
        [OM2MXmlElement("uninstall", "un")]
        public bool? Uninstall
        {
            get;
            set;
        }
        [OM2MXmlElement("installStatus", "ins")]
        public OM2MActionStatus InstallStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("activate", "act")]
        public bool? Activate
        {
            get;
            set;
        }
        [OM2MXmlElement("deactivate", "dea")]
        public bool? Deactivate
        {
            get;
            set;
        }
        [OM2MXmlElement("activeStatus", "acts")]
        public OM2MActionStatus ActiveStatus
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
    [OM2MXmlRoot("softwareAnnc","swrA")]
    public partial class OM2MSoftwareAnnc : OM2MAnnouncedMgmtResource
    {
        [OM2MXmlElement("version", "vr")]
        public string Version
        {
            get;
            set;
        }
        [OM2MXmlElement("softwareName", "swn")]
        public string SoftwareName
        {
            get;
            set;
        }
        [OM2MXmlElement("URL", "url")]
        public string URL
        {
            get;
            set;
        }
        [OM2MXmlElement("install", "in")]
        public bool? Install
        {
            get;
            set;
        }
        [OM2MXmlElement("uninstall", "un")]
        public bool? Uninstall
        {
            get;
            set;
        }
        [OM2MXmlElement("installStatus", "ins")]
        public OM2MActionStatus InstallStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("activate", "act")]
        public bool? Activate
        {
            get;
            set;
        }
        [OM2MXmlElement("deactivate", "dea")]
        public bool? Deactivate
        {
            get;
            set;
        }
        [OM2MXmlElement("activeStatus", "acts")]
        public OM2MActionStatus ActiveStatus
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
