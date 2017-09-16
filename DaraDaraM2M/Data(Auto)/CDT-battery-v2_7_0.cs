using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("battery","bat")]
    public partial class OM2MBattery : OM2MMgmtResource
    {
        [OM2MXmlElement("batteryLevel", "btl")]
        public uint? BatteryLevel
        {
            get;
            set;
        }
        [OM2MXmlElement("batteryStatus", "bts")]
        public OM2MBatteryStatus? BatteryStatus
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
    [OM2MXmlRoot("batteryAnnc","batA")]
    public partial class OM2MBatteryAnnc : OM2MAnnouncedMgmtResource
    {
        [OM2MXmlElement("batteryLevel", "btl")]
        public uint? BatteryLevel
        {
            get;
            set;
        }
        [OM2MXmlElement("batteryStatus", "bts")]
        public OM2MBatteryStatus? BatteryStatus
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
