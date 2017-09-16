using System;

// 2.7.0
namespace DaraDaraM2M.Data
{
	public enum OM2MResourceType
	{
		AccessControlPolicy = 1,
		AE = 2,
		Container = 3,
		ContentInstance = 4,
		CSEBase = 5,
		Delivery = 6,
		EventConfig = 7,
		ExecInstance = 8,
		Group = 9,
		LocationPolicy = 10,
		M2mServiceSubscriptionProfile = 11,
		MgmtCmd = 12,
		MgmtObj = 13,
		Node = 14,
		PollingChannel = 15,
		RemoteCSE = 16,
		Request = 17,
		Schedule = 18,
		ServiceSubscribedAppRule = 19,
		ServiceSubscribedNode = 20,
		StatsCollect = 21,
		StatesConfig = 22,
		Subscription = 23,
		SemanticDescriptor = 24,
		NotificationTargetMgmtPolicyRef = 25,
		NotificationTargetPolicy = 26,
		PolicyDeletionRules = 27,
		FlexContainer = 28,
		TimeSeries = 29,
		TimeSeriesInstance = 30,
		Role = 31,
		Token = 32,
		TrafficPattern = 33,
		DynamicAuthorizationConsultation = 34,
		AccessControlPolicyAnnc = 1001,
		AEAnnc = 1002,
		ContainerAnnc = 1003,
		ContentInstanceAnnc = 1004,
		//CSEBaseAnnc = 1005,
		//DeliveryAnnc = 1006,
		//EventConfigAnnc = 1007,
		//ExecInstanceAnnc = 1008,
		GroupAnnc = 1009,
		LocationPolicyAnnc = 10010,
		//M2mServiceSubscriptionProfileAnnc = 10011,
		//MgmtCmdAnnc = 10012,
		MgmtObjAnnc = 10013,
		NodeAnnc = 10014,
		//PollingChannelAnnc = 10015,
		RemoteCSEAnnc = 10016,
		//RequestAnnc = 10017,
		ScheduleAnnc = 10018,
		ServiceSubscribedAppRuleAnnc = 10019,
		//ServiceSubscribedNodeAnnc = 10020,
		//StatsCollectAnnc = 10021,
		//StatesConfigAnnc = 10022,
		//SubscriptionAnnc = 10023,
		SemanticDescriptorAnnc = 10024,
		//NotificationTargetMgmtPolicyRefAnnc = 10025,
		//NotificationTargetPolicyAnnc = 10026,
		//PolicyDeletionRulesAnnc = 10027,
		FlexContainerAnnc = 10028,
		TimeSeriesAnnc = 10029,
		TimeSeriesInstanceAnnc = 10030,
		//RoleAnnc = 10031,
		//TokenAnnc = 10032,
		TrafficPatternAnnc = 10033,
		DynamicAuthorizationConsultationAnnc = 10034,
	}

	public enum OM2MCseTypeID
	{
		InCSE = 1,
		MnCSE = 2,
		AsnCSE = 3
	}

	public enum OM2MLocationSource
	{
		NetworkBased = 1,
		DeviceBased = 2,
		SharingBased = 3
	}

	public enum OM2MStdEventCats
	{
		Immediate = 2,
		BestEfffort = 3,
		Latest = 4
	}

	public enum OM2MOperation
	{
		Create = 1,
		Retrieve = 2,
		Update = 3,
		Delete = 4,
		Notify = 5
	}

	public enum OM2MResponseType
	{
		NonBlockingRequestSynch = 1,
		NonBlockingRequestAsynch = 2,
		BlockingRequest = 3,
		FlexBlocking = 4
	}

	public enum OM2MResultContent
	{
		Nothing = 0,
		Attributes = 1,
		HierarchicalAddress = 2,
		HierarchicalAddressAndAttributes = 3,
		AttributesAndChildResources = 4,
		AttributesAndChildResourceReferences = 5,
		ChildResourceReferences = 6,
		OriginalResource = 7,
		ChildResources = 8
	}

	public static class OM2MResultContentExtenstion
	{
		public static bool HasAttributes(this OM2MResultContent self)
		{
			return self == OM2MResultContent.Attributes ||
											self == OM2MResultContent.HierarchicalAddressAndAttributes ||
											self == OM2MResultContent.AttributesAndChildResources ||
											self == OM2MResultContent.AttributesAndChildResourceReferences;
		}

		public static bool HasChildResourceReferences(this OM2MResultContent self)
		{
			return self == OM2MResultContent.ChildResourceReferences ||
											self == OM2MResultContent.AttributesAndChildResourceReferences;
		}
	}

	public enum OM2MDiscResType
	{
		Structured = 1,
		Unstrctured = 2
	}

