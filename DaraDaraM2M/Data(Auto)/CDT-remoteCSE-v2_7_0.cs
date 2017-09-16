using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("remoteCSE","csr")]
    public partial class OM2MRemoteCSE : OM2MAnnounceableResource
    {
        [OM2MXmlElement("cseType", "cst")]
        public OM2MCseTypeID? CseType
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
        [OM2MXmlElement("CSEBase", "cb")]
        public string CSEBase
        {
            get;
            set;
        }
        [OM2MXmlElement("CSE-ID", "csi", typeof(OM2MIDDescription))]
        public string CSEID
        {
            get;
            set;
        }
        [OM2MXmlElement("M2M-Ext-ID", "mei", typeof(OM2MExternalIDDescription))]
        public string M2MExtID
        {
            get;
            set;
        }
        [OM2MXmlElement("Trigger-Recipient-ID", "tri", typeof(OM2MTriggerRecipientIDDescription))]
        public uint? TriggerRecipientID
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
        [OM2MXmlElement("nodeLink", "nl")]
        public string NodeLink
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
        [OM2MXmlElement("triggerReferenceNumber", "trn")]
        public uint? TriggerReferenceNumber
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
        [OM2MXmlElement("nodeAnnc", "nodA", typeof(OM2MNodeAnnc))]
        public List<OM2MNodeAnnc> NodeAnnc
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
        [OM2MXmlElement("locationPolicyAnnc", "lcpA", typeof(OM2MLocationPolicyAnnc))]
        public List<OM2MLocationPolicyAnnc> LocationPolicyAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("AEAnnc", "aeA", typeof(OM2MAEAnnc))]
        public List<OM2MAEAnnc> AEAnnc
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
    [OM2MXmlRoot("remoteCSEAnnc","csrA")]
    public partial class OM2MRemoteCSEAnnc : OM2MAnnouncedResource
    {
        [OM2MXmlElement("cseType", "cst")]
        public OM2MCseTypeID? CseType
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
        [OM2MXmlElement("CSEBase", "cb")]
        public string CSEBase
        {
            get;
            set;
        }
        [OM2MXmlElement("CSE-ID", "csi", typeof(OM2MIDDescription))]
        public string CSEID
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
        [OM2MXmlElement("nodeLink", "nl")]
        public string NodeLink
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
        [OM2MXmlElement("nodeAnnc", "nodA", typeof(OM2MNodeAnnc))]
        public List<OM2MNodeAnnc> NodeAnnc
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
        [OM2MXmlElement("pollingChannel", "pch", typeof(OM2MPollingChannel))]
        public List<OM2MPollingChannel> PollingChannel
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
        [OM2MXmlElement("locationPolicyAnnc", "lcpA", typeof(OM2MLocationPolicyAnnc))]
        public List<OM2MLocationPolicyAnnc> LocationPolicyAnnc
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
        [OM2MXmlElement("AEAnnc", "aeA", typeof(OM2MAEAnnc))]
        public List<OM2MAEAnnc> AEAnnc
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
