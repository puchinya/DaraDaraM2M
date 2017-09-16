using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("token","tk")]
    public partial class OM2MToken : OM2MRegularResource
    {
        [OM2MXmlElement("tokenID", typeof(OM2MTokenIDDescription))]
        public string TokenID
        {
            get;
            set;
        }
        [OM2MXmlElement("tokenObject", typeof(OM2MDynAuthJWTDescription))]
        public string TokenObject
        {
            get;
            set;
        }
        [OM2MXmlElement("version", "vr")]
        public string Version
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
        [OM2MXmlElement("tokenName")]
        public string TokenName
        {
            get;
            set;
        }
        [OM2MXmlElement("audience", typeof(OM2MListOfM2MIDDescription))]
        public List<string> Audience
        {
            get;
            set;
        }
        [OM2MXmlElement("permissions")]
        public OM2MPermissions Permissions
        {
            get;
            set;
        }
        [OM2MXmlElement("extension")]
        public string Extension
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
        public partial class OM2MPermissions
        {
            [OM2MXmlElement("permission")]
            public OM2MTokenPermission Permission
            {
                get;
                set;
            }
        }
    }
}
