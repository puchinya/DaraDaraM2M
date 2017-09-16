using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("policyDeletionRules","pdr")]
    public partial class OM2MPolicyDeletionRules : OM2MRegularResource
    {
        [OM2MXmlElement("deletionRules")]
        public OM2MDeletionContexts DeletionRules
        {
            get;
            set;
        }
        [OM2MXmlElement("deletionRulesRelation")]
        public OM2MLogicalOperator? DeletionRulesRelation
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
