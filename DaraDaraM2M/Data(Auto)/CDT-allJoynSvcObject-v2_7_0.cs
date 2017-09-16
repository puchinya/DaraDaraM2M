using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("allJoynSvcObject","ajso")]
    public partial class OM2MAllJoynSvcObject : OM2MFlexContainerResource
    {
        [OM2MXmlElement("objectPath")]
        public string ObjectPath
        {
            get;
            set;
        }
        [OM2MXmlElement("enable", "ena")]
        public bool? Enable
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
        [OM2MXmlElement("allJoynInterface", "ajif", typeof(OM2MAllJoynInterface))]
        public List<OM2MAllJoynInterface> AllJoynInterface
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("allJoynSvcObjectAnnc","ajsoa")]
    public partial class OM2MAllJoynSvcObjectAnnc : OM2MAnnouncedFlexContainerResource
    {
        [OM2MXmlElement("objectPath")]
        public string ObjectPath
        {
            get;
            set;
        }
        [OM2MXmlElement("enable", "ena")]
        public bool? Enable
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
        [OM2MXmlElement("allJoynInterface", "ajif", typeof(OM2MAllJoynInterface))]
        public List<OM2MAllJoynInterface> AllJoynInterface
        {
            get;
            set;
        }
        [OM2MXmlElement("allJoynInterfaceAnnc", "ajifa", typeof(OM2MAllJoynInterfaceAnnc))]
        public List<OM2MAllJoynInterfaceAnnc> AllJoynInterfaceAnnc
        {
            get;
            set;
        }
    }
}
