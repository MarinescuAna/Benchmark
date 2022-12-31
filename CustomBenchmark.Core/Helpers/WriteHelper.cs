using BenchmarkRunner.Entities;
using CustomBenchmark.Core.Configuration;

namespace CustomBenchmark.Core.Helpers
{
    public static class WriteHelper
    {
        public static void PrintResults(List<Result> results, Config config)
        {
            StreamWriter? streamWriter = null;

            if (!Directory.Exists(config.OutputFolderPath))
            {
                Directory.CreateDirectory(config.OutputFolderPath);
            }

            try
            {
                streamWriter = new StreamWriter($"{config.OutputFolderPath}\\{DateTime.Now.Date.Day}{DateTime.Now.Date.Month}{DateTime.Now.Date.Year}{DateTime.Now.Date.Minute}_log.txt");

                for (var i = 0; i < results.Count; i++)
                {
                    Console.WriteLine($"\n\n========Experiment {i+1}======");
                    Console.WriteLine($"Configuration details:");
                    Console.WriteLine($"\t Undirected graph with {config.ConfigGenerator.GraphConfigurations[i].Vertices} vertices with values between [0,{config.ConfigGenerator.GraphConfigurations[i].MaxValueWeight}]\n \t The waiting time between measurements: {config.CollectionTime} ms");
                    Console.WriteLine("\nTimes recorded after the following events:");
                    foreach (var log in results[i].TimeResults!)
                    {
                        Console.WriteLine($"\t{log}");
                    }
                    Console.WriteLine("\nThe memory used during the process of finding the MST:");
                    foreach (var log in results[i].IntermediaryResults!)
                    {
                        Console.WriteLine(log);
                    }
                    Console.WriteLine($"\nTotal processor time : {(float)results[i].TotalProcessorTime.Milliseconds/1000} s");
                }
                streamWriter.Close();
            }
            catch
            {
                throw new Exception("Invalid directory path!");
            }
            finally
            {

                streamWriter?.Dispose();

            }
        }
            
    }
}
