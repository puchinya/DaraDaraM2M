using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("timeSeries","ts")]
    public partial class OM2MTimeSeries : OM2MAnnounceableResource
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
        [OM2MXmlElement("periodicInterval")]
        public int? PeriodicInterval
        {
            get;
            set;
        }
        [OM2MXmlElement("missingDataDetect")]
        public bool? MissingDataDetect
        {
            get;
            set;
        }
        [OM2MXmlElement("missingDataMaxNr")]
        public int? MissingDataMaxNr
        {
            get;
            set;
        }
        [OM2MXmlElement("missingDataList", typeof(OM2MMissingDataListDescription))]
        public object MissingDataList
        {
            get;
            set;
        }
        [OM2MXmlElement("missingDataCurrentNr")]
        public int? MissingDataCurrentNr
        {
            get;
            set;
        }
        [OM2MXmlElement("missingDataDetectTimer")]
        public int? MissingDataDetectTimer
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
        [OM2MXmlElement("latest", "la")]
        public string Latest
        {
            get;
            set;
        }
        [OM2MXmlElement("oldest", "ol")]
        public string Oldest
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
        [OM2MXmlElement("timeSeriesInstance", "tsi", typeof(OM2MTimeSeriesInstance))]
        public List<OM2MTimeSeriesInstance> TimeSeriesInstance
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
    }
    [OM2MXmlRoot("timeSeriesAnnc","tsa ")]
    public partial class OM2MTimeSeriesAnnc : OM2MAnnouncedResource
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
        [OM2MXmlElement("periodicInterval")]
        public int? PeriodicInterval
        {
            get;
            set;
        }
        [OM2MXmlElement("missingDataDetect")]
        public bool? MissingDataDetect
        {
            get;
            set;
        }
        [OM2MXmlElement("missingDataList", typeof(OM2MMissingDataListDescription))]
        public object MissingDataList
        {
            get;
            set;
        }
        [OM2MXmlElement("missingDataCurrentNr")]
        public int? MissingDataCurrentNr
        {
            get;
            set;
        }
        [OM2MXmlElement("missingDataDetectTimer")]
        public int? MissingDataDetectTimer
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
        [OM2MXmlElement("childResource", typeof(OM2MChildResourceRef))]
        public List<OM2MChildResourceRef> ChildResource
        {
            get;
            set;
        }
        [OM2MXmlElement("timeSeriesInstance", "tsi", typeof(OM2MTimeSeriesInstance))]
        public List<OM2MTimeSeriesInstance> TimeSeriesInstance
        {
            get;
            set;
        }
        [OM2MXmlElement("timeSeriesInstanceAnnc", "tsia", typeof(OM2MTimeSeriesInstanceAnnc))]
        public List<OM2MTimeSeriesInstanceAnnc> TimeSeriesInstanceAnnc
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
    }
}
