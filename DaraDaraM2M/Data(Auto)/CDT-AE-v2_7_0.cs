using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("AE","ae")]
    public partial class OM2MAE : OM2MAnnounceableResource
    {
        [OM2MXmlElement("appName", "apn")]
        public string AppName
        {
            get;
            set;
        }
        [OM2MXmlElement("App-ID", "api")]
        public string AppID
        {
            get;
            set;
        }
        [OM2MXmlElement("AE-ID", "aei", typeof(OM2MIDDescription))]
        public string AEID
        {
            get;
            set;
        }
        [OM2MXmlElement("pointOfAccess", "poa", typeof(OM2MPoaListDescription))]
        public List<string> PointOfAccess
        {
            get;
            set;
        }
        [OM2MXmlElement("ontologyRef", "or")]
        public string OntologyRef
        {
            get;
            set;
        }
        [OM2MXmlElement("nodeLink", "nl")]
        public string NodeLink
        {
            get;
            set;
        }
        [OM2MXmlElement("requestReachability", "rr")]
        public bool? RequestReachability
        {
            get;
            set;
        }
        [OM2MXmlElement("contentSerialization", "csz", typeof(OM2MSerializationsDescription))]
        public List<string> ContentSerialization
        {
            get;
            set;
        }
        [OM2MXmlElement("e2eSecInfo")]
        public OM2ME2eSecInfo E2eSecInfo
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
        [OM2MXmlElement("container", "cnt", typeof(OM2MContainer))]
        public List<OM2MContainer> Container
        {
            get;
            set;
        }
        [OM2MXmlElement("group", "grp", typeof(OM2MGroup))]
        public List<OM2MGroup> Group
        {
            get;
            set;
        }
        [OM2MXmlElement("accessControlPolicy", "acp", typeof(OM2MAccessControlPolicy))]
        public List<OM2MAccessControlPolicy> AccessControlPolicy
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
        [OM2MXmlElement("pollingChannel", "pch", typeof(OM2MPollingChannel))]
        public List<OM2MPollingChannel> PollingChannel
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
        [OM2MXmlElement("semanticDescriptor", "smd", typeof(OM2MSemanticDescriptor))]
        public List<OM2MSemanticDescriptor> SemanticDescriptor
        {
            get;
            set;
        }
        [OM2MXmlElement("timeSeries", "ts", typeof(OM2MTimeSeries))]
        public List<OM2MTimeSeries> TimeSeries
        {
            get;
            set;
        }
        [OM2MXmlElement("trafficPattern", "trpt", typeof(OM2MTrafficPattern))]
        public List<OM2MTrafficPattern> TrafficPattern
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_flexContainerResource", typeof(OM2MFlexContainerResource))]
        public List<OM2MFlexContainerResource> Sg_flexContainerResource
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("AEAnnc","aeA")]
    public partial class OM2MAEAnnc : OM2MAnnouncedResource
    {
        [OM2MXmlElement("appName", "apn")]
        public string AppName
        {
            get;
            set;
        }
        [OM2MXmlElement("App-ID", "api")]
        public string AppID
        {
            get;
            set;
        }
        [OM2MXmlElement("AE-ID", "aei", typeof(OM2MIDDescription))]
        public string AEID
        {
            get;
            set;
        }
        [OM2MXmlElement("pointOfAccess", "poa", typeof(OM2MPoaListDescription))]
        public List<string> PointOfAccess
        {
            get;
            set;
        }
        [OM2MXmlElement("ontologyRef", "or")]
        public string OntologyRef
        {
            get;
            set;
        }
        [OM2MXmlElement("nodeLink", "nl")]
        public string NodeLink
        {
            get;
            set;
        }
        [OM2MXmlElement("requestReachability", "rr")]
        public bool? RequestReachability
        {
            get;
            set;
        }
        [OM2MXmlElement("contentSerialization", "csz", typeof(OM2MSerializationsDescription))]
        public List<string> ContentSerialization
        {
            get;
            set;
        }
        [OM2MXmlElement("e2eSecInfo")]
        public OM2ME2eSecInfo E2eSecInfo
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
        [OM2MXmlElement("container", "cnt", typeof(OM2MContainer))]
        public List<OM2MContainer> Container
        {
            get;
            set;
        }
        [OM2MXmlElement("containerAnnc", "cntA", typeof(OM2MContainerAnnc))]
        public List<OM2MContainerAnnc> ContainerAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("group", "grp", typeof(OM2MGroup))]
        public List<OM2MGroup> Group
        {
            get;
            set;
        }
        [OM2MXmlElement("groupAnnc", "grpA", typeof(OM2MGroupAnnc))]
        public List<OM2MGroupAnnc> GroupAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("accessControlPolicy", "acp", typeof(OM2MAccessControlPolicy))]
        public List<OM2MAccessControlPolicy> AccessControlPolicy
        {
            get;
            set;
        }
        [OM2MXmlElement("accessControlPolicyAnnc", "acpA", typeof(OM2MAccessControlPolicyAnnc))]
        public List<OM2MAccessControlPolicyAnnc> AccessControlPolicyAnnc
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
        [OM2MXmlElement("semanticDescriptor", "smd", typeof(OM2MSemanticDescriptor))]
        public List<OM2MSemanticDescriptor> SemanticDescriptor
        {
            get;
            set;
        }
        [OM2MXmlElement("timeSeries", "ts", typeof(OM2MTimeSeries))]
        public List<OM2MTimeSeries> TimeSeries
        {
            get;
            set;
        }
        [OM2MXmlElement("timeSeriesAnnc", "tsa ", typeof(OM2MTimeSeriesAnnc))]
        public List<OM2MTimeSeriesAnnc> TimeSeriesAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("trafficPatternAnnc", "trptA", typeof(OM2MTrafficPatternAnnc))]
        public List<OM2MTrafficPatternAnnc> TrafficPatternAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_flexContainerResource", typeof(OM2MFlexContainerResource))]
        public List<OM2MFlexContainerResource> Sg_flexContainerResource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_announcedFlexContainerResource", typeof(OM2MAnnouncedFlexContainerResource))]
        public List<OM2MAnnouncedFlexContainerResource> Sg_announcedFlexContainerResource
        {
            get;
            set;
        }
    }
}
