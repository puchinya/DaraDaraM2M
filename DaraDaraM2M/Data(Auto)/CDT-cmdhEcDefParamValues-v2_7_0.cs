using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("cmdhEcDefParamValues","cmpv")]
    public partial class OM2MCmdhEcDefParamValues : OM2MMgmtResource
    {
        [OM2MXmlElement("applicableEventCategory", "aec", typeof(OM2MListOfEventCatWithDefDescription))]
        public List<object> ApplicableEventCategory
        {
            get;
            set;
        }
        [OM2MXmlElement("defaultRequestExpTime", "dqet")]
        public long? DefaultRequestExpTime
        {
            get;
            set;
        }
        [OM2MXmlElement("defaultResultExpTime", "dset")]
        public long? DefaultResultExpTime
        {
            get;
            set;
        }
        [OM2MXmlElement("defaultOpExecTime", "doet")]
        public long? DefaultOpExecTime
        {
            get;
            set;
        }
        [OM2MXmlElement("defaultRespPersistence", "drp")]
        public long? DefaultRespPersistence
        {
            get;
            set;
        }
        [OM2MXmlElement("defaultDelAggregation", "dda")]
        public bool? DefaultDelAggregation
        {
            get;
            set;
        }
    }
}
