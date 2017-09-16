using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("aggregatedNotification")]
    public partial class OM2MAggregatedNotification
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MNotification))]
        public class OM2MAggregatedNotification_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("notification", typeof(OM2MAggregatedNotification_Property0Description))]
        public List<OM2MNotification> Notification
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("notification")]
    public partial class OM2MNotification
    {
        [OM2MXmlElement("notificationEvent")]
        public OM2MNotificationEvent NotificationEvent
        {
            get;
            set;
        }
        [OM2MXmlElement("verificationRequest")]
        public bool? VerificationRequest
        {
            get;
            set;
        }
        [OM2MXmlElement("subscriptionDeletion")]
        public bool? SubscriptionDeletion
        {
            get;
            set;
        }
        [OM2MXmlElement("subscriptionReference")]
        public string SubscriptionReference
        {
            get;
            set;
        }
        [OM2MXmlElement("creator", "cr", typeof(OM2MIDDescription))]
        public string Creator
        {
            get;
            set;
        }
        [OM2MXmlElement("notificationForwardingURI", "nfu")]
        public string NotificationForwardingURI
        {
            get;
            set;
        }
        [OM2MXmlElement("IPEDiscoveryRequest")]
        public OM2MIPEDiscoveryRequest IPEDiscoveryRequest
        {
            get;
            set;
        }
        public partial class OM2MNotificationEvent
        {
            [OM2MXmlElement("representation")]
            public object Representation
            {
                get;
                set;
            }
            [OM2MXmlElement("operationMonitor")]
            public OM2MOperationMonitor OperationMonitor
            {
                get;
                set;
            }
            [OM2MXmlElement("notificationEventType")]
            public OM2MNotificationEventType? NotificationEventType
            {
                get;
                set;
            }
            public partial class OM2MOperationMonitor
            {
                [OM2MXmlElement("operation", "op")]
                public OM2MOperation? Operation
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
            }
        }
        public partial class OM2MIPEDiscoveryRequest
        {
            [OM2MXmlElement("originator", "org", typeof(OM2MIDDescription))]
            public string Originator
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
        }
    }
    [OM2MXmlRoot("securityInfo")]
    public partial class OM2MSecurityInfo
    {
        [OM2MXmlElement("securityInfoType")]
        public OM2MSecurityInfoType? SecurityInfoType
        {
            get;
            set;
        }
        [OM2MXmlElement("dasRequest")]
        public OM2MDynAuthDasRequest DasRequest
        {
            get;
            set;
        }
        [OM2MXmlElement("dasResponse")]
        public OM2MDynAuthDasResponse DasResponse
        {
            get;
            set;
        }
        [OM2MXmlElement("esprimRandObject")]
        public OM2MReceiverESPrimRandObject EsprimRandObject
        {
            get;
            set;
        }
        [OM2MXmlElement("esprimObject", typeof(OM2ME2eCompactJWEDescription))]
        public string EsprimObject
        {
            get;
            set;
        }
        [OM2MXmlElement("escertkeMessage")]
        public object EscertkeMessage
        {
            get;
            set;
        }
    }
    public partial class OM2MDynAuthDasResponse
    {
        [OM2MXmlElement("dynamicACPInfo")]
        public OM2MDynamicACPInfo DynamicACPInfo
        {
            get;
            set;
        }
        [OM2MXmlElement("tokens", "ts", typeof(OM2MTokensDescription))]
        public List<string> Tokens
        {
            get;
            set;
        }
        public partial class OM2MDynamicACPInfo
        {
            [OM2MXmlElement("grantedPrivileges")]
            public OM2MSetOfAcrs GrantedPrivileges
            {
                get;
                set;
            }
            [OM2MXmlElement("privilegesLifetime", typeof(OM2MAbsRelTimestampDescription))]
            public object PrivilegesLifetime
            {
                get;
                set;
            }
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MDynAuthJWTDescription))]
        public class OM2MTokensDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
}
