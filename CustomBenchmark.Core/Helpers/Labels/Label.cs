namespace CustomBenchmark.Core.Helpers.Labels
{
    public class Label : IDisposable
    {
        public Label(string message)
        {
            Console.WriteLine(message);
        }
        public void Dispose()
        {
            Console.WriteLine(Tag.Tags[TagType.Stop]);
        }
    }
}