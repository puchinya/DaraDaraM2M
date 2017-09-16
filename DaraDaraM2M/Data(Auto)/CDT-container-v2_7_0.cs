using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("container","cnt")]
    public partial class OM2MContainer : OM2MAnnounceableResource
    {
        [OM2MXmlElement("stateTag", "st")]
        public int? StateTag
        {
            get;
            set;
        }
        [OM2MXmlElement("creator", "cr", typeof(OM2MIDDescription))]
        public string Creator
        {
            get;
            set;
        }
        [OM2MXmlElement("maxNrOfInstances", "mni")]
        public int? MaxNrOfInstances
        {
            get;
            set;
        }
        [OM2MXmlElement("maxByteSize", "mbs")]
        public int? MaxByteSize
        {
            get;
            set;
        }
        [OM2MXmlElement("maxInstanceAge", "mia")]
        public int? MaxInstanceAge
        {
            get;
            set;
        }
        [OM2MXmlElement("currentNrOfInstances", "cni")]
        public int? CurrentNrOfInstances
        {
            get;
            set;
        }
        [OM2MXmlElement("currentByteSize", "cbs")]
        public int? CurrentByteSize
        {
            get;
            set;
        }
        [OM2MXmlElement("locationID", "li")]
        public string LocationID
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
        [OM2MXmlElement("disableRetrieval", "disr")]
        public bool? DisableRetrieval
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
        [OM2MXmlElement("contentInstance", "cin", typeof(OM2MContentInstance))]
        public List<OM2MContentInstance> ContentInstance
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
        [OM2MXmlElement("subscription", "sub", typeof(OM2MSubscription))]
        public List<OM2MSubscription> Subscription
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
        [OM2MXmlElement("sg_flexContainerResource", typeof(OM2MFlexContainerResource))]
        public List<OM2MFlexContainerResource> Sg_flexContainerResource
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("containerAnnc","cntA")]
    public partial class OM2MContainerAnnc : OM2MAnnouncedResource
    {
        [OM2MXmlElement("stateTag", "st")]
        public int? StateTag
        {
            get;
            set;
        }
        [OM2MXmlElement("maxNrOfInstances", "mni")]
        public int? MaxNrOfInstances
        {
            get;
            set;
        }
        [OM2MXmlElement("maxByteSize", "mbs")]
        public int? MaxByteSize
        {
            get;
            set;
        }
        [OM2MXmlElement("maxInstanceAge", "mia")]
        public int? MaxInstanceAge
        {
            get;
            set;
        }
        [OM2MXmlElement("currentNrOfInstances", "cni")]
        public int? CurrentNrOfInstances
        {
            get;
            set;
        }
        [OM2MXmlElement("currentByteSize", "cbs")]
        public int? CurrentByteSize
        {
            get;
            set;
        }
        [OM2MXmlElement("locationID", "li")]
        public string LocationID
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
        [OM2MXmlElement("disableRetrieval", "disr")]
        public bool? DisableRetrieval
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
        [OM2MXmlElement("contentInstance", "cin", typeof(OM2MContentInstance))]
        public List<OM2MContentInstance> ContentInstance
        {
            get;
            set;
        }
        [OM2MXmlElement("contentInstanceAnnc", "cinA", typeof(OM2MContentInstanceAnnc))]
        public List<OM2MContentInstanceAnnc> ContentInstanceAnnc
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
        [OM2MXmlElement("subscription", "sub", typeof(OM2MSubscription))]
        public List<OM2MSubscription> Subscription
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
