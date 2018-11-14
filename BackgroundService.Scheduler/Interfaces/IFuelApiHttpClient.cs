using System.Threading.Tasks;
using BackgroundService.Scheduler.FuelApiResponseModels;

namespace BackgroundService.Scheduler.Interfaces
{
    public interface IFuelApiHttpClient
    {
        Task<FuelApiResponseModel> ReadPriceAsync();
    }
}
