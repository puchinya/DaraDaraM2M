using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("activeCmdhPolicy","acmp")]
    public partial class OM2MActiveCmdhPolicy : OM2MMgmtResource
    {
        [OM2MXmlElement("activeCmdhPolicyLink", "acmlk", typeof(OM2MIDDescription))]
        public string ActiveCmdhPolicyLink
        {
            get;
            set;
        }
    }
}
