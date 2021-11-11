namespace TradingPostDataExtractor.Models
{
    public class ItemData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? GearScore { get; set; }
        public int? MinGearScore { get; set; }
        public int? MaxGearScore { get; set; }
        public int? Tier { get; set; }
    }
}