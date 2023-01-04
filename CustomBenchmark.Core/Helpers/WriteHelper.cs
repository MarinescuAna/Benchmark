using BenchmarkRunner.Entities;
using CustomBenchmark.Core.Configuration;

namespace CustomBenchmark.Core.Helpers
{
    public static class WriteHelper
    {
        public static void PrintResults(Dictionary<string, List<Result>> results, Config config, string projectFolder)
        {
            StreamWriter? streamWriter = null;
            var fullOutputPath = $"{projectFolder}{config.OutputFolderPath}";

            if (!Directory.Exists(fullOutputPath))
            {
                Directory.CreateDirectory(fullOutputPath);
            }

            try
            {
                streamWriter = new StreamWriter(string.Format(Constants.FilePathOutput, fullOutputPath, DateTime.Now.Microsecond,DateTime.Now.Date.Day,DateTime.Now.Date.Month,DateTime.Now.Year));

                foreach (var application in results)
                {
                    streamWriter.WriteLine(string.Format(Constants.Title_ApplicationName_OutputMessage,application.Key));

                    for (var i = 0; i < application.Value.Count; i++)
                    {
                        streamWriter.WriteLine(string.Format(Constants.SubTitle_ExperimentNumber_OutputMessage,i+1));

                        streamWriter.WriteLine(string.Format(
                            Constants.Body_ConfigurationDetailsSection_OutputMessage, 
                            config.ConfigGenerator.GraphConfigurations[i].Vertices,
                            config.ConfigGenerator.GraphConfigurations[i].MaxValueWeight,
                            config.CollectionTime));

                        if (application.Value[i].TimeResults != null)
                        {
                            streamWriter.WriteLine(Constants.Body_TimeRecorded_OutputMessage);
                            foreach (var result in application.Value[i].TimeResults!)
                            {
                                streamWriter.WriteLine(string.Format(Constants.Body_TimeAction_OutputMessage,result.Key,(float)result.Value.ElapsedMilliseconds / 1000));
                            }
                        }

                        streamWriter.WriteLine(string.Format(Constants.Body_TotalMemoryMST_OutputMessage,application.Value[i].ProcessResult));
                        streamWriter.WriteLine(string.Format(Constants.Body_TotalProcessorTime_OutputMessage,(float)application.Value[i].TotalProcessorTime.Milliseconds / 1000));
                        application.Value[i].OtherMessages?.ForEach(log => streamWriter.WriteLine(string.Format(Constants.TextWithTabBefore,log)));
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
                Console.WriteLine(Constants.FileWasGenerated_Log);
                streamWriter?.Dispose();

            }
        }

    }
}
