using CustomBenchmark.Core.Entities;

namespace BenchmarkRunner.Entities
{
    public sealed class Result
    {
        public TimeSpan TotalProcessorTime { get; set; }
        public List<IntermediaryResult>? IntermediaryResults { get; set; }
        public List<TimeResult>? TimeResults { get; set; }
    }
}
