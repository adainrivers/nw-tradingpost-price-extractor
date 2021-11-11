using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TradingPostDataExtractor.GitHub.Models;

namespace TradingPostDataExtractor.GitHub
{
    public class GitHubApiClient
    {
        private static readonly HttpClient HttpClient = new();

        private const string ReleaseApiUrl =
            "https://api.github.com/repos/adainrivers/nw-tradingpost-price-extractor/releases";

        public static async Task<Release> GetLatestReleaseAsync()
        {
            try
            {
                HttpClient.Timeout = TimeSpan.FromSeconds(3);
                HttpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("AdainRivers' New World Trading Post Price Extractor");
                var json = await HttpClient.GetStringAsync(ReleaseApiUrl);
                return JsonConvert.DeserializeObject<List<Release>>(json)?.OrderByDescending(r => r.PublishedAt).FirstOrDefault();

            }
            catch (Exception)
            {
                return null;
            }
        }

        public static int GetNumericReleaseNumber(Release release)
        {
            return VersionNumberHelper.GetNumericVersionNumber(release.TagName);
        }
    }
}
