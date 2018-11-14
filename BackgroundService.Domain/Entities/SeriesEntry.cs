namespace BackgroundService.Domain.Entities
{
    public class SeriesEntry
    {
        public long Id { get; set; }
        
        public string Date { get; set; }

        public decimal Price { get; set; }

        public string SeriesId { get; set; }
        public Series Series { get; set; }
    }
}
