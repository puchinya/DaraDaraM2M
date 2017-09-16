using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("group","grp")]
    public partial class OM2MGroup : OM2MAnnounceableResource
    {
        [OM2MXmlElement("creator", "cr", typeof(OM2MIDDescription))]
        public string Creator
        {
            get;
            set;
        }
        [OM2MXmlElement("memberType", "mt")]
        public OM2MMemberType? MemberType
        {
            get;
            set;
        }
        [OM2MXmlElement("currentNrOfMembers", "cnm")]
        public int? CurrentNrOfMembers
        {
            get;
            set;
        }
        [OM2MXmlElement("maxNrOfMembers", "mnm")]
        public int? MaxNrOfMembers
        {
            get;
            set;
        }
        [OM2MXmlElement("memberIDs", "mid", typeof(OM2MListOfURIsDescription))]
        public List<string> MemberIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("membersAccessControlPolicyIDs", "macp", typeof(OM2MListOfURIsDescription))]
        public List<string> MembersAccessControlPolicyIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("memberTypeValidated", "mtv")]
        public bool? MemberTypeValidated
        {
            get;
            set;
        }
        [OM2MXmlElement("consistencyStrategy", "csy")]
        public OM2MConsistencyStrategy? ConsistencyStrategy
        {
            get;
            set;
        }
        [OM2MXmlElement("groupName", "gn")]
        public string GroupName
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
        [OM2MXmlElement("semanticDescriptor", "smd", typeof(OM2MSemanticDescriptor))]
        public List<OM2MSemanticDescriptor> SemanticDescriptor
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("groupAnnc","grpA")]
    public partial class OM2MGroupAnnc : OM2MAnnouncedResource
    {
        [OM2MXmlElement("memberType", "mt")]
        public OM2MMemberType? MemberType
        {
            get;
            set;
        }
        [OM2MXmlElement("currentNrOfMembers", "cnm")]
        public int? CurrentNrOfMembers
        {
            get;
            set;
        }
        [OM2MXmlElement("maxNrOfMembers", "mnm")]
        public int? MaxNrOfMembers
        {
            get;
            set;
        }
        [OM2MXmlElement("memberIDs", "mid", typeof(OM2MMemberIDsDescription))]
        public List<string> MemberIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("membersAccessControlPolicyIDs", "macp", typeof(OM2MListOfURIsDescription))]
        public List<string> MembersAccessControlPolicyIDs
        {
            get;
            set;
        }
        [OM2MXmlElement("memberTypeValidated", "mtv")]
        public bool? MemberTypeValidated
        {
            get;
            set;
        }
        [OM2MXmlElement("consistencyStrategy", "csy")]
        public OM2MConsistencyStrategy? ConsistencyStrategy
        {
            get;
            set;
        }
        [OM2MXmlElement("groupName", "gn")]
        public string GroupName
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
        [OM2MXmlElement("semanticDescriptor", "smd", typeof(OM2MSemanticDescriptor))]
        public List<OM2MSemanticDescriptor> SemanticDescriptor
        {
            get;
            set;
        }
        [OM2MXmlElement("semanticDescriptorAnnc", "smdA", typeof(OM2MSemanticDescriptorAnnc))]
        public List<OM2MSemanticDescriptorAnnc> SemanticDescriptorAnnc
        {
            get;
            set;
        }
        [OM2MXsdSimpleListType(null, typeof(string))]
        public class OM2MMemberIDsDescription : OM2MXsdSimpleListTypeDescription
        {
        }
    }
}
