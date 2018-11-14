using System.Data.Entity.ModelConfiguration;
using BackgroundService.Domain.Entities;

namespace BackgroundService.Infrastructure.Configurations
{
    public class SeriesEntryEntityConfiguration : EntityTypeConfiguration<SeriesEntry>
    {
        public SeriesEntryEntityConfiguration()
        {
            this.ToTable("SeriesEntries");

            this.HasKey(s => s.Id);
        }
    }
}
