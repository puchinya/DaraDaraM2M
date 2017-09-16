using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("genericInterworkingService","gis ")]
    public partial class OM2MGenericInterworkingService : OM2MFlexContainerResource
    {
        [OM2MXmlElement("serviceName")]
        public string ServiceName
        {
            get;
            set;
        }
        [OM2MXmlElement("inputDataPointLinks", typeof(OM2MIDDescription))]
        public string InputDataPointLinks
        {
            get;
            set;
        }
        [OM2MXmlElement("outputDataPointLinks", typeof(OM2MPoaListDescription))]
        public List<string> OutputDataPointLinks
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
        [OM2MXmlElement("genericInterworkingService", "gis ", typeof(OM2MGenericInterworkingService))]
        public List<OM2MGenericInterworkingService> GenericInterworkingService
        {
            get;
            set;
        }
        [OM2MXmlElement("genericInterworkingOperationInstance", "gio", typeof(OM2MGenericInterworkingOperationInstance))]
        public List<OM2MGenericInterworkingOperationInstance> GenericInterworkingOperationInstance
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
    [OM2MXmlRoot("genericInterworkingServiceAnnc","gisa")]
    public partial class OM2MGenericInterworkingServiceAnnc : OM2MAnnouncedFlexContainerResource
    {
        [OM2MXmlElement("serviceName")]
        public string ServiceName
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
        [OM2MXmlElement("childResource", typeof(OM2MChildResourceRef))]
        public List<OM2MChildResourceRef> ChildResource
        {
            get;
            set;
        }
        [OM2MXmlElement("genericInterworkingServiceAnnc", "gisa", typeof(OM2MGenericInterworkingServiceAnnc))]
        public List<OM2MGenericInterworkingServiceAnnc> GenericInterworkingServiceAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("genericInterworkingOperationInstanceAnnc", "gioa", typeof(OM2MGenericInterworkingOperationInstanceAnnc))]
        public List<OM2MGenericInterworkingOperationInstanceAnnc> GenericInterworkingOperationInstanceAnnc
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
