using System.Data.Entity;
using BackgroundService.Domain.Entities;
using BackgroundService.Infrastructure.Configurations;

namespace BackgroundService.Infrastructure
{
    public class SeriesDbContext : DbContext
    {
        public SeriesDbContext()
            : base("SeriesDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new SeriesEntityConfiguration());
            modelBuilder.Configurations.Add(new SeriesEntryEntityConfiguration());
        }

        public DbSet<Series> Series { get; set; }
        
        public DbSet<SeriesEntry> Entries { get; set; }
    }
}
