using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TradingPostDataExtractor
{
    public static class PriceDataUploader
    {
        private static readonly HttpClient _httpClient = new();
        private const string _url = "https://app2.gaming.tools";

        public static async Task Upload(string json, string region, string server)
        {
            using var form = new MultipartFormDataContent();
            using var fileContent = new ByteArrayContent(Encoding.UTF8.GetBytes(json));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            form.Add(fileContent, "file", "prices.json");
            form.Add(new StringContent(region), "region");
            form.Add(new StringContent(server), "server");
            try
            {
                await _httpClient.PostAsync($"{_url}/prices/price-database", form);
            }
            catch (Exception)
            {
            }
        }

    }
}
