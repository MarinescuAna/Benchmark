using BenchmarkRunner.Entities;
using System.Diagnostics;

namespace CustomBenchmark.Core.Helpers
{
    public static class CollectorHelper
    {
        public static IntermediaryResult? CollectTemporaryData(Process process) => !process.HasExited ? new IntermediaryResult()
        {
            WorkingSet64 = process.WorkingSet64 / 1024 / 1024,
            PagedMemorySize64 = process.PagedMemorySize64 / 1024 / 1024,
            VirtualMemorySize64 = process.VirtualMemorySize64 / 1024 / 1024,
            UserProcessorTime = process.UserProcessorTime,
            PeakWorkingSet64 = process.PeakWorkingSet64 / 1024 / 1024,
            PeakPagedMemorySize64 = process.PeakPagedMemorySize64 / 1024 / 1024,
            PeakVirtualMemorySize64 = process.PeakVirtualMemorySize64 / 1024 / 1024,
            PrivilegedProcessorTime = process.PrivilegedProcessorTime,
        } : null;
    }
}