	public enum OM2MResponseStatusCode
	{
		Accepted = 1000,
		Ok = 2000,
		Created = 2001,
		Deleted = 2002,
		Updated = 2004,
		BadRequest = 4000,
		Forbidden = 4003,
		NotFound = 4004,
		OperationNotAllowed = 4005,
		RequestTimeout = 4008,
		SubscriptionCreatorHasNoPrivilege = 4101,
		ContentsUnacceptable = 4102,
		OriginatorHasNoPrivilege = 4103,
		GroupRequestIdentifierExists = 4104,
		Conflict = 4105,
		OriginatorHasNotRegistered = 4106,
		SecurityAssociationRequired = 4107,
		InvalidChildResourceType = 4108,
		NoMembers = 4109,
		GroupMemberTypeInconsistent = 4110,
		EsprimUnsupportedOption = 4111,
		EsprimUnknownKeyId = 4112,
		GesprimUnknownOrigRandId = 4123,
		EsprimUnknownRecvRandId = 4124,
		GesprimBadMac = 4115,
		InternalServerError = 5000,
		NotImplemented = 5001,
		TargetNotReachable = 5103,
		ReceiverHasNoPrivilege = 5105,
		AlreadyExists = 5106,
		TargetNotSubscribable = 5203,
		SubscriptionVerificationInitiationFailed = 5204,
		SubscriptionHostHasNoPrivilege = 5205,
		NonBlockingRequestNotSupported = 5206,
		NotAcceptable = 5207,
		DeiscoveryDeniedByIpe = 5208,
		GroupMembersNotResponded = 5209,
		EsprimDecryptionError = 5210,
		EsprimEncryptionError = 5211,
		SparqlUpdateError = 5212,
		ExternalObjectNotReachable = 6003,
		ExternalObjectNotFound = 6005,
		MaxNumberOfMemberExceeded = 6010,
		MgmtSessionCannotBeEstablished = 6020,
		MgmtSessionEstablishmentTimeout = 6021,
		InvalidCmdType = 6022,
		InvalidArguments = 6023,
		InsufficientArguments = 6024,
		MgmtConversionError = 6025,
		MgmtCancellationFailed = 6026,
		AlreadyComplete = 6028,
		MgmtCommandNotCancellable = 6029
	}

	public static class OM2MResponseStatusCodeExtension
	{
		public static bool IsSuccess(this OM2MResponseStatusCode code)
		{
			return (int)code < 3000;
		}

		public static bool IsFailed(this OM2MResponseStatusCode code)
		{
			return 4000 <= (int)code;
		}
	}

	public enum OM2MRequestStatus
	{
		Completed = 1,
		Failed = 2,
		Pending = 3,
		Forwarded = 4,
	}

	public enum OM2MMemberType
	{
		Mixed = 0,
		AccessControlPolicy = 1,
		AE = 2,
		Container = 3,
		ContentInstance = 4,
		CSEBase = 5,
		Delivery = 6,
		EventConfig = 7,
		ExecInstance = 8,
		Group = 9,
		LocationPolicy = 10,
		M2mServiceSubscriptionProfile = 11,
		MgmtCmd = 12,
		MgmtObj = 13,
		Node = 14,
		PollingChannel = 15,
		RemoteCSE = 16,
		Request = 17,
		Schedule = 18,
		ServiceSubscribedAppRule = 19,
		ServiceSubscribedNode = 20,
		StatsCollect = 21,
		StatesConfig = 22,
		Subscription = 23,
		SemanticDescriptor = 24,
		NotificationTargetMgmtPolicyRef = 25,
		NotificationTargetPolicy = 26,
		PolicyDeletionRules = 27,
		FlexContainer = 28,
		TimeSeries = 29,
		TimeSeriesInstance = 30,
		Role = 31,
		Token = 32,
		TrafficPattern = 33,
		DynamicAuthorizationConsultation = 34,
		AccessControlPolicyAnnc = 1001,
		AEAnnc = 1002,
		ContainerAnnc = 1003,
		ContentInstanceAnnc = 1004,
		//CSEBaseAnnc = 1005,
		//DeliveryAnnc = 1006,
		//EventConfigAnnc = 1007,
		//ExecInstanceAnnc = 1008,
		GroupAnnc = 1009,
		LocationPolicyAnnc = 10010,
		//M2mServiceSubscriptionProfileAnnc = 10011,
		//MgmtCmdAnnc = 10012,
		MgmtObjAnnc = 10013,
		NodeAnnc = 10014,
		//PollingChannelAnnc = 10015,
		RemoteCSEAnnc = 10016,
		//RequestAnnc = 10017,
		ScheduleAnnc = 10018,
		ServiceSubscribedAppRuleAnnc = 10019,
		//ServiceSubscribedNodeAnnc = 10020,
		//StatsCollectAnnc = 10021,
		//StatesConfigAnnc = 10022,
		//SubscriptionAnnc = 10023,
		SemanticDescriptorAnnc = 10024,
		//NotificationTargetMgmtPolicyRefAnnc = 10025,
		//NotificationTargetPolicyAnnc = 10026,
		//PolicyDeletionRulesAnnc = 10027,
		FlexContainerAnnc = 10028,
		TimeSeriesAnnc = 10029,
		TimeSeriesInstanceAnnc = 10030,
		//RoleAnnc = 10031,
		//TokenAnnc = 10032,
		TrafficPatternAnnc = 10033,
		DynamicAuthorizationConsultationAnnc = 10034,
		Oldest = 20001,
		Latest = 20002
	}

