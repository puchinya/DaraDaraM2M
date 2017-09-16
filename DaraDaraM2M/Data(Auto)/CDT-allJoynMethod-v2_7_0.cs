using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("allJoynMethod","ajmd")]
    public partial class OM2MAllJoynMethod : OM2MFlexContainerResource
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
        [OM2MXmlElement("subscription", "sub", typeof(OM2MSubscription))]
        public List<OM2MSubscription> Subscription
        {
            get;
            set;
        }
        [OM2MXmlElement("allJoynMethodCall", "ajmc", typeof(OM2MAllJoynMethodCall))]
        public List<OM2MAllJoynMethodCall> AllJoynMethodCall
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("allJoynMethodAnnc","ajmda")]
    public partial class OM2MAllJoynMethodAnnc : OM2MAnnouncedFlexContainerResource
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
        [OM2MXmlElement("allJoynMethodCall", "ajmc", typeof(OM2MAllJoynMethodCall))]
        public List<OM2MAllJoynMethodCall> AllJoynMethodCall
        {
            get;
            set;
        }
        [OM2MXmlElement("allJoynMethodCallAnnc", "ajmca", typeof(OM2MAllJoynMethodCallAnnc))]
        public List<OM2MAllJoynMethodCallAnnc> AllJoynMethodCallAnnc
        {
            get;
            set;
        }
    }
}
