namespace Parser.PerformanceProfiling
{
    public class PerformanceValue
    {
        public PerformanceValue(double maxMilliseconds, double totalMilliseconds, int executionsCount)
        {
            MaxMilliseconds = maxMilliseconds;
            TotalMilliseconds = totalMilliseconds;
            ExecutionsCount = executionsCount;
        }
        public double MaxMilliseconds { get; }
        public double TotalMilliseconds { get; }
        public int ExecutionsCount { get; }
        public double AverageMilliseconds => TotalMilliseconds / ExecutionsCount;
    }
}