namespace BenchmarkRunner.Entities
{
    public sealed class ProcessResult
    {
        // Gets the amount of physical memory, in bytes, allocated for the associated process.
        public required float WorkingSet64 { get; init; }
        // Gets the maximum amount of memory in the virtual memory paging file, in bytes, used by the associated process.
        public required float PagedMemorySize64 { get; init; }
        // The amount of time that the associated process has spent running code inside the application portion of the process (not inside the operating system core).
        public required TimeSpan UserProcessorTime { get; init; }
        // The amount of time that the process has spent running code inside the operating system core.
        public required TimeSpan PrivilegedProcessorTime { get; init; }
        // The amount of time that the associated process has spent utilizing the CPU. This value is the sum of the UserProcessorTime and the PrivilegedProcessorTime.
        // Gets the maximum amount of physical memory, in bytes, used by the associated process.
        public required float PeakWorkingSet64 { get; init; }
        // Gets the maximum amount of memory in the virtual memory paging file, in bytes, used by the associated process.
        public required float PeakPagedMemorySize64 { get; init; }
        public override string ToString() => $"""
                Physical memory usage : {WorkingSet64} MB
                Paged memory usage : {PagedMemorySize64} MB
                User processor time : {UserProcessorTime.Milliseconds} ms
                Peak physical memory usage : {PeakWorkingSet64} MB
                Peak paged memory usage : {PeakPagedMemorySize64} MB
                Privileged processor time : {PrivilegedProcessorTime.Milliseconds} ms
            """;
    }
}
