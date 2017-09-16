using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("delivery","dlv")]
    public partial class OM2MDelivery : OM2MRegularResource
    {
        [OM2MXmlElement("stateTag", "st")]
        public int? StateTag
        {
            get;
            set;
        }
        [OM2MXmlElement("source", "sr", typeof(OM2MIDDescription))]
        public string Source
        {
            get;
            set;
        }
        [OM2MXmlElement("target", "tg", typeof(OM2MIDDescription))]
        public string Target
        {
            get;
            set;
        }
        [OM2MXmlElement("lifespan", "Ls", typeof(OM2MTimestampDescription))]
        public string Lifespan
        {
            get;
            set;
        }
        [OM2MXmlElement("eventCat", "ec", typeof(OM2MEventCatDescription))]
        public object EventCat
        {
            get;
            set;
        }
        [OM2MXmlElement("deliveryMetaData", "dmd")]
        public OM2MDeliveryMetaData DeliveryMetaData
        {
            get;
            set;
        }
        [OM2MXmlElement("aggregatedRequest", "arq")]
        public OM2MAggregatedRequest AggregatedRequest
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
