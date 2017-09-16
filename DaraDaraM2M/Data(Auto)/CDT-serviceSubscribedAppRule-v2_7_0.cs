using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("serviceSubscribedAppRule","asar")]
    public partial class OM2MServiceSubscribedAppRule : OM2MRegularResource
    {
        [OM2MXmlElement("applicableCredIDs", typeof(OM2MListOfM2MIDDescription))]
        public List<string> ApplicableCredIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("allowedApp-IDs", typeof(OM2MListOfM2MIDDescription))]
        public List<string> AllowedAppIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("allowedAEs", typeof(OM2MListOfM2MIDDescription))]
        public List<string> AllowedAEs
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
