using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("areaNwkDeviceInfo","andi")]
    public partial class OM2MAreaNwkDeviceInfo : OM2MMgmtResource
    {
        [OM2MXmlElement("devID")]
        public string DevID
        {
            get;
            set;
        }
        [OM2MXmlElement("devType", "dvt")]
        public string DevType
        {
            get;
            set;
        }
        [OM2MXmlElement("areaNwkId", "awi")]
        public string AreaNwkId
        {
            get;
            set;
        }
        [OM2MXmlElement("sleepInterval", "sli")]
        public int? SleepInterval
        {
            get;
            set;
        }
        [OM2MXmlElement("sleepDuration", "sld")]
        public int? SleepDuration
        {
            get;
            set;
        }
        [OM2MXmlElement("devStatus", "ss")]
        public string DevStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("listOfNeighbors", "lnh", typeof(OM2MListOfURIsDescription))]
        public List<string> ListOfNeighbors
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
    [OM2MXmlRoot("areaNwkDeviceInfoAnnc","andiA")]
    public partial class OM2MAreaNwkDeviceInfoAnnc : OM2MAnnouncedMgmtResource
    {
        [OM2MXmlElement("devID")]
        public string DevID
        {
            get;
            set;
        }
        [OM2MXmlElement("devType", "dvt")]
        public string DevType
        {
            get;
            set;
        }
        [OM2MXmlElement("areaNwkId", "awi")]
        public string AreaNwkId
        {
            get;
            set;
        }
        [OM2MXmlElement("sleepInterval", "sli")]
        public int? SleepInterval
        {
            get;
            set;
        }
        [OM2MXmlElement("sleepDuration", "sld")]
        public int? SleepDuration
        {
            get;
            set;
        }
        [OM2MXmlElement("devStatus", "ss")]
        public string DevStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("listOfNeighbors", "lnh", typeof(OM2MListOfURIsDescription))]
        public List<string> ListOfNeighbors
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
