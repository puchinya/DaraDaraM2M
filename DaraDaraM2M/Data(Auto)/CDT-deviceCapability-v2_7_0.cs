using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("deviceCapability","dvc")]
    public partial class OM2MDeviceCapability : OM2MMgmtResource
    {
        [OM2MXmlElement("capabilityName", "can")]
        public string CapabilityName
        {
            get;
            set;
        }
        [OM2MXmlElement("attached", "att")]
        public bool? Attached
        {
            get;
            set;
        }
        [OM2MXmlElement("capabilityActionStatus", "cas")]
        public OM2MActionStatus CapabilityActionStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("currentState", "cus")]
        public bool? CurrentState
        {
            get;
            set;
        }
        [OM2MXmlElement("enable", "ena")]
        public bool? Enable
        {
            get;
            set;
        }
        [OM2MXmlElement("disable", "dis")]
        public bool? Disable
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
    [OM2MXmlRoot("deviceCapabilityAnnc","dvcA")]
    public partial class OM2MDeviceCapabilityAnnc : OM2MAnnouncedMgmtResource
    {
        [OM2MXmlElement("capabilityName", "can")]
        public string CapabilityName
        {
            get;
            set;
        }
        [OM2MXmlElement("attached", "att")]
        public bool? Attached
        {
            get;
            set;
        }
        [OM2MXmlElement("capabilityActionStatus", "cas")]
        public OM2MActionStatus CapabilityActionStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("currentState", "cus")]
        public bool? CurrentState
        {
            get;
            set;
        }
        [OM2MXmlElement("enable", "ena")]
        public bool? Enable
        {
            get;
            set;
        }
        [OM2MXmlElement("disable", "dis")]
        public bool? Disable
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
