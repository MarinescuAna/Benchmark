namespace BenchmarkRunner.Entities
{
    public sealed class IntermediaryResult
    {
        // Gets the amount of physical memory, in bytes, allocated for the associated process.
        public required long WorkingSet64 { get; init; }
        // Gets the maximum amount of memory in the virtual memory paging file, in bytes, used by the associated process.
        public required long PagedMemorySize64 { get; init; }
        // Gets the maximum amount of virtual memory, in bytes, used by the associated process.
        public required long VirtualMemorySize64 { get; init; }
        // The amount of time that the associated process has spent running code inside the application portion of the process (not inside the operating system core).
        public required TimeSpan UserProcessorTime { get; init; }
        // The amount of time that the process has spent running code inside the operating system core.
        public required TimeSpan PrivilegedProcessorTime { get; init; }
        // The amount of time that the associated process has spent utilizing the CPU. This value is the sum of the UserProcessorTime and the PrivilegedProcessorTime.
        // Gets the maximum amount of physical memory, in bytes, used by the associated process.
        public required long PeakWorkingSet64 { get; init; }
        // Gets the maximum amount of memory in the virtual memory paging file, in bytes, used by the associated process.
        public required long PeakPagedMemorySize64 { get; init; }
        // Gets the maximum amount of virtual memory, in bytes, used by the associated process.
        public required long PeakVirtualMemorySize64 { get; init; }
        public override string ToString() =>
            $"\tPhysical memory usage : {WorkingSet64} MG\n" +
            $"\tPaged memory usage : {PagedMemorySize64} MG\n" +
            $"\tVirtual memory usage : {VirtualMemorySize64} MG\n" +
            $"\tUser processor time : {UserProcessorTime.Milliseconds} ms\n" +
            $"\tPeak physical memory usage : {PeakWorkingSet64} MS\n" +
            $"\tPeak paged memory usage : {PeakPagedMemorySize64} MS\n" +
            $"\tPeak virtual memory usage : {PeakVirtualMemorySize64} MS\n" +
            $"\tPrivileged processor time : {PrivilegedProcessorTime.Milliseconds} ms\n";
    }
}
