using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("allJoynInterface","ajif")]
    public partial class OM2MAllJoynInterface : OM2MFlexContainerResource
    {
        [OM2MXmlElement("interfaceIntrospectXmlRef")]
        public string InterfaceIntrospectXmlRef
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
        [OM2MXmlElement("allJoynMethod", "ajmd", typeof(OM2MAllJoynMethod))]
        public List<OM2MAllJoynMethod> AllJoynMethod
        {
            get;
            set;
        }
        [OM2MXmlElement("allJoynProperty", "ajpr", typeof(OM2MAllJoynProperty))]
        public List<OM2MAllJoynProperty> AllJoynProperty
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
    }
    [OM2MXmlRoot("allJoynInterfaceAnnc","ajifa")]
    public partial class OM2MAllJoynInterfaceAnnc : OM2MAnnouncedFlexContainerResource
    {
        [OM2MXmlElement("interfaceIntrospectXmlRef")]
        public string InterfaceIntrospectXmlRef
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
        [OM2MXmlElement("allJoynMethod", "ajmd", typeof(OM2MAllJoynMethod))]
        public List<OM2MAllJoynMethod> AllJoynMethod
        {
            get;
            set;
        }
        [OM2MXmlElement("allJoynMethodAnnc", "ajmda", typeof(OM2MAllJoynMethodAnnc))]
        public List<OM2MAllJoynMethodAnnc> AllJoynMethodAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("allJoynProperty", "ajpr", typeof(OM2MAllJoynProperty))]
        public List<OM2MAllJoynProperty> AllJoynProperty
        {
            get;
            set;
        }
        [OM2MXmlElement("allJoynPropertyAnnc", "ajpra", typeof(OM2MAllJoynPropertyAnnc))]
        public List<OM2MAllJoynPropertyAnnc> AllJoynPropertyAnnc
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
    }
}
