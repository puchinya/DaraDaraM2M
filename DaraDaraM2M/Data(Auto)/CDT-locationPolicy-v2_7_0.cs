using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("locationPolicy","lcp")]
    public partial class OM2MLocationPolicy : OM2MAnnounceableResource
    {
        [OM2MXmlElement("locationSource", "los")]
        public OM2MLocationSource? LocationSource
        {
            get;
            set;
        }
        [OM2MXmlElement("locationUpdatePeriod", "lou", typeof(OM2MListOfDurationDescription))]
        public List<DateTime> LocationUpdatePeriod
        {
            get;
            set;
        }
        [OM2MXmlElement("locationTargetID", "lot", typeof(OM2MNodeIDDescription))]
        public string LocationTargetID
        {
            get;
            set;
        }
        [OM2MXmlElement("locationServer", "lor")]
        public string LocationServer
        {
            get;
            set;
        }
        [OM2MXmlElement("locationContainerID", "loi")]
        public string LocationContainerID
        {
            get;
            set;
        }
        [OM2MXmlElement("locationContainerName", "lon")]
        public string LocationContainerName
        {
            get;
            set;
        }
        [OM2MXmlElement("locationStatus", "lost")]
        public string LocationStatus
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
    [OM2MXmlRoot("locationPolicyAnnc","lcpA")]
    public partial class OM2MLocationPolicyAnnc : OM2MAnnouncedResource
    {
        [OM2MXmlElement("locationSource", "los")]
        public OM2MLocationSource? LocationSource
        {
            get;
            set;
        }
        [OM2MXmlElement("locationUpdatePeriod", "lou", typeof(OM2MListOfDurationDescription))]
        public List<DateTime> LocationUpdatePeriod
        {
            get;
            set;
        }
        [OM2MXmlElement("locationTargetID", "lot", typeof(OM2MNodeIDDescription))]
        public string LocationTargetID
        {
            get;
            set;
        }
        [OM2MXmlElement("locationServer", "lor")]
        public string LocationServer
        {
            get;
            set;
        }
        [OM2MXmlElement("locationContainerID", "loi")]
        public string LocationContainerID
        {
            get;
            set;
        }
        [OM2MXmlElement("locationContainerName", "lon")]
        public string LocationContainerName
        {
            get;
            set;
        }
        [OM2MXmlElement("locationStatus", "lost")]
        public string LocationStatus
        {
            get;
            set;
        }
    }
}
