using System;
using System.Collections.Generic;

namespace DaraDaraM2M.Data
{
    [OM2MXmlRoot("timeSeriesInstance","tsi")]
    public partial class OM2MTimeSeriesInstance : OM2MAnnounceableSubordinateResource
    {
        [OM2MXmlElement("dataGenerationTime", typeof(OM2MAbsRelTimestampDescription))]
        public object DataGenerationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("content", "con")]
        public object Content
        {
            get;
            set;
        }
        [OM2MXmlElement("sequenceNr")]
        public int? SequenceNr
        {
            get;
            set;
        }
    }
    [OM2MXmlRoot("timeSeriesInstanceAnnc","tsia")]
    public partial class OM2MTimeSeriesInstanceAnnc : OM2MAnnouncedSubordinateResource
    {
        [OM2MXmlElement("dataGenerationTime", typeof(OM2MAbsRelTimestampDescription))]
        public object DataGenerationTime
        {
            get;
            set;
        }
        [OM2MXmlElement("content", "con")]
        public object Content
        {
            get;
            set;
        }
        [OM2MXmlElement("sequenceNr")]
        public int? SequenceNr
        {
            get;
            set;
        }
    }
}
