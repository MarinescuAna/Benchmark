using CustomBenchmark.Core.Helpers.Labels;
using System.Diagnostics;

namespace CustomBenchmark.Core.Events
{
    public sealed class OutputCollectorHelper
    {
        public Dictionary<string, Stopwatch> TimeResults { get; private set; } = new();
        public List<string> OtherMessages { get; private set; } = new();
        public bool ErrorOccured { get; private set; } = false;
        public void Process_ThrowError(object sender, DataReceivedEventArgs e)
        {
            // Display all the exceptions into the console
            if (!string.IsNullOrEmpty(e.Data))
            {
                ErrorOccured = true;
                Console.WriteLine(e.Data.ToString());
            }
        }
        public void Process_CollectOutput(object sender, DataReceivedEventArgs e)
        {
            // Exit if there is no Data
            if (string.IsNullOrEmpty(e.Data))
            {
                return;
            }

            // If the message contains a [Start] tag, start the timer
            if (e.Data.Contains(Tag.Tags[TagType.Start]))
            {
                var message = e.Data.Replace(Tag.Tags[TagType.Start], string.Empty);
                if (!TimeResults.ContainsKey(message))
                {
                    TimeResults.Add(message, Stopwatch.StartNew());
                }
                return;
            }

            // If the message contains a [Stop] tag, log the time and reset the timer
            if (e.Data.Contains(Tag.Tags[TagType.Stop]))
            {
                var message = e.Data.Replace(Tag.Tags[TagType.Stop], string.Empty);
                if (!TimeResults.ContainsKey(message))
                {
                    TimeResults[message].Stop();
                }
                return;
            }

            // If the message contains a [Other] tag, log that information
            if (e.Data.Contains(Tag.Tags[TagType.Other]))
            {
                var message = e.Data.Replace(Tag.Tags[TagType.Other], string.Empty).Trim();
                if (!OtherMessages.Contains(message))
                {
                    OtherMessages.Add(message);
                }
                return;
            }

        }


    }
}
