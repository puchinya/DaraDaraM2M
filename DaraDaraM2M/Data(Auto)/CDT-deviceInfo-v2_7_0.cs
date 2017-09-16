using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("deviceInfo","dvi")]
    public partial class OM2MDeviceInfo : OM2MMgmtResource
    {
        [OM2MXmlElement("deviceLabel", "dlb")]
        public string DeviceLabel
        {
            get;
            set;
        }
        [OM2MXmlElement("manufacturer", "man")]
        public string Manufacturer
        {
            get;
            set;
        }
        [OM2MXmlElement("model", "mod")]
        public string Model
        {
            get;
            set;
        }
        [OM2MXmlElement("deviceType", "dty")]
        public string DeviceType
        {
            get;
            set;
        }
        [OM2MXmlElement("fwVersion", "fwv")]
        public string FwVersion
        {
            get;
            set;
        }
        [OM2MXmlElement("swVersion", "swv")]
        public string SwVersion
        {
            get;
            set;
        }
        [OM2MXmlElement("hwVersion", "hwv")]
        public string HwVersion
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
    [OM2MXmlRoot("deviceInfoAnnc","dviA")]
    public partial class OM2MDeviceInfoAnnc : OM2MAnnouncedMgmtResource
    {
        [OM2MXmlElement("deviceLabel", "dlb")]
        public string DeviceLabel
        {
            get;
            set;
        }
        [OM2MXmlElement("manufacturer", "man")]
        public string Manufacturer
        {
            get;
            set;
        }
        [OM2MXmlElement("model", "mod")]
        public string Model
        {
            get;
            set;
        }
        [OM2MXmlElement("deviceType", "dty")]
        public string DeviceType
        {
            get;
            set;
        }
        [OM2MXmlElement("fwVersion", "fwv")]
        public string FwVersion
        {
            get;
            set;
        }
        [OM2MXmlElement("swVersion", "swv")]
        public string SwVersion
        {
            get;
            set;
        }
        [OM2MXmlElement("hwVersion", "hwv")]
        public string HwVersion
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
