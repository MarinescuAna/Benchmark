namespace CustomBenchmark.Core.Helpers.Labels
{
    public class Label : IDisposable
    {
        private readonly string _massageName;
        public Label(string message)
        {
            _massageName = message;
            Console.WriteLine($"{Tag.Tags[TagType.Start]}{_massageName}");
        }
        void IDisposable.Dispose() => Console.WriteLine($"{Tag.Tags[TagType.Stop]}{_massageName}");
    }
}