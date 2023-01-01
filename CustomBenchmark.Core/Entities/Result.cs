using System.Diagnostics;

namespace BenchmarkRunner.Entities
{
    public sealed class Result
    {
        public TimeSpan TotalProcessorTime { get; set; }
        public ProcessResult? ProcessResult { get; set; }
        public Dictionary<string, Stopwatch>? TimeResults { get; set; } = new();
        public List<string>? OtherMessages { get; set; }
    }
}
