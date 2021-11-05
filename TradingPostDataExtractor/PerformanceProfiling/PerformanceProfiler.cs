using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace TradingPostDataExtractor.PerformanceProfiling
{
    public class PerformanceProfiler : IPerformanceProfiler
    {
        public static PerformanceProfiler Current { get; set; } = new PerformanceProfiler();

        private readonly ConcurrentDictionary<string, PerformanceProfile> _profiles = new();

        public void Start(string profileName)
        {
            GetOrAdd(profileName).Start();
        }

        public void Stop(string profileName)
        {
            GetOrAdd(profileName).Stop();
        }

        public Dictionary<string, PerformanceValue> GetProfiles()
        {
            return _profiles.ToDictionary(p =>
                p.Key,
                p => new PerformanceValue(
                    p.Value.MaxMilliseconds,
                    p.Value.TotalMilliseconds,
                    p.Value.ExecutionCount));
        }

        public PerformanceScope CreateScope(string profileName)
        {
            _profiles.TryRemove(profileName, out _);
            return new PerformanceScope(this, profileName);
        }

        private PerformanceProfile GetOrAdd(string profileName)
        {
            return _profiles.GetOrAdd(profileName, p => new PerformanceProfile());
        }

        public static PerformanceProfiler Instance { get; } = new PerformanceProfiler();
    }
}