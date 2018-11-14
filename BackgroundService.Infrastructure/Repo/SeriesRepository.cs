using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BackgroundService.Domain.Entities;
using BackgroundService.Infrastructure.Interfaces;

namespace BackgroundService.Infrastructure.Repo
{
    public class SeriesRepository : ISeriesRepository
    {
        private readonly SeriesDbContext _context;

        public SeriesRepository(SeriesDbContext context)
        {
            _context = context;
        }

        public IQueryable<Series> Get()
        {
            return _context.Series;
        }

        public async Task<bool> CreateAsync(Series entity)
        {
            _context.Series.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Series entity)
        {
            var series = await _context.Series.FirstOrDefaultAsync(m => m.Id == entity.Id);
            if (series == null) return false;

            _context.Entry(series).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
