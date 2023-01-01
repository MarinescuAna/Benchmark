using BenchmarkRunner.Entities;
using System.Diagnostics;

namespace CustomBenchmark.Core.Helpers
{
    public static class CollectorHelper
    {
        public static ProcessResult? CollectTemporaryData(Process process) => !process.HasExited ? new ProcessResult()
        {
            WorkingSet64 =(float) process.WorkingSet64 / 1024 / 1024,
            PagedMemorySize64 = process.PagedMemorySize64 / 1024 / 1024,
            UserProcessorTime = process.UserProcessorTime,
            PeakWorkingSet64 = process.PeakWorkingSet64 / 1024 / 1024,
            PeakPagedMemorySize64 = process.PeakPagedMemorySize64 / 1024 / 1024,
            PrivilegedProcessorTime = process.PrivilegedProcessorTime,
        } : null;
    }
}