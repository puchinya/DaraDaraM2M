using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("allJoynMethodCall","ajmc")]
    public partial class OM2MAllJoynMethodCall : OM2MFlexContainerResource
    {
        [OM2MXmlElement("input")]
        public string Input
        {
            get;
            set;
        }
        [OM2MXmlElement("callStatus")]
        public string CallStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("output")]
        public string Output
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
        [OM2MXmlElement("semanticDescriptor", "smd", typeof(OM2MSemanticDescriptor))]
        public List<OM2MSemanticDescriptor> SemanticDescriptor
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
    [OM2MXmlRoot("allJoynMethodCallAnnc","ajmca")]
    public partial class OM2MAllJoynMethodCallAnnc : OM2MAnnouncedFlexContainerResource
    {
        [OM2MXmlElement("childResource", typeof(OM2MChildResourceRef))]
        public List<OM2MChildResourceRef> ChildResource
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
        [OM2MXmlElement("semanticDescriptorAnnc", "smdA", typeof(OM2MSemanticDescriptorAnnc))]
        public List<OM2MSemanticDescriptorAnnc> SemanticDescriptorAnnc
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
