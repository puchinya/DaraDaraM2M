using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("genericInterworkingOperationInstance","gio")]
    public partial class OM2MGenericInterworkingOperationInstance : OM2MFlexContainerResource
    {
        [OM2MXmlElement("operationName")]
        public string OperationName
        {
            get;
            set;
        }
        [OM2MXmlElement("operationState")]
        public string OperationState
        {
            get;
            set;
        }
        [OM2MXmlElement("inputDataPointLinks")]
        public OM2MListOfDataLinks InputDataPointLinks
        {
            get;
            set;
        }
        [OM2MXmlElement("outputDataPointLinks")]
        public OM2MListOfDataLinks OutputDataPointLinks
        {
            get;
            set;
        }
        [OM2MXmlElement("inputLinks")]
        public OM2MListOfDataLinks InputLinks
        {
            get;
            set;
        }
        [OM2MXmlElement("outputLinks")]
        public OM2MListOfDataLinks OutputLinks
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
        [OM2MXmlElement("semanticDescriptor", "smd", typeof(OM2MSemanticDescriptor))]
        public List<OM2MSemanticDescriptor> SemanticDescriptor
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
    [OM2MXmlRoot("genericInterworkingOperationInstanceAnnc","gioa")]
    public partial class OM2MGenericInterworkingOperationInstanceAnnc : OM2MAnnouncedFlexContainerResource
    {
        [OM2MXmlElement("operationName")]
        public string OperationName
        {
            get;
            set;
        }
        [OM2MXmlElement("operationState")]
        public string OperationState
        {
            get;
            set;
        }
        [OM2MXmlElement("inputDataPointLinks")]
        public OM2MListOfDataLinks InputDataPointLinks
        {
            get;
            set;
        }
        [OM2MXmlElement("outputDataPointLinks")]
        public OM2MListOfDataLinks OutputDataPointLinks
        {
            get;
            set;
        }
        [OM2MXmlElement("inputLinks")]
        public OM2MListOfDataLinks InputLinks
        {
            get;
            set;
        }
        [OM2MXmlElement("outputLinks")]
        public OM2MListOfDataLinks OutputLinks
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
        [OM2MXmlElement("subscription", "sub", typeof(OM2MSubscription))]
        public List<OM2MSubscription> Subscription
        {
            get;
            set;
        }
    }
}
