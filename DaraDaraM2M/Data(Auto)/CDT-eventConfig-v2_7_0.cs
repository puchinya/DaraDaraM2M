using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("eventConfig","evcg")]
    public partial class OM2MEventConfig : OM2MRegularResource
    {
        [OM2MXmlElement("creator", "cr", typeof(OM2MIDDescription))]
        public string Creator
        {
            get;
            set;
        }
        [OM2MXmlElement("eventID", "evi")]
        public string EventID
        {
            get;
            set;
        }
        [OM2MXmlElement("eventType", "evt")]
        public OM2MEventType? EventType
        {
            get;
            set;
        }
        [OM2MXmlElement("eventStart", typeof(OM2MTimestampDescription))]
        public string EventStart
        {
            get;
            set;
        }
        [OM2MXmlElement("eventEnd", "eve", typeof(OM2MTimestampDescription))]
        public string EventEnd
        {
            get;
            set;
        }
        [OM2MXmlElement("operationType", "opt", typeof(OM2MOperationTypeDescription))]
        public List<OM2MOperation> OperationType
        {
            get;
            set;
        }
        [OM2MXmlElement("dataSize", "ds")]
        public int? DataSize
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
        [OM2MXsdSimpleListType(null, typeof(OM2MOperation))]
        public class OM2MOperationTypeDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
}
