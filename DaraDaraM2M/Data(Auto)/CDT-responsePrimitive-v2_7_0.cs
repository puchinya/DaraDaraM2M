using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("resourceWrapper")]
    public partial class OM2MResourceWrapper
    {
        [OM2MXmlElement("URI")]
        public string URI
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_resource", typeof(OM2MResource))]
        public List<OM2MResource> Sg_resource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_regularResource", typeof(OM2MRegularResource))]
        public List<OM2MRegularResource> Sg_regularResource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_announcedResource", typeof(OM2MAnnouncedResource))]
        public List<OM2MAnnouncedResource> Sg_announcedResource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_announceableResource", typeof(OM2MAnnounceableResource))]
        public List<OM2MAnnounceableResource> Sg_announceableResource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_subordinateResource", typeof(OM2MSubordinateResource))]
        public List<OM2MSubordinateResource> Sg_subordinateResource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_announcedSubordinateResource", typeof(OM2MAnnouncedSubordinateResource))]
        public List<OM2MAnnouncedSubordinateResource> Sg_announcedSubordinateResource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_announceableSubordinateResource", typeof(OM2MAnnounceableSubordinateResource))]
        public List<OM2MAnnounceableSubordinateResource> Sg_announceableSubordinateResource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_mgmtResource", typeof(OM2MMgmtResource))]
        public List<OM2MMgmtResource> Sg_mgmtResource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_announcedMgmtResource", typeof(OM2MAnnouncedMgmtResource))]
        public List<OM2MAnnouncedMgmtResource> Sg_announcedMgmtResource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_flexContainerResource", typeof(OM2MFlexContainerResource))]
        public List<OM2MFlexContainerResource> Sg_flexContainerResource
        {
            get;
            set;
        }
        [OM2MXmlElement("sg_announcedFlexContainerResource", typeof(OM2MAnnouncedFlexContainerResource))]
        public List<OM2MAnnouncedFlexContainerResource> Sg_announcedFlexContainerResource
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("aggregatedResponse")]
    public partial class OM2MAggregatedResponse
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MResponsePrimitive))]
        public class OM2MAggregatedResponse_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("resourceID", "ri")]
        public string ResourceID
        {
            get;
            set;
        }
        [OM2MXmlElement("responsePrimitive", "rsp", typeof(OM2MAggregatedResponse_Property0Description))]
        public List<OM2MResponsePrimitive> ResponsePrimitive
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("listOfChildResourceRef")]
    public partial class OM2MListOfChildResourceRef
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MChildResourceRef))]
        public class OM2MListOfChildResourceRef_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("childResource", typeof(OM2MListOfChildResourceRef_Property0Description))]
        public List<OM2MChildResourceRef> ChildResource
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("responsePrimitive","rsp")]
    public partial class OM2MResponsePrimitive
    {
        [OM2MXmlElement("responseStatusCode", "rsc")]
        public OM2MResponseStatusCode? ResponseStatusCode
        {
            get;
            set;
        }
        [OM2MXmlElement("requestIdentifier", "rqi", typeof(OM2MRequestIDDescription))]
        public string RequestIdentifier
        {
            get;
            set;
        }
        [OM2MXmlElement("primitiveContent", "pc")]
        public OM2MPrimitiveContent PrimitiveContent
        {
            get;
            set;
        }
        [OM2MXmlElement("to", "to", typeof(OM2MIDDescription))]
        public string To
        {
            get;
            set;
        }
        [OM2MXmlElement("from", "fr", typeof(OM2MIDDescription))]
        public string From
        {
            get;
            set;
        }
        [OM2MXmlElement("originatingTimestamp", "ot", typeof(OM2MTimestampDescription))]
        public string OriginatingTimestamp
        {
            get;
            set;
        }
        [OM2MXmlElement("resultExpirationTimestamp", "rset", typeof(OM2MAbsRelTimestampDescription))]
        public object ResultExpirationTimestamp
        {
            get;
            set;
        }
        [OM2MXmlElement("eventCategory", "ec", typeof(OM2MEventCatDescription))]
        public object EventCategory
        {
            get;
            set;
        }
        [OM2MXmlElement("contentStatus", "cnst")]
        public OM2MContentStatus? ContentStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("contentOffset", "cnot")]
        public int? ContentOffset
        {
            get;
            set;
        }
        [OM2MXmlElement("assignedTokenIdentifiers", "ati")]
        public OM2MDynAuthLocalTokenIdAssignments AssignedTokenIdentifiers
        {
            get;
            set;
        }
        [OM2MXmlElement("tokenReqInfo", "tqf")]
        public OM2MDynAuthTokenReqInfo TokenReqInfo
        {
            get;
            set;
        }
    }
}
