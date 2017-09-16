using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("execInstance","exin")]
    public partial class OM2MExecInstance : OM2MRegularResource
    {
        [OM2MXmlElement("execStatus", "exs")]
        public OM2MExecStatusType? ExecStatus
        {
            get;
            set;
        }
        [OM2MXmlElement("execResult", "exr")]
        public OM2MExecResultType? ExecResult
        {
            get;
            set;
        }
        [OM2MXmlElement("execDisable", "exd")]
        public bool? ExecDisable
        {
            get;
            set;
        }
        [OM2MXmlElement("execTarget", "ext", typeof(OM2MNodeIDDescription))]
        public string ExecTarget
        {
            get;
            set;
        }
        [OM2MXmlElement("execMode", "exm")]
        public OM2MExecModeType? ExecMode
        {
            get;
            set;
        }
        [OM2MXmlElement("execFrequency", "exf")]
        public DateTime? ExecFrequency
        {
            get;
            set;
        }
        [OM2MXmlElement("execDelay", "exy")]
        public DateTime? ExecDelay
        {
            get;
            set;
        }
        [OM2MXmlElement("execNumber", "exn")]
        public int? ExecNumber
        {
            get;
            set;
        }
        [OM2MXmlElement("execReqArgs", "exra")]
        public OM2MExecReqArgsListType ExecReqArgs
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
