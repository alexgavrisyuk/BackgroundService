using System;
using System.Collections.Generic;

namespace BackgroundService.Domain.Entities
{
    public class Series
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Units { get; set; }

        public string F { get; set; }

        public string UnitsShort { get; set; }

        public string Description { get; set; }

        public string Copyright { get; set; }

        public string Source { get; set; }

        public string Iso366 { get; set; }

        public string Geography { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public DateTime Updated { get; set; }

        public ICollection<SeriesEntry> Entries { get; set; }

        public void Update(string copyright, string description, string end, string f, string geography, string iso366,
            string name, string source, string start, string units, string unitsShort, DateTime updated)
        {
           Copyright = copyright;
           Description = description;
           End = end;
           F = f;
           Geography = geography;
           Iso366 = iso366;
           Name = name;
           Source = source;
           Start = start;
           Units = units;
           UnitsShort = unitsShort;
           Updated = updated;
        }
    }
}
