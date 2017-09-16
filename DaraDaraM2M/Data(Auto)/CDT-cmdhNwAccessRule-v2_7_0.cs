using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("cmdhNwAccessRule","cmwr")]
    public partial class OM2MCmdhNwAccessRule : OM2MMgmtResource
    {
        [OM2MXmlElement("targetNetwork", "ttn", typeof(OM2MListOfM2MIDDescription))]
        public List<string> TargetNetwork
        {
            get;
            set;
        }
        [OM2MXmlElement("minReqVolume")]
        public int? MinReqVolume
        {
            get;
            set;
        }
        [OM2MXmlElement("spreadingWaitTime")]
        public int? SpreadingWaitTime
        {
            get;
            set;
        }
        [OM2MXmlElement("backOffParameters")]
        public OM2MBackOffParameters BackOffParameters
        {
            get;
            set;
        }
        [OM2MXmlElement("otherConditions")]
        public object OtherConditions
        {
            get;
            set;
        }
        [OM2MXmlElement("mgmtLink", "cmlk")]
        public OM2MMgmtLinkRef MgmtLink
        {
            get;
            set;
        }
    }
}
