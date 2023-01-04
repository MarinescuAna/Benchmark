using BenchmarkRunner.Entities;
using CustomBenchmark.Core.Configuration;
using CustomBenchmark.Core.Events;
using CustomBenchmark.Core.Helpers;
using System.Diagnostics;

namespace CustomBenchmark.Core
{
    public sealed class Runner
    {
        private readonly string _projectFolderPath;
        private readonly Config _configuration;
        private readonly OutputCollectorHelper _outputCollector;
        public Runner(Config config, string path)
        {
            _projectFolderPath = path;
            _configuration = config;
            _outputCollector = new OutputCollectorHelper();
        }

        public void Run()
        {
            var results = new Dictionary<string, List<Result>>();

            // Foreach graph configurations provided via json file, do the following actions:
            foreach (var config in _configuration.ConfigGenerator.GraphConfigurations)
            {
                // Run process for generating the adjacency matrix according to the configuration file, without saving any information about it 
                _ = RunNewProcess($"{_projectFolderPath}{_configuration.InputFolderPath} {config.Vertices} {config.MaxValueWeight}", $"{_projectFolderPath}{_configuration.ConfigGenerator.ExeGeneratorPath}", 0, false);

                Console.WriteLine(string.Format(Constants.MatrixDetails_Log,config.Vertices,config.MaxValueWeight));

                // If any error occured, stop the process
                if (_outputCollector.ErrorOccured)
                {
                    return;
                }

                // Having the adjacency matrix generated according to the given configuration, run all the process and log the results
                foreach (var exe in _configuration.ApplicationsExePaths)
                {
                    Console.WriteLine(string.Format(Constants.TextWithTabBefore,exe.Key));

                    // If the process wasn't run by this moment, add it into the dictionary
                    if (!results.ContainsKey(exe.Key))
                    {
                        results.Add(exe.Key, new());
                    }

                    var filepath = string.Format(Constants.FilePathInput, _projectFolderPath,_configuration.InputFolderPath, config.Vertices,config.MaxValueWeight);

                    // Run the algorithm for the given graph and pick up the results
                    results[exe.Key].Add(RunNewProcess(filepath, $"{_projectFolderPath}{exe.Value}", _configuration.CollectionTime));
                }
            }

            // For each applications, display the collected results
            WriteHelper.PrintResults(results, _configuration, _projectFolderPath);

        }

        public Result RunNewProcess(string args, string exePath, int collectionTime, bool redirectStandardOutput = true)
        {
            // Create the process
            var result = new Result();
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


            // Start process
            try
            {
                process.Start();
             }
            catch
            {
                throw new Exception(Constants.InvalidPath_Exception);
            }

            process.BeginErrorReadLine();
            if (redirectStandardOutput)
            {
                process.BeginOutputReadLine();
            }

            // While the process still running, collect the results
            do
            {
                if (redirectStandardOutput)
                {
                    var collectedResult = CollectorHelper.CollectTemporaryData(process);
                    if (collectedResult != null)
                    {
                        result.ProcessResult = collectedResult;
                    }
                    process.Refresh();
                }
            } while (!process.WaitForExit(collectionTime));

            // Get the last results
            if (redirectStandardOutput)
            {
                result.TotalProcessorTime = process.TotalProcessorTime;
                result.TimeResults = _outputCollector.TimeResults;
                result.OtherMessages = _outputCollector.OtherMessages;
            }

            process.Close();

            return result!;
        }
    }
}