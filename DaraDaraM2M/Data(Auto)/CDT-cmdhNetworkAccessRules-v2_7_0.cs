using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("cmdhNetworkAccessRules","cmnr")]
    public partial class OM2MCmdhNetworkAccessRules : OM2MMgmtResource
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MMgmtLinkRef))]
        public class OM2MCmdhNetworkAccessRules_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("applicableEventCategories", "aecs", typeof(OM2MListOfEventCatWithDefDescription))]
        public List<object> ApplicableEventCategories
        {
            get;
            set;
        }
        [OM2MXmlElement("mgmtLink", "cmlk", typeof(OM2MCmdhNetworkAccessRules_Property0Description))]
        public List<OM2MMgmtLinkRef> MgmtLink
        {
            get;
            set;
        }
    }
}
