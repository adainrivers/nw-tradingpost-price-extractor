using System.Collections.Generic;

namespace Parser.PerformanceProfiling
{
    public interface IPerformanceProfiler
    {
        void Start(string profileName);
        void Stop(string profileName);
        Dictionary<string, PerformanceValue> GetProfiles();
    }
}