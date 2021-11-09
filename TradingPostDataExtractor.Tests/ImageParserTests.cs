using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using TradingPostDataExtractor.Models;
using Xunit;

namespace TradingPostDataExtractor.Tests
{
    public class ImageParserTests
    {
        private const string TestImagesFolder = "TestImages";

        static ImageParserTests()
        {
            ItemFinder.Initialize();
        }

        [Theory]
        [ClassData(typeof(ImageParserTestData))]
        public async Task FullImageTest(string imageFileName, decimal[] prices = null, int?[] gearScores = null, int[] availability = null)
        {
            var imageParser = new ImageParser(true);
            var priceParser = new RawPriceDataParser();
            var testImagePath = Path.Combine(TestImagesFolder, imageFileName);
            using var image = Image.FromFile(testImagePath);
            var results = await imageParser.Parse("eng", image);

            var parsedResults = new List<PriceData>();
            foreach (var rawPriceData in results)
            {
                if (priceParser.TryParse(rawPriceData, out var priceData))
                {
                    parsedResults.Add(priceData);
                }
            }

            Assert.True(results.Count == parsedResults.Count, $"Parsed Result Count  Expected: {results.Count}, Actual: {parsedResults.Count}");

            if (prices != null)
            {
                for (var i = 0; i < parsedResults.Count; i++)
                {
                    Assert.True(prices[i] == parsedResults[i].Price, $"Price Expected: {prices[i]}, Actual: {parsedResults[i].Price}");
                }
            }
            if (gearScores != null)
            {
                for (var i = 0; i < parsedResults.Count; i++)
                {
                    Assert.True(gearScores[i] == parsedResults[i].GearScore, $"GearScore Expected: {gearScores[i]}, Actual: {parsedResults[i].GearScore}");
                }
            }
            if (availability != null)
            {
                for (var i = 0; i < parsedResults.Count; i++)
                {
                    Assert.True(availability[i] == parsedResults[i].Availability, $"Availability Expected: {availability[i]}, Actual: {parsedResults[i].Availability}");
                }
            }
        }

        public class ImageParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    "image-1.png",
                    new[] { 195, 15, 15, 9.99m, 5.5m, 5.5m, 70, 28, 79 },
                    new int?[] { null, null, null, null, null, null, null, null, null },
                    new[] { 7, 5, 5, 5, 4, 4, 3, 3, 3 }
                };

                yield return new object[]
                {
                    "image-2.png",
                    new[] { 0.9m, 0.03m, 0.03m, 0.9m, 0.05m, 0.15m, 0.01m, 0.1m, 0.6m },
                    new int?[] { null, null, null, null, null, null, null, null, null },
                    new[] { 11235, 10000, 10000, 7950, 6312, 3652, 3500, 3198, 2810 }
                };

                yield return new object[]
                {
                    "image-3.png",
                    new [] { 0.24m, 0.25m, 0.26m, 0.28m, 0.30m, 0.50m, 0.60m, 0.70m, 0.70m },
                    new int?[] { null, null, null, null, null, null, null, null, null },
                    new [] { 72, 45, 54, 216, 170, 435, 393, 38, 41 }
                };

                yield return new object[]
                {
                    "image-4.png",
                    new [] { 3m, 3.39m, 3.45m, 3.75m, 3.9m, 3.95m, 4m, 4m, 4.23m },
                    new int?[] { null, null, null, null, null, null, null, null, null },
                    new[] { 31, 41, 286, 9, 52, 30, 11, 300, 923}
                };

                yield return new object[]
                {
                    "image-5.jpg",
                    new[] { 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m },
                    new int?[] { null, 200, 200, null, null, null, null, null, null },
                    new[] { 671, 27, 61, 340, 485, 395, 163, 140, 285 }
                };

                yield return new object[]
                {
                    "image-6.png",
                    new[] { 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m },
                    new int?[] { null, 200, 100, 200, null, null, 200, null, 100 },
                    new[] { 860, 9, 38, 102, 1138, 75, 13, 1723, 100 }
                };

                yield return new object[]
                {
                    "image-7.png",
                    new[] { 50m, 250, 85, 100, 79, 150, 100, 300, 130},
                    new int?[] { 494, 492, 489, 489, 488, 488, 488, 483, 481 },
                    new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
