using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("memory","mem")]
    public partial class OM2MMemory : OM2MMgmtResource
    {
        [OM2MXmlElement("memAvailable", "mma")]
        public ulong? MemAvailable
        {
            get;
            set;
        }
        [OM2MXmlElement("memTotal", "mmt")]
        public ulong? MemTotal
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
    [OM2MXmlRoot("memoryAnnc","memA")]
    public partial class OM2MMemoryAnnc : OM2MAnnouncedMgmtResource
    {
        [OM2MXmlElement("memAvailable", "mma")]
        public ulong? MemAvailable
        {
            get;
            set;
        }
        [OM2MXmlElement("memTotal", "mmt")]
        public ulong? MemTotal
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
