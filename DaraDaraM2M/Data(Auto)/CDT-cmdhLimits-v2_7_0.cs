using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("cmdhLimits","cml")]
    public partial class OM2MCmdhLimits : OM2MMgmtResource
    {
        [OM2MXmlElement("order", "od")]
        public int? Order
        {
            get;
            set;
        }
        [OM2MXmlElement("requestOrigin", "ror", typeof(OM2MListOfM2MIDDescription))]
        public List<string> RequestOrigin
        {
            get;
            set;
        }
        [OM2MXmlElement("requestContext", "rct")]
        public object RequestContext
        {
            get;
            set;
        }
        [OM2MXmlElement("requestContextNotification", "rctn")]
        public bool? RequestContextNotification
        {
            get;
            set;
        }
        [OM2MXmlElement("requestCharacteristics", "rch")]
        public object RequestCharacteristics
        {
            get;
            set;
        }
        [OM2MXmlElement("limitsEventCategory", "lec", typeof(OM2MListOfEventCatDescription))]
        public List<object> LimitsEventCategory
        {
            get;
            set;
        }
        [OM2MXmlElement("limitsRequestExpTime", "lqet", typeof(OM2MListOfMinMaxDescription))]
        public List<long> LimitsRequestExpTime
        {
            get;
            set;
        }
        [OM2MXmlElement("limitsResultExpTime", "lset", typeof(OM2MListOfMinMaxDescription))]
        public List<long> LimitsResultExpTime
        {
            get;
            set;
        }
        [OM2MXmlElement("limitsOpExecTime", "loet", typeof(OM2MListOfMinMaxDescription))]
        public List<long> LimitsOpExecTime
        {
            get;
            set;
        }
        [OM2MXmlElement("limitsRespPersistence", "lrp", typeof(OM2MListOfMinMaxDescription))]
        public List<long> LimitsRespPersistence
        {
            get;
            set;
        }
        [OM2MXmlElement("limitsDelAggregation", "lda", typeof(OM2MLimitsDelAggregationDescription))]
        public string LimitsDelAggregation
        {
            get;
            set;
        }
        [OM2MXsdSimpleType(null, typeof(string))]
        public class OM2MLimitsDelAggregationDescription : OM2MXsdSimpleTypeDescription
        {
        }
    }
}
