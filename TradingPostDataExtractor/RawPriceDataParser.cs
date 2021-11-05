using System.Linq;
using TradingPostDataExtractor.PerformanceProfiling;

namespace TradingPostDataExtractor
{
    public class RawPriceDataParser
    {
        public bool TryParse(RawPriceData rawPriceData, out PriceData priceData)
        {
            PerformanceProfiler.Current?.Start("PriceDataParser.Parse");
            if (string.IsNullOrWhiteSpace(rawPriceData.ItemName) || string.IsNullOrWhiteSpace(rawPriceData.Availability) ||
                string.IsNullOrWhiteSpace(rawPriceData.Price))
            {
                priceData = null;
                PerformanceProfiler.Current?.Stop("PriceDataParser.Parse");
                return false;
            }


            var priceStr = rawPriceData.Price.Replace(",", string.Empty).Replace(".", "");

            priceStr = $"{new string(priceStr.Take(priceStr.Length - 2).ToArray())},{new string(priceStr.Skip(priceStr.Length - 2).Take(2).ToArray())}";
            if (!decimal.TryParse(priceStr, out var price))
            {
                priceData = null;
                PerformanceProfiler.Current?.Stop("PriceDataParser.Parse");
                return false;
            }

            if (!int.TryParse(rawPriceData.Availability.Trim(), out var availability))
            {
                priceData = null;
                PerformanceProfiler.Current?.Stop("PriceDataParser.Parse");
                return false;
            }

            var name = ItemNameFixer.GetFixedName(rawPriceData.ItemName);

            priceData = new PriceData {ItemName = name, Price = price, Availability = availability};

            PerformanceProfiler.Current?.Stop("PriceDataParser.Parse");
            return true;
        }
    }
}