	public enum OM2MConsistencyStrategy
	{
		AbandonMember = 1,
		AbandonGroup = 2,
		SetMixed = 3
	}

	public enum OM2MCmdType
	{
		Reset = 1,
		Reboot = 2,
		Upload = 3,
		Download = 4,
		SoftwareInstall = 5,
		SoftwareUninstall = 6,
		SoftwareUpdate = 7
	}

	public enum OM2MExecModeType
	{
		ImmediateOnce = 1,
		ImmediateRepeat = 2,
		RandomOnce = 3,
		RandomRepeat = 4,
	}

	public enum OM2MExecStatusType
	{
		Initiated = 1,
		Pending = 2,
		Finished = 3,
		Cancelling = 4,
		Cancelled = 5,
		StatusNonCancellable = 6
	}

	// TBC
	public enum OM2MExecResultType
	{
	}

	public enum OM2MPendingNotification
	{
		SendLatest = 1,
		SendAllPending = 2
	}

	public enum OM2MNotificationContentType
	{
		AllAttributes = 1,
		ModifiedAttributes = 2,
		ResourceId = 3
	}

	public enum OM2MNotificationEventType
	{
		UpdateResource = 1,
		DeleteResource = 2,
		CreateDirectChildResource = 3,
		DeleteDirectChildResource = 4,
		RetrieveContainerResource = 5
	}

	public enum OM2MStatus
	{
		Succeessful = 1,
		Failure = 2,
		InProcess = 3
	}

	public enum OM2MBatteryStatus
	{
		Normal = 1,
		Charging = 2,
		ChargingComplete = 3,
		Damaged = 4,
		LowBattery = 5,
		NotInstalled = 6,
		Unknown = 7
	}

	// TBD
	public enum OM2MMgmtDefinition
	{
		Unspecified = 0,
		Firmware = 1001,
		Software = 1002,
		Memory = 1003
	}

	public enum OM2MLogTypeId
	{
		System = 1,
		Security = 2,
		Event = 3,
		Trace = 4,
		Panic = 5
	}

	public enum OM2MLogStatus
	{
		Started = 1,
		Stopped = 2,
		Unknown = 3,
		NotPresent = 4,
		Error = 5
	}

	public enum OM2MEventType
	{
		DataOperation = 1,
		StorageBased = 2,
		TimerBased = 3
	}

	public enum OM2MStatsRuleStatusType
	{
		Active = 1,
		Inactive = 2
	}

	public enum OM2MStatModelType
	{
		EventBased = 1,
	}

	public enum OM2MEncodingType
	{
		Plain = 0,
		Base64String = 1,
		Base64Binary = 2
	}

	// TBD
	public enum OM2MAccessControlOperations
	{
		Create = 1,
		Retrieve = 2,
		CreateAndRetrieve = 3,
		Update = 4,
		Delete = 8,
		Notify = 16,
		Discover = 32
	}

	public enum OM2MFilterUsage
	{
		Dictionary = 1,
		ConditionalRetrieval = 2,
		IPEOnDemandDiscovery = 3
	}

	public enum OM2MNotificationTargetPolicyAction
	{
		AcceptRequest = 1,
		RejectRequest = 2,
		SeekAuthorization = 3,
		InfromSubscription = 4,
	}

	public enum OM2MLogicalOperator
	{
		And = 1,
		Or = 2
	}

	public enum OM2MAllJoynDirection
	{
		AllJoynToOneM2M = 1,
		OneM2MToAllJoyn = 2
	}

	public enum OM2MContentFilterSyntax
	{
		JsonPathSyntax = 1
	}

	// TBD
	public enum OM2MContentSecurity
	{
		JsonPathSyntax = 1
	}

	// TBD
	public enum OM2MSuid
	{
		JsonPathSyntax = 1
	}

	// TBD
	public enum OM2MEsprimKeyGenAlgID
	{
		JsonPathSyntax = 1
	}

	// TBD
	public enum OM2MEsprimProtocolAndAlgID
	{
		JsonPathSyntax = 1
	}

	public enum OM2MPeriodicIndicator
	{
		Periodic = 1,
		OnDemand = 2
	}

	public enum OM2MStationaryIndication
	{
		Stationary = 1,
		Mobile = 2
	}

	public enum OM2MContentStatus
	{
		PartialContent = 1,
		FullContent = 2
	}

	public enum OM2MNetworkAction
	{
		CellularRegistration = 1,
		CellularAttach = 2,
		CellularPdpctxact = 3,
		CellularSms = 4,
		Default = 5
	}

	// TBD
	public enum OM2MSecurityInfoType
	{
		PartialContent = 1,
		FullContent = 2
	}
}
