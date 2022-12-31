using CustomBenchmark.Core.Entities;
using CustomBenchmark.Core.Helpers.Labels;
using System.Diagnostics;
using System.Text;

namespace CustomBenchmark.Core.Events
{
    public sealed class OutputCollectorHelper
    {
        private readonly Stopwatch? _stopwatch = new();
        private readonly StringBuilder _lastAction = new();
        private bool _startCollectingResults=false;
        public List<string> Result = new();
        public List<TimeResult> TimeResults { get; private set; } = new();
        public bool ErrorOccured { get; private set; } = false;
        public void Process_ThrowError(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                ErrorOccured = true;
                Console.WriteLine(e.Data.ToString());
            }
        }
        public void Process_CollectOutput(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
            {
                return;
            }

            if (e.Data.Contains(Tag.Tags[TagType.Start]))
            {
                _lastAction.Append(e.Data.Replace(Tag.Tags[TagType.Start], string.Empty));
                _stopwatch!.Start();
            }
            else
            {
                if (e.Data.Contains(Tag.Tags[TagType.Stop]))
                {
                    _stopwatch!.Stop();
                    TimeResults.Add(new TimeResult(_lastAction.ToString(), _stopwatch.Elapsed));
                    _lastAction.Clear();
                    _stopwatch!.Restart();
                }
                else
                {
                    if (e.Data.Contains(Tag.Tags[TagType.Stop]))
                    {
                        _startCollectingResults = true;
                    }
                    else
                    {
                        if (_startCollectingResults)
                        {
                            Result.Add(e.Data);
                        }
                    }
                }
            }

        }
    }
}
