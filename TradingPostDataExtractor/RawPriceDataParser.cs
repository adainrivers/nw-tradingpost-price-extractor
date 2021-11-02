using System.Linq;

namespace TradingPostDataExtractor
{
    public class RawPriceDataParser
    {
        public bool TryParse(RawPriceData rawPriceData, out PriceData priceData)
        {
            if (string.IsNullOrWhiteSpace(rawPriceData.ItemName) || string.IsNullOrWhiteSpace(rawPriceData.Availability) ||
                string.IsNullOrWhiteSpace(rawPriceData.Price))
            {
                priceData = null;
                return false;
            }


            var priceStr = rawPriceData.Price.Replace(",", string.Empty).Replace(".", "");

            priceStr = $"{new string(priceStr.Take(priceStr.Length - 2).ToArray())},{new string(priceStr.Skip(priceStr.Length - 2).Take(2).ToArray())}";
            if (!decimal.TryParse(priceStr, out var price))
            {
                priceData = null;
                return false;
            }

            if (!int.TryParse(rawPriceData.Availability.Trim(), out var availability))
            {
                priceData = null;
                return false;
            }

            priceData = new PriceData {ItemName = rawPriceData.ItemName, Price = price, Availability = availability};

            return true;
        }
    }
}
