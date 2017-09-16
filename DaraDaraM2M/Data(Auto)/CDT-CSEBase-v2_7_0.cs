using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("CSEBase","cb")]
    public partial class OM2MCSEBase : OM2MResource
    {
        [OM2MXmlElement("accessControlPolicyIDs", "acpi", typeof(OM2MAcpTypeDescription))]
        public List<string> AccessControlPolicyIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("cseType", "cst")]
        public OM2MCseTypeID? CseType
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
        [OM2MXmlElement("supportedResourceType", "srt", typeof(OM2MSupportedResourceTypeDescription))]
        public List<OM2MResourceType> SupportedResourceType
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
        [OM2MXmlElement("remoteCSE", "csr", typeof(OM2MRemoteCSE))]
        public List<OM2MRemoteCSE> RemoteCSE
        {
            get;
            set;
        }
        [OM2MXmlElement("remoteCSEAnnc", "csrA", typeof(OM2MRemoteCSEAnnc))]
        public List<OM2MRemoteCSEAnnc> RemoteCSEAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("node", "nod", typeof(OM2MNode))]
        public List<OM2MNode> Node
        {
            get;
            set;
        }
        [OM2MXmlElement("AE", "ae", typeof(OM2MAE))]
        public List<OM2MAE> AE
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
        [OM2MXmlElement("mgmtCmd", "mgc", typeof(OM2MMgmtCmd))]
        public List<OM2MMgmtCmd> MgmtCmd
        {
            get;
            set;
        }
        [OM2MXmlElement("locationPolicy", "lcp", typeof(OM2MLocationPolicy))]
        public List<OM2MLocationPolicy> LocationPolicy
        {
            get;
            set;
        }
        [OM2MXmlElement("statsConfig", "stcg", typeof(OM2MStatsConfig))]
        public List<OM2MStatsConfig> StatsConfig
        {
            get;
            set;
        }
        [OM2MXmlElement("statsCollect", "stcl", typeof(OM2MStatsCollect))]
        public List<OM2MStatsCollect> StatsCollect
        {
            get;
            set;
        }
        [OM2MXmlElement("request", "req", typeof(OM2MRequest))]
        public List<OM2MRequest> Request
        {
            get;
            set;
        }
        [OM2MXmlElement("delivery", "dlv", typeof(OM2MDelivery))]
        public List<OM2MDelivery> Delivery
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
        [OM2MXmlElement("m2mServiceSubscriptionProfile", "mssp", typeof(OM2MM2mServiceSubscriptionProfile))]
        public List<OM2MM2mServiceSubscriptionProfile> M2mServiceSubscriptionProfile
        {
            get;
            set;
        }
        [OM2MXmlElement("serviceSubscribedAppRule", "asar", typeof(OM2MServiceSubscribedAppRule))]
        public List<OM2MServiceSubscribedAppRule> ServiceSubscribedAppRule
        {
            get;
            set;
        }
        [OM2MXmlElement("role", "rol", typeof(OM2MRole))]
        public List<OM2MRole> Role
        {
            get;
            set;
        }
        [OM2MXmlElement("token", "tk", typeof(OM2MToken))]
        public List<OM2MToken> Token
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
        [OM2MXsdSimpleListType(null, typeof(OM2MResourceType))]
        public class OM2MSupportedResourceTypeDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
}
