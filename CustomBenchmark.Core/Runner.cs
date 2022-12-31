using BenchmarkRunner.Entities;
using CustomBenchmark.Core.Configuration;
using CustomBenchmark.Core.Entities;
using CustomBenchmark.Core.Events;
using CustomBenchmark.Core.Helpers;
using System.Diagnostics;

namespace CustomBenchmark.Core
{
    public sealed class Runner
    {
        private readonly Config _configuration;
        private readonly OutputCollectorHelper _outputCollector;
        public Runner(Config config)
        {
            _configuration = config;
            _outputCollector = new OutputCollectorHelper();
        }

        public void Run()
        {
            var results = new List<Result>();
            foreach (var config in _configuration.ConfigGenerator.GraphConfigurations)
            {
                // Run process for generating the adjacency matrix according to the configuration file
                // This process is not measured
                RunNewProcess($"{_configuration.InputFilePath} {config.Vertices} {config.MaxValueWeight}", _configuration.ConfigGenerator.ExeGeneratorPath, 0, null, false);

                if (_outputCollector.ErrorOccured)
                {
                    return;
                }

                var result = new Result()
                {
                    IntermediaryResults = new List<IntermediaryResult>(),
                    TimeResults = new List<TimeResult>() {
                    new TimeResult("The adjacency matrix was created!(No measurements was made to this action)", TimeSpan.Zero)
                }
                };

                //Run MST process, both algorithms
                RunNewProcess(_configuration.InputFilePath, _configuration.ExeMstPath, _configuration.CollectionTime, result);
                results.Add(result);
            }

            WriteHelper.PrintResults(results, _configuration);
        }

        public void RunNewProcess(string args, string exePath, int collectionTime, Result? result, bool redirectStandardOutput = true)
        {
            using var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    Arguments = args,
                    FileName = exePath,
                    UseShellExecute = false,
                    RedirectStandardOutput = redirectStandardOutput,
                    RedirectStandardError = true
                },
                EnableRaisingEvents = true
            };

            if (redirectStandardOutput)
            {
                // capture normal output
                process.OutputDataReceived += _outputCollector.Process_CollectOutput;
            }
            // Capture error output
            process.ErrorDataReceived += _outputCollector.Process_ThrowError;

            process.Start();

            process.BeginErrorReadLine();
            if (redirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }

            do
            {
                if (result != null)
                {
                    // Display current process statistics.
                    var collectedResult = CollectorHelper.CollectTemporaryData(process);
                    if (collectedResult != null)
                    {
                        result!.IntermediaryResults!.Add(collectedResult);
                    }
                    process.Refresh();
                }
            } while (!process.WaitForExit(collectionTime));

            if (result != null)
            {
                result.TotalProcessorTime = process.TotalProcessorTime;
                result.TimeResults!.AddRange(_outputCollector.TimeResults);
            }

            process.Close();

        }
    }
}