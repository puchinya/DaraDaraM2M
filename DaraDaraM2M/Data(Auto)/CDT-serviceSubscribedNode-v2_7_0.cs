using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("serviceSubscribedNode","svsn")]
    public partial class OM2MServiceSubscribedNode : OM2MRegularResource
    {
        [OM2MXmlElement("nodeID", "ni", typeof(OM2MNodeIDDescription))]
        public string NodeID
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
        [OM2MXmlElement("deviceIdentifier", "di", typeof(OM2MDeviceIdentifierDescription))]
        public List<string> DeviceIdentifier
        {
            get;
            set;
        }
        [OM2MXmlElement("ruleLinks", "rlk", typeof(OM2MListOfURIsDescription))]
        public List<string> RuleLinks
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
        [OM2MXsdSimpleListType(null, typeof(OM2MDeviceIDDescription))]
        public class OM2MDeviceIdentifierDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
}
