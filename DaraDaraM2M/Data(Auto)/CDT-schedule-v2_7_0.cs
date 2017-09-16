using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("schedule","sch")]
    public partial class OM2MSchedule : OM2MAnnounceableSubordinateResource
    {
        [OM2MXmlElement("scheduleElement", "se")]
        public OM2MScheduleEntries ScheduleElement
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
    [OM2MXmlRoot("scheduleAnnc","schA")]
    public partial class OM2MScheduleAnnc : OM2MAnnouncedSubordinateResource
    {
        [OM2MXmlElement("scheduleElement", "se")]
        public OM2MScheduleEntries ScheduleElement
        {
            get;
            set;
        }
    }
}
