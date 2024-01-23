using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodaTimePlayground
{
    public class TimeZone
    {
        public string TimeZoneCode { get; set; } = string.Empty;

        public string TimeZoneName { get; set; } = string.Empty;

        public string TimeZoneCountryCode { get; set; } = string.Empty;

        public string TimeZoneCountryName { get; set; } = string.Empty;

        public decimal TimeZoneUTCOffset { get; set; }

        public decimal TimeZoneLatitude { get; set; }

        public decimal TimeZoneLongitude { get; set; }

        public string TimeZoneNotes { get; set; } = string.Empty;
    }
}
