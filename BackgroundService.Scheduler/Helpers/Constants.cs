namespace BackgroundService.Scheduler.Helpers
{
    public class Constants
    {
        public const int DefaultDaysIntervalLoadPrice = 7;

        public const string LoadPriceUrl =
            "http://api.eia.gov/series/?api_key=ec92aacd6947350dcb894062a4ad2d08&series_id=PET.EMD_EPD2D_PTE_NUS_DPG.W";

        public const int DefaultDaysCount = 10;
    }
}
