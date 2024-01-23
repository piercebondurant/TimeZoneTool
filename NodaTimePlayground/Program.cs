using System;
using NodaTime;
using NodaTime.TimeZones;

namespace NodaTimePlayground
{
    class Program
    {
        public static void Main(string[] args)
        {
            var exporter = new NodaTimeZoneExporter();

            exporter.WriteTimeZonesToCsv("timezones.csv");
        }
    }
}