namespace CustomBenchmark.Helper
{
    public class Label : IDisposable
    {
        public Label(string message)
        {
            Console.WriteLine(message);
        }
        public void Dispose()
        {
            Console.WriteLine("Stop");
        }
    }
}