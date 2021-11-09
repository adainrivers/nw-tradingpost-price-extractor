using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TradingPostDataExtractor.Properties;

namespace TradingPostDataExtractor
{
    public static class Servers
    {
        private static List<Server> _servers;

        private static readonly Dictionary<string, string> Regions = new Dictionary<string, string>
        {
            {"AP Southeast", "ap-southeast-2"},
            {"EU Central", "eu-central-1"},
            {"SA East", "sa-east-1"},
            {"US East", "us-east-1"},
            {"US West", "us-west-2"},
            {"TEST", "test"},
        };

        public static List<string> GetRegions()
        {
            return Regions.Keys.ToList();
        }

        public static List<string> GetServers(string region)
        {
            var regionId = Regions[region];
            return _servers.Where(s => s.Region == regionId).Select(s => s.Name).OrderBy(s => s).ToList();
        }

        public static void Initialize()
        {
            var bytes = Resources.servers;
            if (bytes == null || bytes.Length <= 0)
            {
                return;
            }

            var json = Encoding.UTF8.GetString(bytes);
            _servers = JsonConvert.DeserializeObject<List<Server>>(json);

            _servers.Add(new Server{Name = "Test", Region = "test"});


        }

        private class Server
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("region")]
            public string Region { get; set; }
        }
    }
}
