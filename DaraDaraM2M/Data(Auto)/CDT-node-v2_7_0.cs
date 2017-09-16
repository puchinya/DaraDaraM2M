using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("node","nod")]
    public partial class OM2MNode : OM2MAnnounceableResource
    {
        [OM2MXmlElement("nodeID", "ni", typeof(OM2MNodeIDDescription))]
        public string NodeID
        {
            get;
            set;
        }
        [OM2MXmlElement("hostedCSELink", "hcl", typeof(OM2MIDDescription))]
        public string HostedCSELink
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
        [OM2MXmlElement("memory", "mem", typeof(OM2MMemory))]
        public List<OM2MMemory> Memory
        {
            get;
            set;
        }
        [OM2MXmlElement("battery", "bat", typeof(OM2MBattery))]
        public List<OM2MBattery> Battery
        {
            get;
            set;
        }
        [OM2MXmlElement("areaNwkInfo", "ani", typeof(OM2MAreaNwkInfo))]
        public List<OM2MAreaNwkInfo> AreaNwkInfo
        {
            get;
            set;
        }
        [OM2MXmlElement("areaNwkDeviceInfo", "andi", typeof(OM2MAreaNwkDeviceInfo))]
        public List<OM2MAreaNwkDeviceInfo> AreaNwkDeviceInfo
        {
            get;
            set;
        }
        [OM2MXmlElement("firmware", "fwr", typeof(OM2MFirmware))]
        public List<OM2MFirmware> Firmware
        {
            get;
            set;
        }
        [OM2MXmlElement("software", "swr", typeof(OM2MSoftware))]
        public List<OM2MSoftware> Software
        {
            get;
            set;
        }
        [OM2MXmlElement("deviceInfo", "dvi", typeof(OM2MDeviceInfo))]
        public List<OM2MDeviceInfo> DeviceInfo
        {
            get;
            set;
        }
        [OM2MXmlElement("deviceCapability", "dvc", typeof(OM2MDeviceCapability))]
        public List<OM2MDeviceCapability> DeviceCapability
        {
            get;
            set;
        }
        [OM2MXmlElement("reboot", "rbo", typeof(OM2MReboot))]
        public List<OM2MReboot> Reboot
        {
            get;
            set;
        }
        [OM2MXmlElement("eventLog", "evl", typeof(OM2MEventLog))]
        public List<OM2MEventLog> EventLog
        {
            get;
            set;
        }
        [OM2MXmlElement("cmdhPolicy", "cmp", typeof(OM2MCmdhPolicy))]
        public List<OM2MCmdhPolicy> CmdhPolicy
        {
            get;
            set;
        }
        [OM2MXmlElement("activeCmdhPolicy", "acmp", typeof(OM2MActiveCmdhPolicy))]
        public List<OM2MActiveCmdhPolicy> ActiveCmdhPolicy
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
        [OM2MXmlElement("trafficPattern", "trpt", typeof(OM2MTrafficPattern))]
        public List<OM2MTrafficPattern> TrafficPattern
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("nodeAnnc","nodA")]
    public partial class OM2MNodeAnnc : OM2MAnnouncedResource
    {
        [OM2MXmlElement("nodeID", "ni", typeof(OM2MNodeIDDescription))]
        public string NodeID
        {
            get;
            set;
        }
        [OM2MXmlElement("hostedCSELink", "hcl", typeof(OM2MIDDescription))]
        public string HostedCSELink
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
        [OM2MXmlElement("memoryAnnc", "memA", typeof(OM2MMemoryAnnc))]
        public List<OM2MMemoryAnnc> MemoryAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("batteryAnnc", "batA", typeof(OM2MBatteryAnnc))]
        public List<OM2MBatteryAnnc> BatteryAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("areaNwkInfoAnnc", "aniA", typeof(OM2MAreaNwkInfoAnnc))]
        public List<OM2MAreaNwkInfoAnnc> AreaNwkInfoAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("areaNwkDeviceInfoAnnc", "andiA", typeof(OM2MAreaNwkDeviceInfoAnnc))]
        public List<OM2MAreaNwkDeviceInfoAnnc> AreaNwkDeviceInfoAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("firmwareAnnc", "fwrA", typeof(OM2MFirmwareAnnc))]
        public List<OM2MFirmwareAnnc> FirmwareAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("softwareAnnc", "swrA", typeof(OM2MSoftwareAnnc))]
        public List<OM2MSoftwareAnnc> SoftwareAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("deviceInfoAnnc", "dviA", typeof(OM2MDeviceInfoAnnc))]
        public List<OM2MDeviceInfoAnnc> DeviceInfoAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("deviceCapabilityAnnc", "dvcA", typeof(OM2MDeviceCapabilityAnnc))]
        public List<OM2MDeviceCapabilityAnnc> DeviceCapabilityAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("rebootAnnc", "rboA", typeof(OM2MRebootAnnc))]
        public List<OM2MRebootAnnc> RebootAnnc
        {
            get;
            set;
        }
        [OM2MXmlElement("eventLogAnnc", "evlA", typeof(OM2MEventLogAnnc))]
        public List<OM2MEventLogAnnc> EventLogAnnc
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
        [OM2MXmlElement("trafficPatternAnnc", "trptA", typeof(OM2MTrafficPatternAnnc))]
        public List<OM2MTrafficPatternAnnc> TrafficPatternAnnc
        {
            get;
            set;
        }
    }
}
