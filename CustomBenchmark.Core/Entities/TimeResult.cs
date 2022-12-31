namespace CustomBenchmark.Core.Entities
{
    public sealed record TimeResult(string EventName, TimeSpan Time)
    {
        public sealed override string ToString() => $"{EventName} : {(float)Time.Milliseconds/1000}s";
    }
}
