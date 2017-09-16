using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("dynamicAuthorizationConsultation","dac")]
    public partial class OM2MDynamicAuthorizationConsultation : OM2MRegularResource
    {
        [OM2MXmlElement("dynamicAuthorizationEnabled")]
        public bool? DynamicAuthorizationEnabled
        {
            get;
            set;
        }
        [OM2MXmlElement("dynamicAuthorizationPoA", typeof(OM2MListOfURIsDescription))]
        public List<string> DynamicAuthorizationPoA
        {
            get;
            set;
        }
        [OM2MXmlElement("dynamicAuthorizationLifetime", typeof(OM2MTimestampDescription))]
        public string DynamicAuthorizationLifetime
        {
            get;
            set;
        }
    }
}
