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
            TerritoryFinder.Initialize();
        }

        [Theory]
        [ClassData(typeof(ImageParserTestData))]
        public async Task FullImageTest(string imageFileName, string[] itemIds, decimal[] prices = null, int?[] gearScores = null, int[] availability = null, string[] locations = null)
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


            if (itemIds != null)
            {
                for (var i = 0; i < parsedResults.Count; i++)
                {
                    Assert.True(itemIds[i] == parsedResults[i].ItemId, $"ItemId Expected: {itemIds[i]}, Actual: {parsedResults[i].ItemId}");
                }
            }
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
            if (locations != null)
            {
                for (var i = 0; i < parsedResults.Count; i++)
                {
                    Assert.True(locations[i] == parsedResults[i].Location, $"Location Expected: {locations[i]}, Actual: {parsedResults[i].Location}");
                }
            }
        }

        public class ImageParserTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                    "image-001.png",
                    new [] { "ambert1", "ambert1", "ambert1", "ambert1", "ambert1", "ambert1", "ambert1", "ambert1", "ambert1"},
                    new [] { 195, 15, 15, 9.99m, 5.5m, 5.5m, 70, 28, 79 },
                    new int?[] { null, null, null, null, null, null, null, null, null },
                    new [] { 7, 5, 5, 5, 4, 4, 3, 3, 3 },
                    new [] { "Windsward", "Windsward", "Windsward", "Everfall", "Everfall", "Everfall",  "First Light", "Everfall", "Monarch's Bluffs" }
                };

                yield return new object[]
                {
                    "image-002.png",
                    new [] { "arrowbt4", "watert1", "watert1", "arrowbt4", "woodstaint5", "fibert1", "shott2", "woodt4", "rawhidet4"},
                    new [] { 0.9m, 0.03m, 0.03m, 0.9m, 0.05m, 0.15m, 0.01m, 0.1m, 0.6m },
                    new int?[] { null, null, null, null, null, null, null, null, null },
                    new [] { 11285, 10000, 10000, 7950, 6312, 3652, 3500, 3198, 2810 }
                };

                yield return new object[]
                {
                    "image-003.png",
                    null,
                    new [] { 0.24m, 0.25m, 0.26m, 0.28m, 0.30m, 0.50m, 0.60m, 0.70m, 0.70m },
                    new int?[] { null, null, null, null, null, null, null, null, null },
                    new [] { 72, 45, 54, 216, 170, 435, 393, 38, 41 }
                };

                yield return new object[]
                {
                    "image-004.png",
                    null,
                    new [] { 3m, 3.39m, 3.45m, 3.75m, 3.9m, 3.95m, 4m, 4m, 4.23m },
                    new int?[] { null, null, null, null, null, null, null, null, null },
                    new [] { 31, 4, 286, 9, 52, 30, 1, 300, 923}
                };

                yield return new object[]
                {
                    "image-005.jpg",
                    null,
                    new [] { 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m },
                    new int?[] { null, 200, 200, null, null, null, null, null, null },
                    new [] { 671, 27, 61, 340, 485, 395, 163, 140, 285 }
                };

                yield return new object[]
                {
                    "image-006.png",
                    null,
                    new [] { 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m, 0.01m },
                    new int?[] { null, 200, 100, 200, null, null, 200, null, 100 },
                    new [] { 860, 9, 38, 102, 1138, 75, 13, 1728, 100 }
                };

                yield return new object[]
                {
                    "image-007.png",
                    null,
                    new [] { 50m, 250, 85, 100, 79, 150, 100, 300, 130},
                    new int?[] { 494, 492, 489, 489, 488, 488, 488, 483, 481 },
                    new [] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
                };

                yield return new object[]
                {
                    "image-008.png",
                    null,
                    new [] { 0.03m, 0.03m, 0.03m, 0.03m, 0.03m, 0.03m, 0.03m, 0.03m, 0.03m},
                    new int?[] { null, 200, null, null, null, 200, null, null, null },
                    new [] { 2, 100, 323, 1428, 889, 43, 500, 500, 500 }
                };

                yield return new object[]
                {
                    "image-009.png",
                    null,
                    new [] { 10m, 10m, 10m, 10m, 10m, 10m, 10m, 10m, 10m },
                    new int?[] { 338, 272, 464, 337, 328, 332, 328, 339, 276 },
                    new [] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
                };


                yield return new object[]
                {
                    "image-010.png",
                    null,
                    new [] { 2.5m, 2.5m, 4m, 4m, 4.8m, 4.98m, 4.99m, 4.99m, 4.99m },
                    new int?[] { 350, 340,269, 271, 323, 369, 421, 327, 328 },
                    new [] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
                };

                yield return new object[]
                {
                    "image-011.png",
                    null,
                    new [] { 480, 980, 400, 200, 1480, 200, 580, 400, 700m },
                    new int?[] { 595, 591, 590, 589, 589, 588, 587, 585, 585 },
                    new [] { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
