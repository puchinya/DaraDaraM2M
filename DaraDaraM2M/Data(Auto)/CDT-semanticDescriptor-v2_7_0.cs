using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("semanticDescriptor","smd")]
    public partial class OM2MSemanticDescriptor : OM2MAnnounceableResource
    {
        [OM2MXmlElement("creator", "cr", typeof(OM2MIDDescription))]
        public string Creator
        {
            get;
            set;
        }
        [OM2MXmlElement("descriptorRepresentation", typeof(OM2MDescriptorRepresentationDescription))]
        public string DescriptorRepresentation
        {
            get;
            set;
        }
        [OM2MXmlElement("semanticOpExec", typeof(OM2MSparqlDescription))]
        public string SemanticOpExec
        {
            get;
            set;
        }
        [OM2MXmlElement("descriptor")]
        public object Descriptor
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
        [OM2MXmlElement("relatedSemantics", typeof(OM2MListOfURIsDescription))]
        public List<string> RelatedSemantics
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
    }
    [OM2MXmlRoot("semanticDescriptorAnnc","smdA")]
    public partial class OM2MSemanticDescriptorAnnc : OM2MAnnouncedResource
    {
        [OM2MXmlElement("descriptorRepresentation", typeof(OM2MDescriptorRepresentationDescription))]
        public string DescriptorRepresentation
        {
            get;
            set;
        }
        [OM2MXmlElement("semanticOpExec", typeof(OM2MSparqlDescription))]
        public string SemanticOpExec
        {
            get;
            set;
        }
        [OM2MXmlElement("descriptor")]
        public object Descriptor
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
        [OM2MXmlElement("relatedSemantics", typeof(OM2MListOfURIsDescription))]
        public List<string> RelatedSemantics
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
    }
}
