using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("firmware","fwr")]
    public partial class OM2MFirmware : OM2MMgmtResource
    {
        [OM2MXmlElement("version", "vr")]
        public string Version
        {
            get;
            set;
        }
        [OM2MXmlElement("firmwareName", "fwnnam")]
        public string FirmwareName
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
        [OM2MXmlElement("update", "ud")]
        public bool? Update
        {
            get;
            set;
        }
        [OM2MXmlElement("updateStatus", "uds")]
        public OM2MActionStatus UpdateStatus
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
    [OM2MXmlRoot("firmwareAnnc","fwrA")]
    public partial class OM2MFirmwareAnnc : OM2MAnnouncedMgmtResource
    {
        [OM2MXmlElement("version", "vr")]
        public string Version
        {
            get;
            set;
        }
        [OM2MXmlElement("firmwareName", "fwnnam")]
        public string FirmwareName
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
        [OM2MXmlElement("update", "ud")]
        public bool? Update
        {
            get;
            set;
        }
        [OM2MXmlElement("updateStatus", "uds")]
        public OM2MActionStatus UpdateStatus
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
