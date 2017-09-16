using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("statsCollect","stcl")]
    public partial class OM2MStatsCollect : OM2MRegularResource
    {
        [OM2MXmlElement("creator", "cr", typeof(OM2MIDDescription))]
        public string Creator
        {
            get;
            set;
        }
        [OM2MXmlElement("statsCollectID", "sci")]
        public string StatsCollectID
        {
            get;
            set;
        }
        [OM2MXmlElement("collectingEntityID", "cei", typeof(OM2MIDDescription))]
        public string CollectingEntityID
        {
            get;
            set;
        }
        [OM2MXmlElement("collectedEntityID", "cdi", typeof(OM2MIDDescription))]
        public string CollectedEntityID
        {
            get;
            set;
        }
        [OM2MXmlElement("statsRuleStatus", "srs")]
        public OM2MStatsRuleStatusType? StatsRuleStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("statModel", "sm")]
        public OM2MStatModelType? StatModel
        {
            get;
            set;
        }
        [OM2MXmlElement("collectPeriod", "cp")]
        public OM2MScheduleEntries CollectPeriod
        {
            get;
            set;
        }
        [OM2MXmlElement("eventID", "evi")]
        public string EventID
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
