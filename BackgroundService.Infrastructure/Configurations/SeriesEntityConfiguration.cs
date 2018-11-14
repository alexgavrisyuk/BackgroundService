using System.Data.Entity.ModelConfiguration;
using BackgroundService.Domain.Entities;

namespace BackgroundService.Infrastructure.Configurations
{
    public class SeriesEntityConfiguration : EntityTypeConfiguration<Series>
    {
        public SeriesEntityConfiguration()
        {
            this.ToTable("Series");

            this.HasKey(s => s.Id);
            
            this.HasMany<SeriesEntry>(g => g.Entries)
                .WithRequired(s => s.Series)
                .HasForeignKey(s => s.SeriesId);
        }
    }
}
