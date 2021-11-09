using System.Collections.Generic;

namespace TradingPostDataExtractor.Models
{
    public class TradingPostItem
    {
        public string Id { get; set; }
        public int? GS { get; set; }
        public int? MinGS { get; set; }
        public int? MaxGS { get; set; }
        public int Tier { get; set; }
        public int Rarity { get; set; }
        public List<string> Names { get; set; }
    }
}