using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXsdSimpleType("ID", typeof(string))]
    public class OM2MIDDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("nodeID", typeof(string))]
    public class OM2MNodeIDDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("deviceID", typeof(string))]
    public class OM2MDeviceIDDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("externalID", typeof(string))]
    public class OM2MExternalIDDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("requestID", typeof(string))]
    public class OM2MRequestIDDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("roleID", typeof(string))]
    public class OM2MRoleIDDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("tokenID", typeof(string))]
    public class OM2MTokenIDDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("nhURI", typeof(string))]
    public class OM2MNhURIDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleListType("acpType", typeof(OM2MIDDescription))]
    public class OM2MAcpTypeDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleListType("labels", typeof(string))]
    public class OM2MLabelsDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleType("triggerRecipientID", typeof(uint))]
    public class OM2MTriggerRecipientIDDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleListType("listOfM2MID", typeof(OM2MIDDescription))]
    public class OM2MListOfM2MIDDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleType("longMin-1", typeof(long))]
    public class OM2MLongMin1Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleListType("listOfMinMax", typeof(OM2MLongMin1Description))]
    public class OM2MListOfMinMaxDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleType("ipv4", typeof(string))]
    public class OM2MIpv4Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("ipv6", typeof(string))]
    public class OM2MIpv6Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleListType("poaList", typeof(string))]
    public class OM2MPoaListDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleType("timestamp", typeof(string))]
    public class OM2MTimestampDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType(null, typeof(OM2MTimestampDescription))]
    public class OM2MAbsRelTimestamp_Member0Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType(null, typeof(long))]
    public class OM2MAbsRelTimestamp_Member1Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleUnionType("absRelTimestamp")]
    [OM2MXsdSimpleUnionTypeMember(typeof(OM2MTimestampDescription))]
    [OM2MXsdSimpleUnionTypeMember(typeof(long))]
    public class OM2MAbsRelTimestampDescription : OM2MXsdSimpleUnionTypeDescription
    {
    }
    [OM2MXsdSimpleType(null, typeof(OM2MListOfTimeStampDescription))]
    public class OM2MMissingDataList_Member0Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType(null, typeof(OM2MListOfRelTimeStampDescription))]
    public class OM2MMissingDataList_Member1Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleUnionType("missingDataList")]
    [OM2MXsdSimpleUnionTypeMember(typeof(OM2MListOfTimeStampDescription))]
    [OM2MXsdSimpleUnionTypeMember(typeof(OM2MListOfRelTimeStampDescription))]
    public class OM2MMissingDataListDescription : OM2MXsdSimpleUnionTypeDescription
    {
    }
    [OM2MXsdSimpleListType("listOfTimeStamp", typeof(OM2MTimestampDescription))]
    public class OM2MListOfTimeStampDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleListType("listOfRelTimeStamp", typeof(long))]
    public class OM2MListOfRelTimeStampDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleType("typeOfContent", typeof(string))]
    public class OM2MTypeOfContentDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("permittedMediaTypes", typeof(OM2MTypeOfContentDescription))]
    public class OM2MPermittedMediaTypesDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleListType("serializations", typeof(OM2MPermittedMediaTypesDescription))]
    public class OM2MSerializationsDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleType("contentInfo", typeof(string))]
    public class OM2MContentInfoDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType(null, typeof(OM2MStdEventCats))]
    public class OM2MEventCat_Member0Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType(null, typeof(int))]
    public class OM2MEventCat_Member1Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleUnionType("eventCat")]
    [OM2MXsdSimpleUnionTypeMember(typeof(OM2MStdEventCats))]
    [OM2MXsdSimpleUnionTypeMember(typeof(int))]
    public class OM2MEventCatDescription : OM2MXsdSimpleUnionTypeDescription
    {
    }
    [OM2MXsdSimpleType(null, typeof(OM2MEventCatDescription))]
    public class OM2MEventCatWithDef_Member0Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType(null, typeof(int))]
    public class OM2MEventCatWithDef_Member1Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleUnionType("eventCatWithDef")]
    [OM2MXsdSimpleUnionTypeMember(typeof(OM2MEventCatDescription))]
    [OM2MXsdSimpleUnionTypeMember(typeof(int))]
    public class OM2MEventCatWithDefDescription : OM2MXsdSimpleUnionTypeDescription
    {
    }
    [OM2MXsdSimpleListType("listOfEventCat", typeof(OM2MEventCatDescription))]
    public class OM2MListOfEventCatDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleListType("listOfEventCatWithDef", typeof(OM2MEventCatWithDefDescription))]
    public class OM2MListOfEventCatWithDefDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleType("scheduleEntry", typeof(string))]
    public class OM2MScheduleEntryDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleListType("listOfURIs", typeof(string))]
    public class OM2MListOfURIsDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleListType("listOfDuration", typeof(DateTime))]
    public class OM2MListOfDurationDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleListType("attributeList", typeof(string))]
    public class OM2MAttributeListDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleListType("resourceTypeList", typeof(OM2MResourceType))]
    public class OM2MResourceTypeListDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXsdSimpleType("sparql", typeof(string))]
    public class OM2MSparqlDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("descriptorRepresentation", typeof(string))]
    public class OM2MDescriptorRepresentationDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("e2eCompactJWS", typeof(string))]
    public class OM2ME2eCompactJWSDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType("e2eCompactJWE", typeof(string))]
    public class OM2ME2eCompactJWEDescription : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType(null, typeof(OM2ME2eCompactJWSDescription))]
    public class OM2MDynAuthJWT_Member0Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleType(null, typeof(OM2ME2eCompactJWEDescription))]
    public class OM2MDynAuthJWT_Member1Description : OM2MXsdSimpleTypeDescription
    {
    }
    [OM2MXsdSimpleUnionType("dynAuthJWT")]
    [OM2MXsdSimpleUnionTypeMember(typeof(OM2ME2eCompactJWSDescription))]
    [OM2MXsdSimpleUnionTypeMember(typeof(OM2ME2eCompactJWEDescription))]
    public class OM2MDynAuthJWTDescription : OM2MXsdSimpleUnionTypeDescription
    {
    }
    public partial class OM2MDeliveryMetaData
    {
        [OM2MXmlElement("tracingOption")]
        public bool? TracingOption
        {
            get;
            set;
        }
        [OM2MXmlElement("tracingInfo", typeof(OM2MListOfM2MIDDescription))]
        public List<string> TracingInfo
        {
            get;
            set;
        }
    }
    public partial class OM2MAggregatedRequest
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MRequest))]
        public class OM2MAggregatedRequest_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("request", "req", typeof(OM2MAggregatedRequest_Property0Description))]
        public List<OM2MRequest> Request
        {
            get;
            set;
        }
        public partial class OM2MRequest
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
            [OM2MXmlElement("primitiveContent", "pc")]
            public OM2MPrimitiveContent PrimitiveContent
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
        }
    }
    public partial class OM2MMetaInformation
    {
        [OM2MXmlElement("resourceType", "ty")]
        public OM2MResourceType? ResourceType
        {
            get;
            set;
        }
        [OM2MXmlElement("name")]
        public string Name
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
    }
    public partial class OM2MPrimitiveContent
    {
        [OM2MXmlAnyElement]
        public List<object> Any
        {
            get;
            set;
        }
    }
    public partial class OM2MFilterCriteria
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MTypeOfContentDescription))]
        public class OM2MFilterCriteria_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MAttribute))]
        public class OM2MFilterCriteria_Property1Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MSparqlDescription))]
        public class OM2MFilterCriteria_Property2Description : OM2MXsdSimpleListTypeDescription
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
        [OM2MXmlElement("labels", "lbl", typeof(OM2MLabelsDescription))]
        public List<string> Labels
        {
            get;
            set;
        }
        [OM2MXmlElement("resourceType", "ty", typeof(OM2MResourceTypeListDescription))]
        public List<OM2MResourceType> ResourceType
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
        [OM2MXmlElement("contentType", typeof(OM2MFilterCriteria_Property0Description))]
        public List<string> ContentType
        {
            get;
            set;
        }
        [OM2MXmlElement("attribute", typeof(OM2MFilterCriteria_Property1Description))]
        public List<OM2MAttribute> Attribute
        {
            get;
            set;
        }
        [OM2MXmlElement("filterUsage")]
        public OM2MFilterUsage? FilterUsage
        {
            get;
            set;
        }
        [OM2MXmlElement("limit")]
        public int? Limit
        {
            get;
            set;
        }
        [OM2MXmlElement("semanticsFilter", typeof(OM2MFilterCriteria_Property2Description))]
        public List<string> SemanticsFilter
        {
            get;
            set;
        }
        [OM2MXmlElement("filterOperation")]
        public bool? FilterOperation
        {
            get;
            set;
        }
        [OM2MXmlElement("contentFilterSyntax")]
        public OM2MContentFilterSyntax? ContentFilterSyntax
        {
            get;
            set;
        }
        [OM2MXmlElement("contentFilterQuery")]
        public string ContentFilterQuery
        {
            get;
            set;
        }
        [OM2MXmlElement("level")]
        public int? Level
        {
            get;
            set;
        }
        [OM2MXmlElement("offset")]
        public int? Offset
        {
            get;
            set;
        }
    }
    public partial class OM2MAttribute
    {
        [OM2MXmlElement("name")]
        public string Name
        {
            get;
            set;
        }
        [OM2MXmlElement("value")]
        public object Value
        {
            get;
            set;
        }
    }
    public partial class OM2MScheduleEntries
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MScheduleEntryDescription))]
        public class OM2MScheduleEntries_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("scheduleEntry", typeof(OM2MScheduleEntries_Property0Description))]
        public List<string> ScheduleEntry
        {
            get;
            set;
        }
    }
    public partial class OM2MActionStatus
    {
        [OM2MXmlElement("action")]
        public string Action
        {
            get;
            set;
        }
        [OM2MXmlElement("status")]
        public OM2MStatus? Status
        {
            get;
            set;
        }
    }
    public partial class OM2MAnyArgType
    {
        [OM2MXmlElement("name")]
        public string Name
        {
            get;
            set;
        }
        [OM2MXmlElement("value")]
        public object Value
        {
            get;
            set;
        }
    }
    public partial class OM2MResetArgsType
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MAnyArgType))]
        public class OM2MResetArgsType_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("anyArg", typeof(OM2MResetArgsType_Property0Description))]
        public List<OM2MAnyArgType> AnyArg
        {
            get;
            set;
        }
    }
    public partial class OM2MRebootArgsType
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MAnyArgType))]
        public class OM2MRebootArgsType_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("anyArg", typeof(OM2MRebootArgsType_Property0Description))]
        public List<OM2MAnyArgType> AnyArg
        {
            get;
            set;
        }
    }
    public partial class OM2MUploadArgsType
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MAnyArgType))]
        public class OM2MUploadArgsType_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("fileType")]
        public string FileType
        {
            get;
            set;
        }
        [OM2MXmlElement("URL", "url")]
        public string URL
        {
            get;
            set;
        }
        [OM2MXmlElement("username")]
        public string Username
        {
            get;
            set;
        }
        [OM2MXmlElement("password")]
        public string Password
        {
            get;
            set;
        }
        [OM2MXmlElement("anyArg", typeof(OM2MUploadArgsType_Property0Description))]
        public List<OM2MAnyArgType> AnyArg
        {
            get;
            set;
        }
    }
    public partial class OM2MDownloadArgsType
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MAnyArgType))]
        public class OM2MDownloadArgsType_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("fileType")]
        public string FileType
        {
            get;
            set;
        }
        [OM2MXmlElement("URL", "url")]
        public string URL
        {
            get;
            set;
        }
        [OM2MXmlElement("username")]
        public string Username
        {
            get;
            set;
        }
        [OM2MXmlElement("password")]
        public string Password
        {
            get;
            set;
        }
        [OM2MXmlElement("filesize")]
        public int? Filesize
        {
            get;
            set;
        }
        [OM2MXmlElement("targetFile")]
        public string TargetFile
        {
            get;
            set;
        }
        [OM2MXmlElement("delaySeconds")]
        public int? DelaySeconds
        {
            get;
            set;
        }
        [OM2MXmlElement("successURL")]
        public string SuccessURL
        {
            get;
            set;
        }
        [OM2MXmlElement("startTime", typeof(OM2MTimestampDescription))]
        public string StartTime
        {
            get;
            set;
        }
        [OM2MXmlElement("completeTime", typeof(OM2MTimestampDescription))]
        public string CompleteTime
        {
            get;
            set;
        }
        [OM2MXmlElement("anyArg", typeof(OM2MDownloadArgsType_Property0Description))]
        public List<OM2MAnyArgType> AnyArg
        {
            get;
            set;
        }
    }
    public partial class OM2MSoftwareInstallArgsType
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MAnyArgType))]
        public class OM2MSoftwareInstallArgsType_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("URL", "url")]
        public string URL
        {
            get;
            set;
        }
        [OM2MXmlElement("UUID")]
        public string UUID
        {
            get;
            set;
        }
        [OM2MXmlElement("username")]
        public string Username
        {
            get;
            set;
        }
        [OM2MXmlElement("password")]
        public string Password
        {
            get;
            set;
        }
        [OM2MXmlElement("executionEnvRef")]
        public string ExecutionEnvRef
        {
            get;
            set;
        }
        [OM2MXmlElement("anyArg", typeof(OM2MSoftwareInstallArgsType_Property0Description))]
        public List<OM2MAnyArgType> AnyArg
        {
            get;
            set;
        }
    }
    public partial class OM2MSoftwareUpdateArgsType
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MAnyArgType))]
        public class OM2MSoftwareUpdateArgsType_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("UUID")]
        public string UUID
        {
            get;
            set;
        }
        [OM2MXmlElement("version", "vr")]
        public string Version
        {
            get;
            set;
        }
        [OM2MXmlElement("URL", "url")]
        public string URL
        {
            get;
            set;
        }
        [OM2MXmlElement("username")]
        public string Username
        {
            get;
            set;
        }
        [OM2MXmlElement("password")]
        public string Password
        {
            get;
            set;
        }
        [OM2MXmlElement("executionEnvRef")]
        public string ExecutionEnvRef
        {
            get;
            set;
        }
        [OM2MXmlElement("anyArg", typeof(OM2MSoftwareUpdateArgsType_Property0Description))]
        public List<OM2MAnyArgType> AnyArg
        {
            get;
            set;
        }
    }
    public partial class OM2MSoftwareUninstallArgsType
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MAnyArgType))]
        public class OM2MSoftwareUninstallArgsType_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("UUID")]
        public string UUID
        {
            get;
            set;
        }
        [OM2MXmlElement("version", "vr")]
        public string Version
        {
            get;
            set;
        }
        [OM2MXmlElement("executionEnvRef")]
        public string ExecutionEnvRef
        {
            get;
            set;
        }
        [OM2MXmlElement("anyArg", typeof(OM2MSoftwareUninstallArgsType_Property0Description))]
        public List<OM2MAnyArgType> AnyArg
        {
            get;
            set;
        }
    }
    public partial class OM2MExecReqArgsListType
    {
        [OM2MXmlElement("reset", typeof(OM2MResetArgsType))]
        public List<OM2MResetArgsType> Reset
        {
            get;
            set;
        }
        [OM2MXmlElement("reboot", "rbo", typeof(OM2MRebootArgsType))]
        public List<OM2MRebootArgsType> Reboot
        {
            get;
            set;
        }
        [OM2MXmlElement("upload", typeof(OM2MUploadArgsType))]
        public List<OM2MUploadArgsType> Upload
        {
            get;
            set;
        }
        [OM2MXmlElement("download", typeof(OM2MDownloadArgsType))]
        public List<OM2MDownloadArgsType> Download
        {
            get;
            set;
        }
        [OM2MXmlElement("softwareInstall", typeof(OM2MSoftwareInstallArgsType))]
        public List<OM2MSoftwareInstallArgsType> SoftwareInstall
        {
            get;
            set;
        }
        [OM2MXmlElement("softwareUpdate", typeof(OM2MSoftwareUpdateArgsType))]
        public List<OM2MSoftwareUpdateArgsType> SoftwareUpdate
        {
            get;
            set;
        }
        [OM2MXmlElement("softwareUninstall", typeof(OM2MSoftwareUninstallArgsType))]
        public List<OM2MSoftwareUninstallArgsType> SoftwareUninstall
        {
            get;
            set;
        }
    }
    public partial class OM2MMgmtLinkRef
    {
        [OM2MXmlAttribute("name")]
        public string Name
        {
            get;
            set;
        }
        [OM2MXmlAttribute("type")]
        public OM2MMgmtDefinition? Type
        {
            get;
            set;
        }
        [OM2MXmlValue]
        public string Value
        {
            get;
            set;
        }
    }
    public partial class OM2MSetOfAcrs
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MAccessControlRule))]
        public class OM2MSetOfAcrs_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("accessControlRule", typeof(OM2MSetOfAcrs_Property0Description))]
        public List<OM2MAccessControlRule> AccessControlRule
        {
            get;
            set;
        }
    }
    public partial class OM2MAccessControlRule
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MAccessControlContexts))]
        public class OM2MAccessControlRule_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("accessControlOriginators", typeof(OM2MListOfURIsDescription))]
        public List<string> AccessControlOriginators
        {
            get;
            set;
        }
        [OM2MXmlElement("accessControlOperations")]
        public OM2MAccessControlOperations? AccessControlOperations
        {
            get;
            set;
        }
        [OM2MXmlElement("accessControlContexts", typeof(OM2MAccessControlRule_Property0Description))]
        public List<OM2MAccessControlContexts> AccessControlContexts
        {
            get;
            set;
        }
        [OM2MXmlElement("accessControlAuthenticationFlag")]
        public bool? AccessControlAuthenticationFlag
        {
            get;
            set;
        }
        public partial class OM2MAccessControlContexts
        {
            [OM2MXsdSimpleListType(null, typeof(OM2MScheduleEntryDescription))]
            public class OM2MAccessControlContexts_Property0Description : OM2MXsdSimpleListTypeDescription
            {
            }
            [OM2MXmlElement("accessControlWindow", typeof(OM2MAccessControlContexts_Property0Description))]
            public List<string> AccessControlWindow
            {
                get;
                set;
            }
            [OM2MXmlElement("accessControlIpAddresses")]
            public OM2MAccessControlIpAddresses AccessControlIpAddresses
            {
                get;
                set;
            }
            [OM2MXmlElement("accessControlLocationRegion")]
            public OM2MLocationRegion AccessControlLocationRegion
            {
                get;
                set;
            }
            public partial class OM2MAccessControlIpAddresses
            {
                [OM2MXmlElement("ipv4Addresses", typeof(OM2MIpv4AddressesDescription))]
                public List<string> Ipv4Addresses
                {
                    get;
                    set;
                }
                [OM2MXmlElement("ipv6Addresses", typeof(OM2MIpv6AddressesDescription))]
                public List<string> Ipv6Addresses
                {
                    get;
                    set;
                }
                [OM2MXsdSimpleListType(null, typeof(OM2MIpv4Description))]
                public class OM2MIpv4AddressesDescription : OM2MXsdSimpleListTypeDescription
                {
                }
                [OM2MXsdSimpleListType(null, typeof(OM2MIpv6Description))]
                public class OM2MIpv6AddressesDescription : OM2MXsdSimpleListTypeDescription
                {
                }
            }
        }
    }
    public partial class OM2MChildResourceRef
    {
        [OM2MXmlAttribute("name")]
        public string Name
        {
            get;
            set;
        }
        [OM2MXmlAttribute("type")]
        public OM2MResourceType? Type
        {
            get;
            set;
        }
        [OM2MXmlAttribute("specializationID")]
        public string SpecializationID
        {
            get;
            set;
        }
        [OM2MXmlValue]
        public string Value
        {
            get;
            set;
        }
    }
    public partial class OM2MResponseTypeInfo
    {
        [OM2MXmlElement("responseTypeValue")]
        public OM2MResponseType? ResponseTypeValue
        {
            get;
            set;
        }
        [OM2MXmlElement("notificationURI", "nu", typeof(OM2MNotificationURIDescription))]
        public List<string> NotificationURI
        {
            get;
            set;
        }
        [OM2MXsdSimpleListType(null, typeof(string))]
        public class OM2MNotificationURIDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
    public partial class OM2MOperationResult
    {
        [OM2MXmlElement("responseStatusCode", "rsc")]
        public OM2MResponseStatusCode? ResponseStatusCode
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
        [OM2MXmlElement("primitiveContent", "pc")]
        public OM2MPrimitiveContent PrimitiveContent
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
        [OM2MXmlElement("originatingTimestamp", "ot", typeof(OM2MTimestampDescription))]
        public string OriginatingTimestamp
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
        [OM2MXmlElement("eventCategory", "ec", typeof(OM2MEventCatDescription))]
        public object EventCategory
        {
            get;
            set;
        }
        [OM2MXmlElement("contentStatus", "cnst")]
        public OM2MContentStatus? ContentStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("contentOffset", "cnot")]
        public int? ContentOffset
        {
            get;
            set;
        }
    }
    public partial class OM2MContentRef
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MURIReference))]
        public class OM2MContentRef_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("URIReference", typeof(OM2MContentRef_Property0Description))]
        public List<OM2MURIReference> URIReference
        {
            get;
            set;
        }
        public partial class OM2MURIReference
        {
            [OM2MXmlElement("name")]
            public string Name
            {
                get;
                set;
            }
            [OM2MXmlElement("URI")]
            public string URI
            {
                get;
                set;
            }
        }
    }
    public partial class OM2MDeletionContexts
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MScheduleEntryDescription))]
        public class OM2MDeletionContexts_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MLocationRegion))]
        public class OM2MDeletionContexts_Property1Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("timeOfDay", typeof(OM2MDeletionContexts_Property0Description))]
        public List<string> TimeOfDay
        {
            get;
            set;
        }
        [OM2MXmlElement("locationRegions", typeof(OM2MDeletionContexts_Property1Description))]
        public List<OM2MLocationRegion> LocationRegions
        {
            get;
            set;
        }
    }
    public partial class OM2MLocationRegion
    {
        [OM2MXmlElement("countryCode", typeof(List<string>))]
        public List<List<string>> CountryCode
        {
            get;
            set;
        }
        [OM2MXmlElement("circRegion", typeof(List<float>))]
        public List<List<float>> CircRegion
        {
            get;
            set;
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MCountryCodeDescription))]
        public class OM2MCountryCodeDescription : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(float))]
        public class OM2MCircRegionDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
    [OM2MXsdSimpleType("countryCode", typeof(string))]
    public class OM2MCountryCodeDescription : OM2MXsdSimpleTypeDescription
    {
    }
    public partial class OM2MMissingData
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
    public partial class OM2MReceiverESPrimRandObject
    {
        [OM2MXmlElement("esprimRandID")]
        public string EsprimRandID
        {
            get;
            set;
        }
        [OM2MXmlElement("esprimRandValue")]
        public string EsprimRandValue
        {
            get;
            set;
        }
        [OM2MXmlElement("esprimRandExpiry", typeof(OM2MAbsRelTimestampDescription))]
        public object EsprimRandExpiry
        {
            get;
            set;
        }
        [OM2MXmlElement("esprimKeyGenAlgIDs", typeof(OM2MEsprimKeyGenAlgIDsDescription))]
        public List<OM2MEsprimKeyGenAlgID> EsprimKeyGenAlgIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("esprimProtocolAndAlgIDs", typeof(OM2MEsprimProtocolAndAlgIDsDescription))]
        public List<OM2MEsprimProtocolAndAlgID> EsprimProtocolAndAlgIDs
        {
            get;
            set;
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MEsprimKeyGenAlgID))]
        public class OM2MEsprimKeyGenAlgIDsDescription : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MEsprimProtocolAndAlgID))]
        public class OM2MEsprimProtocolAndAlgIDsDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
    public partial class OM2MOriginatorESPrimRandObject
    {
        [OM2MXmlElement("esprimRandID")]
        public string EsprimRandID
        {
            get;
            set;
        }
        [OM2MXmlElement("esprimRandValue")]
        public string EsprimRandValue
        {
            get;
            set;
        }
        [OM2MXmlElement("esprimRandExpiry", typeof(OM2MAbsRelTimestampDescription))]
        public object EsprimRandExpiry
        {
            get;
            set;
        }
        [OM2MXmlElement("esprimKeyGenAlgIDs")]
        public OM2MEsprimKeyGenAlgID? EsprimKeyGenAlgIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("esprimProtocolAndAlgIDs", typeof(OM2MEsprimProtocolAndAlgIDsDescription))]
        public List<OM2MEsprimProtocolAndAlgID> EsprimProtocolAndAlgIDs
        {
            get;
            set;
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MEsprimProtocolAndAlgID))]
        public class OM2MEsprimProtocolAndAlgIDsDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
    public partial class OM2ME2eSecInfo
    {
        [OM2MXmlElement("supportedE2ESecFeatures", typeof(OM2MSupportedE2ESecFeaturesDescription))]
        public List<OM2MSuid> SupportedE2ESecFeatures
        {
            get;
            set;
        }
        [OM2MXmlElement("certificates", typeof(OM2MCertificatesDescription))]
        public List<object> Certificates
        {
            get;
            set;
        }
        [OM2MXmlElement("sharedReceiverESPrimRandObject")]
        public OM2MReceiverESPrimRandObject SharedReceiverESPrimRandObject
        {
            get;
            set;
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MSuid))]
        public class OM2MSupportedE2ESecFeaturesDescription : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(object))]
        public class OM2MCertificatesDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
    public partial class OM2MTokenPermission
    {
        [OM2MXmlElement("resourceIDs", typeof(OM2MListOfM2MIDDescription))]
        public List<string> ResourceIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("privileges", "pv")]
        public OM2MSetOfAcrs Privileges
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
        [OM2MXsdSimpleListType(null, typeof(OM2MRoleIDDescription))]
        public class OM2MRoleIDsDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
    public partial class OM2MTokenPermissions
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MTokenPermission))]
        public class OM2MTokenPermissions_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("permission", typeof(OM2MTokenPermissions_Property0Description))]
        public List<OM2MTokenPermission> Permission
        {
            get;
            set;
        }
    }
    public partial class OM2MTokenClaimSet
    {
        [OM2MXmlElement("version", "vr")]
        public string Version
        {
            get;
            set;
        }
        [OM2MXmlElement("tokenID", typeof(OM2MTokenIDDescription))]
        public string TokenID
        {
            get;
            set;
        }
        [OM2MXmlElement("holder", typeof(OM2MIDDescription))]
        public string Holder
        {
            get;
            set;
        }
        [OM2MXmlElement("issuer", typeof(OM2MIDDescription))]
        public string Issuer
        {
            get;
            set;
        }
        [OM2MXmlElement("notBefore", typeof(OM2MTimestampDescription))]
        public string NotBefore
        {
            get;
            set;
        }
        [OM2MXmlElement("notAfter", typeof(OM2MTimestampDescription))]
        public string NotAfter
        {
            get;
            set;
        }
        [OM2MXmlElement("tokenName")]
        public string TokenName
        {
            get;
            set;
        }
        [OM2MXmlElement("audience", typeof(OM2MListOfM2MIDDescription))]
        public List<string> Audience
        {
            get;
            set;
        }
        [OM2MXmlElement("permissions")]
        public OM2MTokenPermissions Permissions
        {
            get;
            set;
        }
        [OM2MXmlElement("extension")]
        public string Extension
        {
            get;
            set;
        }
    }
    public partial class OM2MDynAuthLocalTokenIdAssignments
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MLocalTokenIdAssignment))]
        public class OM2MDynAuthLocalTokenIdAssignments_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("localTokenIdAssignment", typeof(OM2MDynAuthLocalTokenIdAssignments_Property0Description))]
        public List<OM2MLocalTokenIdAssignment> LocalTokenIdAssignment
        {
            get;
            set;
        }
        public partial class OM2MLocalTokenIdAssignment
        {
            [OM2MXmlElement("localTokenID")]
            public string LocalTokenID
            {
                get;
                set;
            }
            [OM2MXmlElement("tokenID", typeof(OM2MTokenIDDescription))]
            public string TokenID
            {
                get;
                set;
            }
        }
    }
    public partial class OM2MDynAuthTokenSummary
    {
        [OM2MXmlElement("tokenID", typeof(OM2MTokenIDDescription))]
        public string TokenID
        {
            get;
            set;
        }
        [OM2MXmlElement("notBefore", typeof(OM2MTimestampDescription))]
        public string NotBefore
        {
            get;
            set;
        }
        [OM2MXmlElement("notAfter", typeof(OM2MTimestampDescription))]
        public string NotAfter
        {
            get;
            set;
        }
        [OM2MXmlElement("tokenName")]
        public string TokenName
        {
            get;
            set;
        }
        [OM2MXmlElement("audience", typeof(OM2MListOfM2MIDDescription))]
        public List<string> Audience
        {
            get;
            set;
        }
    }
    public partial class OM2MDynAuthTokenReqInfo
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MDasInfo))]
        public class OM2MDynAuthTokenReqInfo_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("dasInfo", typeof(OM2MDynAuthTokenReqInfo_Property0Description))]
        public List<OM2MDasInfo> DasInfo
        {
            get;
            set;
        }
        public partial class OM2MDasInfo
        {
            [OM2MXmlElement("URI")]
            public string URI
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
            [OM2MXmlElement("securedDasRequest", typeof(OM2MDynAuthJWTDescription))]
            public string SecuredDasRequest
            {
                get;
                set;
            }
        }
    }
    public partial class OM2MDynAuthDasRequest
    {
        [OM2MXmlElement("originator", "org", typeof(OM2MIDDescription))]
        public string Originator
        {
            get;
            set;
        }
        [OM2MXmlElement("targetedResourceType")]
        public OM2MResourceType? TargetedResourceType
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
        [OM2MXmlElement("originatorIP")]
        public OM2MOriginatorIP OriginatorIP
        {
            get;
            set;
        }
        [OM2MXmlElement("originatorLocation")]
        public OM2MLocationRegion OriginatorLocation
        {
            get;
            set;
        }
        [OM2MXmlElement("originatorRoleIDs", typeof(OM2MOriginatorRoleIDsDescription))]
        public List<string> OriginatorRoleIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("requestTimestamp", typeof(OM2MAbsRelTimestampDescription))]
        public object RequestTimestamp
        {
            get;
            set;
        }
        [OM2MXmlElement("targetedResourceID")]
        public string TargetedResourceID
        {
            get;
            set;
        }
        [OM2MXmlElement("proposedPrivilegesLifetime", typeof(OM2MAbsRelTimestampDescription))]
        public object ProposedPrivilegesLifetime
        {
            get;
            set;
        }
        [OM2MXmlElement("roleIDsFromACPs", typeof(OM2MRoleIDsFromACPsDescription))]
        public List<string> RoleIDsFromACPs
        {
            get;
            set;
        }
        [OM2MXmlElement("tokenIDs", "tids", typeof(OM2MTokenIDsDescription))]
        public List<string> TokenIDs
        {
            get;
            set;
        }
        public partial class OM2MOriginatorIP
        {
            [OM2MXmlElement("ipv4Address", typeof(OM2MIpv4Description))]
            public string Ipv4Address
            {
                get;
                set;
            }
            [OM2MXmlElement("ipv6Address", typeof(OM2MIpv6Description))]
            public string Ipv6Address
            {
                get;
                set;
            }
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MRoleIDDescription))]
        public class OM2MOriginatorRoleIDsDescription : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MRoleIDDescription))]
        public class OM2MRoleIDsFromACPsDescription : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXsdSimpleListType(null, typeof(OM2MTokenIDDescription))]
        public class OM2MTokenIDsDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
    public partial class OM2MBackOffParameters
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MBackOffParametersSet))]
        public class OM2MBackOffParameters_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("backOffParametersSet", typeof(OM2MBackOffParameters_Property0Description))]
        public List<OM2MBackOffParametersSet> BackOffParametersSet
        {
            get;
            set;
        }
        public partial class OM2MBackOffParametersSet
        {
            [OM2MXmlElement("networkAction")]
            public OM2MNetworkAction? NetworkAction
            {
                get;
                set;
            }
            [OM2MXmlElement("initialBackoffTime")]
            public int? InitialBackoffTime
            {
                get;
                set;
            }
            [OM2MXmlElement("additionalBackoffTime")]
            public int? AdditionalBackoffTime
            {
                get;
                set;
            }
            [OM2MXmlElement("maximumBackoffTime")]
            public int? MaximumBackoffTime
            {
                get;
                set;
            }
            [OM2MXmlElement("optionalRandomBackoffTime")]
            public int? OptionalRandomBackoffTime
            {
                get;
                set;
            }
        }
    }
    public partial class OM2MListOfDataLinks
    {
        [OM2MXsdSimpleListType(null, typeof(OM2MDataLink))]
        public class OM2MListOfDataLinks_Property0Description : OM2MXsdSimpleListTypeDescription
        {
        }
        [OM2MXmlElement("dataLinkEntry", typeof(OM2MListOfDataLinks_Property0Description))]
        public List<OM2MDataLink> DataLinkEntry
        {
            get;
            set;
        }
    }
    public partial class OM2MDataLink
    {
        [OM2MXmlElement("name")]
        public string Name
        {
            get;
            set;
        }
        [OM2MXmlElement("dataContainerID", typeof(OM2MIDDescription))]
        public string DataContainerID
        {
            get;
            set;
        }
        [OM2MXmlElement("attributeName")]
        public string AttributeName
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("resource")]
    public partial class OM2MResource
    {
        [OM2MXmlAttribute("resourceName", "rn")]
        public string ResourceName
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
        [OM2MXmlElement("resourceID", "ri", typeof(OM2MIDDescription))]
        public string ResourceID
        {
            get;
            set;
        }
        [OM2MXmlElement("parentID", "pi", typeof(OM2MNhURIDescription))]
        public string ParentID
        {
            get;
            set;
        }
        [OM2MXmlElement("creationTime", "ct", typeof(OM2MTimestampDescription))]
        public string CreationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("lastModifiedTime", "lt", typeof(OM2MTimestampDescription))]
        public string LastModifiedTime
        {
            get;
            set;
        }
        [OM2MXmlElement("labels", "lbl", typeof(OM2MLabelsDescription))]
        public List<string> Labels
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("regularResource")]
    public partial class OM2MRegularResource : OM2MResource
    {
        [OM2MXmlElement("accessControlPolicyIDs", "acpi", typeof(OM2MAcpTypeDescription))]
        public List<string> AccessControlPolicyIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("expirationTime", "et", typeof(OM2MTimestampDescription))]
        public string ExpirationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("dynamicAuthorizationConsultationIDs", typeof(OM2MListOfURIsDescription))]
        public List<string> DynamicAuthorizationConsultationIDs
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("announceableResource")]
    public partial class OM2MAnnounceableResource : OM2MRegularResource
    {
        [OM2MXmlElement("announceTo", "at", typeof(OM2MListOfURIsDescription))]
        public List<string> AnnounceTo
        {
            get;
            set;
        }
        [OM2MXmlElement("announcedAttribute", "aa", typeof(OM2MAnnouncedAttributeDescription))]
        public List<string> AnnouncedAttribute
        {
            get;
            set;
        }
        [OM2MXsdSimpleListType(null, typeof(string))]
        public class OM2MAnnouncedAttributeDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
    [OM2MXmlRoot("announcedResource")]
    public partial class OM2MAnnouncedResource : OM2MResource
    {
        [OM2MXmlElement("accessControlPolicyIDs", "acpi", typeof(OM2MAcpTypeDescription))]
        public List<string> AccessControlPolicyIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("expirationTime", "et", typeof(OM2MTimestampDescription))]
        public string ExpirationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("link")]
        public string Link
        {
            get;
            set;
        }
        [OM2MXmlElement("dynamicAuthorizationConsultationIDs", typeof(OM2MListOfURIsDescription))]
        public List<string> DynamicAuthorizationConsultationIDs
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("announceableSubordinateResource")]
    public partial class OM2MAnnounceableSubordinateResource : OM2MResource
    {
        [OM2MXmlElement("expirationTime", "et", typeof(OM2MTimestampDescription))]
        public string ExpirationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("announceTo", "at", typeof(OM2MListOfURIsDescription))]
        public List<string> AnnounceTo
        {
            get;
            set;
        }
        [OM2MXmlElement("announcedAttribute", "aa", typeof(OM2MAnnouncedAttributeDescription))]
        public List<string> AnnouncedAttribute
        {
            get;
            set;
        }
        [OM2MXsdSimpleListType(null, typeof(string))]
        public class OM2MAnnouncedAttributeDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
    [OM2MXmlRoot("subordinateResource")]
    public partial class OM2MSubordinateResource : OM2MResource
    {
        [OM2MXmlElement("expirationTime", "et", typeof(OM2MTimestampDescription))]
        public string ExpirationTime
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("announcedSubordinateResource")]
    public partial class OM2MAnnouncedSubordinateResource : OM2MResource
    {
        [OM2MXmlElement("expirationTime", "et", typeof(OM2MTimestampDescription))]
        public string ExpirationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("link")]
        public string Link
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("mgmtResource")]
    public partial class OM2MMgmtResource : OM2MAnnounceableResource
    {
        [OM2MXmlElement("mgmtDefinition", "mgd")]
        public OM2MMgmtDefinition? MgmtDefinition
        {
            get;
            set;
        }
        [OM2MXmlElement("objectIDs", "obis", typeof(OM2MListOfURIsDescription))]
        public List<string> ObjectIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("objectPaths", "obps", typeof(OM2MListOfURIsDescription))]
        public List<string> ObjectPaths
        {
            get;
            set;
        }
        [OM2MXmlElement("description", "dc")]
        public string Description
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("announcedMgmtResource")]
    public partial class OM2MAnnouncedMgmtResource : OM2MAnnouncedResource
    {
        [OM2MXmlElement("mgmtDefinition", "mgd")]
        public OM2MMgmtDefinition? MgmtDefinition
        {
            get;
            set;
        }
        [OM2MXmlElement("objectIDs", "obis", typeof(OM2MListOfURIsDescription))]
        public List<string> ObjectIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("objectPaths", "obps", typeof(OM2MListOfURIsDescription))]
        public List<string> ObjectPaths
        {
            get;
            set;
        }
        [OM2MXmlElement("description", "dc")]
        public string Description
        {
            get;
            set;
        }
    }
    [OM2MXsdSimpleListType("listOfNCNames", typeof(string))]
    public class OM2MListOfNCNamesDescription : OM2MXsdSimpleListTypeDescription
    {
    }
    [OM2MXmlRoot("flexContainerResource")]
    public partial class OM2MFlexContainerResource
    {
        [OM2MXmlAttribute("resourceName", "rn")]
        public string ResourceName
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
        [OM2MXmlElement("resourceID", "ri", typeof(OM2MIDDescription))]
        public string ResourceID
        {
            get;
            set;
        }
        [OM2MXmlElement("parentID", "pi", typeof(OM2MNhURIDescription))]
        public string ParentID
        {
            get;
            set;
        }
        [OM2MXmlElement("creationTime", "ct", typeof(OM2MTimestampDescription))]
        public string CreationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("lastModifiedTime", "lt", typeof(OM2MTimestampDescription))]
        public string LastModifiedTime
        {
            get;
            set;
        }
        [OM2MXmlElement("labels", "lbl", typeof(OM2MLabelsDescription))]
        public List<string> Labels
        {
            get;
            set;
        }
        [OM2MXmlElement("accessControlPolicyIDs", "acpi", typeof(OM2MAcpTypeDescription))]
        public List<string> AccessControlPolicyIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("expirationTime", "et", typeof(OM2MTimestampDescription))]
        public string ExpirationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("dynamicAuthorizationConsultationIDs", typeof(OM2MListOfURIsDescription))]
        public List<string> DynamicAuthorizationConsultationIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("announceTo", "at", typeof(OM2MListOfURIsDescription))]
        public List<string> AnnounceTo
        {
            get;
            set;
        }
        [OM2MXmlElement("announcedAttribute", "aa", typeof(OM2MListOfNCNamesDescription))]
        public List<string> AnnouncedAttribute
        {
            get;
            set;
        }
        [OM2MXmlElement("stateTag", "st")]
        public int? StateTag
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
        [OM2MXmlElement("containerDefinition", "cnd")]
        public string ContainerDefinition
        {
            get;
            set;
        }
        [OM2MXmlElement("ontologyRef", "or")]
        public string OntologyRef
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("announcedFlexContainerResource")]
    public partial class OM2MAnnouncedFlexContainerResource
    {
        [OM2MXmlAttribute("resourceName", "rn")]
        public string ResourceName
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
        [OM2MXmlElement("resourceID", "ri", typeof(OM2MIDDescription))]
        public string ResourceID
        {
            get;
            set;
        }
        [OM2MXmlElement("parentID", "pi", typeof(OM2MNhURIDescription))]
        public string ParentID
        {
            get;
            set;
        }
        [OM2MXmlElement("creationTime", "ct", typeof(OM2MTimestampDescription))]
        public string CreationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("lastModifiedTime", "lt", typeof(OM2MTimestampDescription))]
        public string LastModifiedTime
        {
            get;
            set;
        }
        [OM2MXmlElement("labels", "lbl", typeof(OM2MLabelsDescription))]
        public List<string> Labels
        {
            get;
            set;
        }
        [OM2MXmlElement("accessControlPolicyIDs", "acpi", typeof(OM2MAcpTypeDescription))]
        public List<string> AccessControlPolicyIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("expirationTime", "et", typeof(OM2MTimestampDescription))]
        public string ExpirationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("link")]
        public string Link
        {
            get;
            set;
        }
        [OM2MXmlElement("dynamicAuthorizationConsultationIDs", typeof(OM2MListOfURIsDescription))]
        public List<string> DynamicAuthorizationConsultationIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("stateTag", "st")]
        public int? StateTag
        {
            get;
            set;
        }
        [OM2MXmlElement("containerDefinition", "cnd")]
        public string ContainerDefinition
        {
            get;
            set;
        }
        [OM2MXmlElement("ontologyRef", "or")]
        public string OntologyRef
        {
            get;
            set;
        }
    }
}
