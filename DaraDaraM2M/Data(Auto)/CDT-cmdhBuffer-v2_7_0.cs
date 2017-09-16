using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("cmdhBuffer","cmbf")]
    public partial class OM2MCmdhBuffer : OM2MMgmtResource
    {
        [OM2MXmlElement("applicableEventCategory", "aec", typeof(OM2MListOfEventCatWithDefDescription))]
        public List<object> ApplicableEventCategory
        {
            get;
            set;
        }
        [OM2MXmlElement("maxBufferSize")]
        public int? MaxBufferSize
        {
            get;
            set;
        }
        [OM2MXmlElement("storagePriority", typeof(OM2MStoragePriorityDescription))]
        public int? StoragePriority
        {
            get;
            set;
        }
        [OM2MXsdSimpleType(null, typeof(int))]
        public class OM2MStoragePriorityDescription : OM2MXsdSimpleTypeDescription
        {
        }
    }
}
