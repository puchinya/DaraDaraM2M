using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("areaNwkInfo","ani")]
    public partial class OM2MAreaNwkInfo : OM2MMgmtResource
    {
        [OM2MXmlElement("areaNwkType", "ant")]
        public string AreaNwkType
        {
            get;
            set;
        }
        [OM2MXmlElement("listOfDevices", "ldv", typeof(OM2MListOfURIsDescription))]
        public List<string> ListOfDevices
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
    [OM2MXmlRoot("areaNwkInfoAnnc","aniA")]
    public partial class OM2MAreaNwkInfoAnnc : OM2MAnnouncedMgmtResource
    {
        [OM2MXmlElement("areaNwkType", "ant")]
        public string AreaNwkType
        {
            get;
            set;
        }
        [OM2MXmlElement("listOfDevices", "ldv", typeof(OM2MListOfURIsDescription))]
        public List<string> ListOfDevices
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
