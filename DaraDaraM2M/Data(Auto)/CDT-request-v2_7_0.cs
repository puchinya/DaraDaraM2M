using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("request","req")]
    public partial class OM2MRequest : OM2MRegularResource
    {
        [OM2MXmlElement("stateTag", "st")]
        public int? StateTag
        {
            get;
            set;
        }
        [OM2MXmlElement("operation", "op")]
        public OM2MOperation? Operation
        {
            get;
            set;
        }
        [OM2MXmlElement("target", "tg")]
        public string Target
        {
            get;
            set;
        }
        [OM2MXmlElement("originator", "org", typeof(OM2MIDDescription))]
        public string Originator
        {
            get;
            set;
        }
        [OM2MXmlElement("requestID", "rid", typeof(OM2MRequestIDDescription))]
        public string RequestID
        {
            get;
            set;
        }
        [OM2MXmlElement("metaInformation", "mi")]
        public OM2MMetaInformation MetaInformation
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
        [OM2MXmlElement("requestStatus", "rs")]
        public OM2MRequestStatus? RequestStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("operationResult", "ors")]
        public OM2MOperationResult OperationResult
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
