using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("eventLog","evl")]
    public partial class OM2MEventLog : OM2MMgmtResource
    {
        [OM2MXmlElement("logTypeId", "lgt")]
        public OM2MLogTypeId? LogTypeId
        {
            get;
            set;
        }
        [OM2MXmlElement("logData", "lgd")]
        public string LogData
        {
            get;
            set;
        }
        [OM2MXmlElement("logStatus", "lgst")]
        public OM2MLogStatus? LogStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("logStart", "lga")]
        public bool? LogStart
        {
            get;
            set;
        }
        [OM2MXmlElement("logStop", "lgo")]
        public bool? LogStop
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
    [OM2MXmlRoot("eventLogAnnc","evlA")]
    public partial class OM2MEventLogAnnc : OM2MAnnouncedMgmtResource
    {
        [OM2MXmlElement("logTypeId", "lgt")]
        public OM2MLogTypeId? LogTypeId
        {
            get;
            set;
        }
        [OM2MXmlElement("logData", "lgd")]
        public string LogData
        {
            get;
            set;
        }
        [OM2MXmlElement("logStatus", "lgst")]
        public OM2MLogStatus? LogStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("logStart", "lga")]
        public bool? LogStart
        {
            get;
            set;
        }
        [OM2MXmlElement("logStop", "lgo")]
        public bool? LogStop
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
