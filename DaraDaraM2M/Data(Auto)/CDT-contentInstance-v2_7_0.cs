using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("contentInstance","cin")]
    public partial class OM2MContentInstance : OM2MAnnounceableSubordinateResource
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
        [OM2MXmlElement("contentInfo", "cnf", typeof(OM2MContentInfoDescription))]
        public string ContentInfo
        {
            get;
            set;
        }
        [OM2MXmlElement("contentSize", "cs")]
        public int? ContentSize
        {
            get;
            set;
        }
        [OM2MXmlElement("contentRef", "conr")]
        public OM2MContentRef ContentRef
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
        [OM2MXmlElement("content", "con")]
        public object Content
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
    }
    [OM2MXmlRoot("contentInstanceAnnc","cinA")]
    public partial class OM2MContentInstanceAnnc : OM2MAnnouncedSubordinateResource
    {
        [OM2MXmlElement("stateTag", "st")]
        public int? StateTag
        {
            get;
            set;
        }
        [OM2MXmlElement("contentInfo", "cnf", typeof(OM2MContentInfoDescription))]
        public string ContentInfo
        {
            get;
            set;
        }
        [OM2MXmlElement("contentSize", "cs")]
        public int? ContentSize
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
        [OM2MXmlElement("content", "con")]
        public object Content
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
    }
}
