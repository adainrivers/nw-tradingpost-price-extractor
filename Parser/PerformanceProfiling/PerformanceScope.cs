using System;

namespace Parser.PerformanceProfiling
{
    public class PerformanceScope : IDisposable
    {
        private readonly IPerformanceProfiler _profiler;
        private readonly string _profileName;

        public PerformanceScope(IPerformanceProfiler profiler, string profileName)
        {
            _profiler = profiler;
            _profileName = profileName;
            profiler.Start(profileName);
        }

        public void Dispose()
        {
            _profiler.Stop(_profileName);
        }
    }
}