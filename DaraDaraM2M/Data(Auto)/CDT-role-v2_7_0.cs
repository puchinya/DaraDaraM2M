using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("role","rol")]
    public partial class OM2MRole : OM2MRegularResource
    {
        [OM2MXmlElement("roleID", typeof(OM2MRoleIDDescription))]
        public string RoleID
        {
            get;
            set;
        }
        [OM2MXmlElement("issuer", typeof(OM2MIDDescription))]
        public string Issuer
        {
            get;
            set;
        }
        [OM2MXmlElement("holder", typeof(OM2MIDDescription))]
        public string Holder
        {
            get;
            set;
        }
        [OM2MXmlElement("notBefore", typeof(OM2MTimestampDescription))]
        public string NotBefore
        {
            get;
            set;
        }
        [OM2MXmlElement("notAfter", typeof(OM2MTimestampDescription))]
        public string NotAfter
        {
            get;
            set;
        }
        [OM2MXmlElement("roleName")]
        public string RoleName
        {
            get;
            set;
        }
        [OM2MXmlElement("tokenLink")]
        public string TokenLink
        {
            get;
            set;
        }
        [OM2MXmlElement("childResource", typeof(OM2MChildResourceRef))]
        public List<OM2MChildResourceRef> ChildResource
        {
            get;
            set;
        }
        [OM2MXmlElement("subscription", "sub", typeof(OM2MSubscription))]
        public List<OM2MSubscription> Subscription
        {
            get;
            set;
        }
    }
}
