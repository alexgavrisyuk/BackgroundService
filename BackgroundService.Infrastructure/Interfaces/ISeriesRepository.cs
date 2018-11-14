using System.Linq;
using System.Threading.Tasks;
using BackgroundService.Domain.Entities;

namespace BackgroundService.Infrastructure.Interfaces
{
    public interface ISeriesRepository
    {
        IQueryable<Series> Get();

        Task<bool> CreateAsync(Series entity);

        Task<bool> UpdateAsync(Series entity);
    }
}
