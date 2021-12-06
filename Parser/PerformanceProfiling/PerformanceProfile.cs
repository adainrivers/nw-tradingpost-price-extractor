using System;

namespace Parser.PerformanceProfiling
{
    internal class PerformanceProfile
    {
        private int _executionCount;
        private double _totalMilliseconds;
        private DateTimeOffset _startTime;
        private double _maxMilliseconds;

        internal PerformanceProfile()
        {
        }

        internal void Start()
        {
            _executionCount++;
            _startTime = DateTimeOffset.UtcNow;
        }

        internal void Stop()
        {
            var elapsed = (DateTimeOffset.UtcNow - _startTime).TotalMilliseconds;
            _maxMilliseconds = Math.Max(_maxMilliseconds, elapsed);
            _totalMilliseconds += elapsed;
        }

        internal int ExecutionCount => _executionCount;
        internal double MaxMilliseconds => _maxMilliseconds;
        internal double TotalMilliseconds => _totalMilliseconds;
    }
}
