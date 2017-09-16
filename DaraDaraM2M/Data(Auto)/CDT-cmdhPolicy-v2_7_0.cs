using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("cmdhPolicy","cmp")]
    public partial class OM2MCmdhPolicy : OM2MMgmtResource
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MMgmtLinkRef))]
        public class OM2MCmdhPolicy_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("cmdhPolicyName", "cpn")]
        public string CmdhPolicyName
        {
            get;
            set;
        }
        [OM2MXmlElement("mgmtLink", "cmlk", typeof(OM2MCmdhPolicy_Property0Description))]
        public List<OM2MMgmtLinkRef> MgmtLink
        {
            get;
            set;
        }
    }
}
