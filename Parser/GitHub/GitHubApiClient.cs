using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Parser.GitHub.Models;

namespace Parser.GitHub
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
                HttpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("Not Chrome Sorry");
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
