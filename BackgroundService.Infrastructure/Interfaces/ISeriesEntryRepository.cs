using System.Linq;
using System.Threading.Tasks;
using BackgroundService.Domain.Entities;

namespace BackgroundService.Infrastructure.Interfaces
{
    public interface ISeriesEntryRepository
    {
        IQueryable<SeriesEntry> Get();

        Task<bool> CreateAsync(SeriesEntry entity);

        Task<bool> UpdateAsync(SeriesEntry entity);
    }
}
