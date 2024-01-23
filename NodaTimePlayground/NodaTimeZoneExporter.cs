using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;
using NodaTime.TimeZones;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace NodaTimePlayground
{
    public class NodaTimeZoneExporter
    {
        public List<TimeZone> GetTzdbZoneLocations()
        {
            var tzList = TzdbDateTimeZoneSource.Default.ZoneLocations.ToList();
            var resultList = new List<TimeZone>();

            foreach(var item in tzList)
            {
                resultList.Add(new TimeZone
                {
                    TimeZoneName = item.ZoneId,
                    TimeZoneNotes = item.Comment,
                    TimeZoneCountryCode = item.CountryCode,
                    TimeZoneCountryName = item.CountryName,
                    TimeZoneLatitude = (decimal)item.Latitude,
                    TimeZoneLongitude = (decimal)item.Longitude,
                    TimeZoneCode = item.ZoneId,
                    TimeZoneUTCOffset = Math.Round(DateTimeZoneProviders.Tzdb[item.ZoneId].GetUtcOffset(new Instant()).ToTimeSpan().Hours +
                                        (decimal)DateTimeZoneProviders.Tzdb[item.ZoneId].GetUtcOffset(new Instant()).ToTimeSpan().Minutes / 60, 1)
                });
            }

            resultList.Sort((x, y) => x.TimeZoneUTCOffset.CompareTo(y.TimeZoneUTCOffset));

            return resultList;
        }

        public void WriteTimeZonesToCsv(string path)
        {
            var timeZoneLocations = GetTzdbZoneLocations();

            using(var streamWriter = new StreamWriter(path))
            using (var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csvWriter.WriteRecords(timeZoneLocations);
            }
        }

    }
}
