using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("allJoynApp","ajap")]
    public partial class OM2MAllJoynApp : OM2MFlexContainerResource
    {
        [OM2MXmlElement("direction")]
        public OM2MAllJoynDirection? Direction
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
        [OM2MXmlElement("allJoynSvcObject", "ajso", typeof(OM2MAllJoynSvcObject))]
        public List<OM2MAllJoynSvcObject> AllJoynSvcObject
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("allJoynAppAnnc","ajapa")]
    public partial class OM2MAllJoynAppAnnc : OM2MAnnouncedFlexContainerResource
    {
        [OM2MXmlElement("direction")]
        public OM2MAllJoynDirection? Direction
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
        [OM2MXmlElement("allJoynSvcObject", "ajso", typeof(OM2MAllJoynSvcObject))]
        public List<OM2MAllJoynSvcObject> AllJoynSvcObject
        {
            get;
            set;
        }
        [OM2MXmlElement("allJoynSvcObjectAnnc", "ajsoa", typeof(OM2MAllJoynSvcObjectAnnc))]
        public List<OM2MAllJoynSvcObjectAnnc> AllJoynSvcObjectAnnc
        {
            get;
            set;
        }
    }
}
