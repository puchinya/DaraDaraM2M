using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("cmdhDefaults","cmdf")]
    public partial class OM2MCmdhDefaults : OM2MMgmtResource
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MMgmtLinkRef))]
        public class OM2MCmdhDefaults_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("mgmtLink", "cmlk", typeof(OM2MCmdhDefaults_Property0Description))]
        public List<OM2MMgmtLinkRef> MgmtLink
        {
            get;
            set;
        }
    }
}
