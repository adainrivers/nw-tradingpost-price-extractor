namespace TradingPostDataExtractor.Models
{
    public class PriceData
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Availability { get; set; }
        public int? GearScore { get; set; }
    }
}