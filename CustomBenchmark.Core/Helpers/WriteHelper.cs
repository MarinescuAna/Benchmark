using BenchmarkRunner.Entities;
using CustomBenchmark.Core.Configuration;

namespace CustomBenchmark.Core.Helpers
{
    public static class WriteHelper
    {
        public static void PrintResults(Dictionary<string, List<Result>> results, Config config)
        {
            StreamWriter? streamWriter = null;

            if (!Directory.Exists(config.OutputFolderPath))
            {
                Directory.CreateDirectory(config.OutputFolderPath);
            }

            try
            {
                streamWriter = new StreamWriter($"{config.OutputFolderPath}\\{DateTime.Now.Date.Day}{DateTime.Now.Date.Month}{DateTime.Now.Date.Year}{DateTime.Now.Date.Minute}_log.txt");

                foreach (var application in results)
                {
                    streamWriter.WriteLine($"""
                        
                        ************************************************************
                        ******************** {application.Key} ********************
                        ************************************************************
                        
                        """);

                    for (var i = 0; i < application.Value.Count; i++)
                    {
                        streamWriter.WriteLine($"""
                            
                            ================================
                            ======= Experiment {i + 1} =======
                            ================================
                            
                            """);

                        streamWriter.WriteLine($"Configuration details:");
                        streamWriter.WriteLine($"""
                                Undirected graph with {config.ConfigGenerator.GraphConfigurations[i].Vertices} vertices and values between [0,{config.ConfigGenerator.GraphConfigurations[i].MaxValueWeight}] 
                                The waiting time between measurements: {config.CollectionTime} ms
                            """);

                        if (application.Value[i].TimeResults != null)
                        {
                            streamWriter.WriteLine("\nTimes recorded after the following events:");
                            foreach (var result in application.Value[i].TimeResults!)
                            {
                                streamWriter.WriteLine($"\t{result.Key} : {(float)result.Value.ElapsedMilliseconds / 1000} s");
                            }
                        }

                        streamWriter.WriteLine($"\nThe memory used during the process of finding the MST: \n{application.Value[i].ProcessResult}");
                        streamWriter.WriteLine($"\tTotal processor time : {(float)application.Value[i].TotalProcessorTime.Milliseconds / 1000} s");
                        application.Value[i].OtherMessages?.ForEach(log => streamWriter.WriteLine($"\t{log}"));
                    }
                }
                streamWriter.Close();
            }
            catch
            {
                throw new Exception(Constants.InvalidPath_Exception);
            }
            finally
            {
                Console.WriteLine("The file was generated!");
                streamWriter?.Dispose();

            }
        }

    }
}
