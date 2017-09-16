using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("cmdhDefEcValue","cmdv")]
    public partial class OM2MCmdhDefEcValue : OM2MMgmtResource
    {
        [OM2MXmlElement("order", "od")]
        public int? Order
        {
            get;
            set;
        }
        [OM2MXmlElement("defEcValue", "dev", typeof(OM2MEventCatDescription))]
        public object DefEcValue
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
    }
}
