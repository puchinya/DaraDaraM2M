using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("svcObjWrapper","ajsw")]
    public partial class OM2MSvcObjWrapper : OM2MFlexContainerResource
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
        [OM2MXmlElement("allJoynApp", "ajap", typeof(OM2MAllJoynApp))]
        public List<OM2MAllJoynApp> AllJoynApp
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("svcObjWrapperAnnc","ajswa")]
    public partial class OM2MSvcObjWrapperAnnc : OM2MAnnouncedFlexContainerResource
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
        [OM2MXmlElement("allJoynAppAnnc", "ajapa", typeof(OM2MAllJoynAppAnnc))]
        public List<OM2MAllJoynAppAnnc> AllJoynAppAnnc
        {
            get;
            set;
        }
    }
}
