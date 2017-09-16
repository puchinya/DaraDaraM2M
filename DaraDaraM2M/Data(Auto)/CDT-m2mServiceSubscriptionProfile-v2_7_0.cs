using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("m2mServiceSubscriptionProfile","mssp")]
    public partial class OM2MM2mServiceSubscriptionProfile : OM2MRegularResource
    {
        [OM2MXmlElement("childResource", typeof(OM2MChildResourceRef))]
        public List<OM2MChildResourceRef> ChildResource
        {
            get;
            set;
        }
        [OM2MXmlElement("serviceSubscribedNode", "svsn", typeof(OM2MServiceSubscribedNode))]
        public List<OM2MServiceSubscribedNode> ServiceSubscribedNode
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
