using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    public partial class OM2MEventNotificationCriteria
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MOperation))]
        public class OM2MEventNotificationCriteria_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MAttribute))]
        public class OM2MEventNotificationCriteria_Property1Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MNotificationEventType))]
        public class OM2MEventNotificationCriteria_Property2Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("createdBefore", typeof(OM2MTimestampDescription))]
        public string CreatedBefore
        {
            get;
            set;
        }
        [OM2MXmlElement("createdAfter", typeof(OM2MTimestampDescription))]
        public string CreatedAfter
        {
            get;
            set;
        }
        [OM2MXmlElement("modifiedSince", typeof(OM2MTimestampDescription))]
        public string ModifiedSince
        {
            get;
            set;
        }
        [OM2MXmlElement("unmodifiedSince", typeof(OM2MTimestampDescription))]
        public string UnmodifiedSince
        {
            get;
            set;
        }
        [OM2MXmlElement("stateTagSmaller")]
        public int? StateTagSmaller
        {
            get;
            set;
        }
        [OM2MXmlElement("stateTagBigger")]
        public int? StateTagBigger
        {
            get;
            set;
        }
        [OM2MXmlElement("expireBefore", typeof(OM2MTimestampDescription))]
        public string ExpireBefore
        {
            get;
            set;
        }
        [OM2MXmlElement("expireAfter", typeof(OM2MTimestampDescription))]
        public string ExpireAfter
        {
            get;
            set;
        }
        [OM2MXmlElement("sizeAbove")]
        public int? SizeAbove
        {
            get;
            set;
        }
        [OM2MXmlElement("sizeBelow")]
        public int? SizeBelow
        {
            get;
            set;
        }
        [OM2MXmlElement("operationMonitor", typeof(OM2MEventNotificationCriteria_Property0Description))]
        public List<OM2MOperation> OperationMonitor
        {
            get;
            set;
        }
        [OM2MXmlElement("attribute", typeof(OM2MEventNotificationCriteria_Property1Description))]
        public List<OM2MAttribute> Attribute
        {
            get;
            set;
        }
        [OM2MXmlElement("notificationEventType", typeof(OM2MEventNotificationCriteria_Property2Description))]
        public List<OM2MNotificationEventType> NotificationEventType
        {
            get;
            set;
        }
        [OM2MXmlElement("missingData")]
        public OM2MMissingData MissingData
        {
            get;
            set;
        }
    }
    public partial class OM2MBatchNotify
    {
        [OM2MXmlElement("number")]
        public int? Number
        {
            get;
            set;
        }
        [OM2MXmlElement("duration")]
        public DateTime? Duration
        {
            get;
            set;
        }
    }
    public partial class OM2MRateLimit
    {
        [OM2MXmlElement("maxNrOfNotify")]
        public int? MaxNrOfNotify
        {
            get;
            set;
        }
        [OM2MXmlElement("timeWindow")]
        public DateTime? TimeWindow
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("subscription","sub")]
    public partial class OM2MSubscription : OM2MRegularResource
    {
        [OM2MXmlElement("creator", "cr", typeof(OM2MIDDescription))]
        public string Creator
        {
            get;
            set;
        }
        [OM2MXmlElement("eventNotificationCriteria", "enc")]
        public OM2MEventNotificationCriteria EventNotificationCriteria
        {
            get;
            set;
        }
        [OM2MXmlElement("expirationCounter", "exc")]
        public int? ExpirationCounter
        {
            get;
            set;
        }
        [OM2MXmlElement("notificationURI", "nu", typeof(OM2MListOfURIsDescription))]
        public List<string> NotificationURI
        {
            get;
            set;
        }
        [OM2MXmlElement("groupID", "gpi")]
        public string GroupID
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
        [OM2MXmlElement("batchNotify", "bn")]
        public OM2MBatchNotify BatchNotify
        {
            get;
            set;
        }
        [OM2MXmlElement("rateLimit", "rl")]
        public OM2MRateLimit RateLimit
        {
            get;
            set;
        }
        [OM2MXmlElement("preSubscriptionNotify", "psn")]
        public int? PreSubscriptionNotify
        {
            get;
            set;
        }
        [OM2MXmlElement("pendingNotification", "pn")]
        public OM2MPendingNotification? PendingNotification
        {
            get;
            set;
        }
        [OM2MXmlElement("notificationStoragePriority", "nsp")]
        public int? NotificationStoragePriority
        {
            get;
            set;
        }
        [OM2MXmlElement("latestNotify", "ln")]
        public bool? LatestNotify
        {
            get;
            set;
        }
        [OM2MXmlElement("notificationContentType", "nct")]
        public OM2MNotificationContentType? NotificationContentType
        {
            get;
            set;
        }
        [OM2MXmlElement("notificationEventCat", "nec", typeof(OM2MEventCatDescription))]
        public object NotificationEventCat
        {
            get;
            set;
        }
        [OM2MXmlElement("subscriberURI", "su")]
        public string SubscriberURI
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
        [OM2MXmlElement("schedule", "sch", typeof(OM2MSchedule))]
        public List<OM2MSchedule> Schedule
        {
            get;
            set;
        }
        [OM2MXmlElement("notificationTargetMgmtPolicyRef", "ntpr", typeof(OM2MNotificationTargetMgmtPolicyRef))]
        public List<OM2MNotificationTargetMgmtPolicyRef> NotificationTargetMgmtPolicyRef
        {
            get;
            set;
        }
    }
}
