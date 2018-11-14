using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BackgroundService.Domain.Entities;
using BackgroundService.Infrastructure.Interfaces;

namespace BackgroundService.Infrastructure.Repo
{
    public class SeriesEntryRepository : ISeriesEntryRepository
    {
        private readonly SeriesDbContext _context;

        public SeriesEntryRepository(SeriesDbContext seriesDbContext)
        {
            _context = seriesDbContext;
        }

        public IQueryable<SeriesEntry> Get()
        {
            return _context.Entries;
        }

        public async Task<bool> CreateAsync(SeriesEntry entity)
        {
            _context.Entries.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(SeriesEntry entity)
        {
            var series = await _context.Entries.FirstOrDefaultAsync(m => m.Id == entity.Id);
            if (series == null) return false;

            _context.Entry(series).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
