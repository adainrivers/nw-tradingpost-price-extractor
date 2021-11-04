using System.Collections.Generic;

namespace TradingPostDataExtractor
{
    public class DebugInfo
    {
        public string NewWorldGameWindowDimensions { get; set; }
        public List<RawPriceData> RawPriceData { get; set; }
        public List<RawPriceData> InvalidPriceData { get; set; }
    }
}