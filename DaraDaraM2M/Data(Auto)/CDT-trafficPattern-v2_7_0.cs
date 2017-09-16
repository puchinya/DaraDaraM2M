using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("trafficPattern","trpt")]
    public partial class OM2MTrafficPattern : OM2MAnnounceableResource
    {
        [OM2MXmlElement("provideToNSE")]
        public bool? ProvideToNSE
        {
            get;
            set;
        }
        [OM2MXmlElement("periodicIndicator")]
        public OM2MPeriodicIndicator? PeriodicIndicator
        {
            get;
            set;
        }
        [OM2MXmlElement("periodicDurationTime")]
        public uint? PeriodicDurationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("periodicIntervalTime")]
        public uint? PeriodicIntervalTime
        {
            get;
            set;
        }
        [OM2MXmlElement("stationaryIndication")]
        public OM2MStationaryIndication? StationaryIndication
        {
            get;
            set;
        }
        [OM2MXmlElement("dataSizeIndicator")]
        public int? DataSizeIndicator
        {
            get;
            set;
        }
        [OM2MXmlElement("validityTime", typeof(OM2MTimestampDescription))]
        public string ValidityTime
        {
            get;
            set;
        }
        [OM2MXmlElement("targetNetwork", "ttn", typeof(OM2MListOfM2MIDDescription))]
        public List<string> TargetNetwork
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
        [OM2MXmlElement("schedule", "sch", typeof(OM2MSchedule))]
        public List<OM2MSchedule> Schedule
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("trafficPatternAnnc","trptA")]
    public partial class OM2MTrafficPatternAnnc : OM2MAnnouncedResource
    {
        [OM2MXmlElement("provideToNSE")]
        public bool? ProvideToNSE
        {
            get;
            set;
        }
        [OM2MXmlElement("periodicIndicator")]
        public OM2MPeriodicIndicator? PeriodicIndicator
        {
            get;
            set;
        }
        [OM2MXmlElement("periodicDurationTime")]
        public uint? PeriodicDurationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("periodicIntervalTime")]
        public uint? PeriodicIntervalTime
        {
            get;
            set;
        }
        [OM2MXmlElement("stationaryIndication")]
        public OM2MStationaryIndication? StationaryIndication
        {
            get;
            set;
        }
        [OM2MXmlElement("dataSizeIndicator")]
        public int? DataSizeIndicator
        {
            get;
            set;
        }
        [OM2MXmlElement("validityTime", typeof(OM2MTimestampDescription))]
        public string ValidityTime
        {
            get;
            set;
        }
        [OM2MXmlElement("targetNetwork", "ttn", typeof(OM2MListOfM2MIDDescription))]
        public List<string> TargetNetwork
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
        [OM2MXmlElement("scheduleAnnc", "schA", typeof(OM2MScheduleAnnc))]
        public List<OM2MScheduleAnnc> ScheduleAnnc
        {
            get;
            set;
        }
    }
}
