using System.Linq;
using TradingPostDataExtractor.Models;
using TradingPostDataExtractor.PerformanceProfiling;

namespace TradingPostDataExtractor
{
    public class RawPriceDataParser
    {
        public bool TryParse(RawPriceData rawPriceData, out PriceData priceData)
        {
            PerformanceProfiler.Current?.Start("PriceDataParser.Parse");
            priceData = null;

            if (string.IsNullOrWhiteSpace(rawPriceData.ItemName) || string.IsNullOrWhiteSpace(rawPriceData.Availability) ||
                string.IsNullOrWhiteSpace(rawPriceData.Price))
            {
                PerformanceProfiler.Current?.Stop("PriceDataParser.Parse");
                return false;
            }


            var priceStr = rawPriceData.Price.Replace(",", string.Empty).Replace(".", "");

            if (priceStr == string.Empty)
            {
                PerformanceProfiler.Current?.Stop("PriceDataParser.Parse");
                return false;
            }

            var wholeStr = priceStr.Substring(0, priceStr.Length - 2);
            var fractionStr = priceStr.Substring(priceStr.Length - 2, 2);

            if (!int.TryParse(wholeStr, out var whole) || !int.TryParse(fractionStr, out var fraction))
            {
                PerformanceProfiler.Current?.Stop("PriceDataParser.Parse");
                return false;
            }

            var price = whole + (decimal)fraction / 100;

            if (!int.TryParse(rawPriceData.Availability.Trim(), out var availability))
            {
                PerformanceProfiler.Current?.Stop("PriceDataParser.Parse");
                return false;
            }

            int? gearScoreResult = null;
            if (!string.IsNullOrWhiteSpace(rawPriceData.GearScore) && int.TryParse(rawPriceData.GearScore.Trim(), out var gearScore) && gearScore >= 100)
            {
                gearScoreResult = gearScore;
            }


            var item = ItemFinder.GetItem(rawPriceData.ItemName, gearScoreResult);
            if (item == null)
            {
                return false;
            }
            priceData = new PriceData { ItemId = item.Id, ItemName = item.Name, Price = price, Availability = availability, GearScore = gearScoreResult };

            PerformanceProfiler.Current?.Stop("PriceDataParser.Parse");
            return true;
        }
    }
}
