using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("notificationTargetPolicy","ntp")]
    public partial class OM2MNotificationTargetPolicy : OM2MRegularResource
    {
        [OM2MXmlElement("creator", "cr", typeof(OM2MIDDescription))]
        public string Creator
        {
            get;
            set;
        }
        [OM2MXmlElement("action")]
        public OM2MNotificationTargetPolicyAction? Action
        {
            get;
            set;
        }
        [OM2MXmlElement("policyLabel")]
        public string PolicyLabel
        {
            get;
            set;
        }
        [OM2MXmlElement("rulesRelationship")]
        public OM2MLogicalOperator? RulesRelationship
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
        [OM2MXmlElement("policyDeletionRules", "pdr", typeof(OM2MPolicyDeletionRules))]
        public List<OM2MPolicyDeletionRules> PolicyDeletionRules
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
