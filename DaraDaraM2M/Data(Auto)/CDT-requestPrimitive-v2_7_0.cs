using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("requestPrimitive","rqp")]
    public partial class OM2MRequestPrimitive
    {
        [OM2MXmlElement("operation", "op")]
        public OM2MOperation? Operation
        {
            get;
            set;
        }
        [OM2MXmlElement("to", "to")]
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
        [OM2MXmlElement("requestIdentifier", "rqi", typeof(OM2MRequestIDDescription))]
        public string RequestIdentifier
        {
            get;
            set;
        }
        [OM2MXmlElement("resourceType", "ty")]
        public OM2MResourceType? ResourceType
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
        [OM2MXmlElement("roleIDs", "rids", typeof(OM2MRoleIDsDescription))]
        public List<string> RoleIDs
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
        [OM2MXmlElement("requestExpirationTimestamp", "rget", typeof(OM2MAbsRelTimestampDescription))]
        public object RequestExpirationTimestamp
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
        [OM2MXmlElement("operationExecutionTime", "oet", typeof(OM2MAbsRelTimestampDescription))]
        public object OperationExecutionTime
        {
            get;
            set;
        }
        [OM2MXmlElement("responseType", "rt")]
        public OM2MResponseTypeInfo ResponseType
        {
            get;
            set;
        }
        [OM2MXmlElement("resultPersistence", "rp", typeof(OM2MAbsRelTimestampDescription))]
        public object ResultPersistence
        {
            get;
            set;
        }
        [OM2MXmlElement("resultContent", "rcn")]
        public OM2MResultContent? ResultContent
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
        [OM2MXmlElement("deliveryAggregation", "da")]
        public bool? DeliveryAggregation
        {
            get;
            set;
        }
        [OM2MXmlElement("groupRequestIdentifier", "gid")]
        public string GroupRequestIdentifier
        {
            get;
            set;
        }
        [OM2MXmlElement("filterCriteria", "fc")]
        public OM2MFilterCriteria FilterCriteria
        {
            get;
            set;
        }
        [OM2MXmlElement("discoveryResultType", "drt")]
        public OM2MDiscResType? DiscoveryResultType
        {
            get;
            set;
        }
        [OM2MXmlElement("tokens", "ts", typeof(OM2MDynAuthJWTDescription))]
        public string Tokens
        {
            get;
            set;
        }
        [OM2MXmlElement("tokenIDs", "tids", typeof(OM2MTokenIDDescription))]
        public string TokenIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("localTokenIDs", "ltids", typeof(OM2MLocalTokenIDsDescription))]
        public List<string> LocalTokenIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("tokenReqIndicator", "tqi")]
        public bool? TokenReqIndicator
        {
            get;
            set;
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MRoleIDDescription))]
        public class OM2MRoleIDsDescription : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(string))]
        public class OM2MLocalTokenIDsDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
}
