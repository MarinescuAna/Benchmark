namespace CustomBenchmark.Core
{
    internal static class Constants
    {
        internal static readonly string InvalidConfigFile_Exception = "Can't read the config.json file!";
        internal static readonly string ConfigurationFileMissing_Exception = "The configuration file is missing!";
        internal static readonly string InvalidPath_Exception = "Invalid path!";
        internal static readonly string MissingArguments_Exception = "The argument is missing!";

        internal static readonly string MatrixDetails_Log = "\nMatrix: {0} [0, {1}): ";
        internal static readonly string FileWasGenerated_Log = "The file was generated!";

        internal static readonly string ConfigFileName = "config.json";
        internal static readonly string FilePathInput = "{0}{1}\\{2}_{3}_Graph.txt";
        internal static readonly string FilePathOutput = "{0}\\{1}{2}{3}{4}_log.txt";
        internal static readonly string TextWithTabBefore = "\t{0}";


        internal static readonly string Title_ApplicationName_OutputMessage = """
                        
                        ************************************************************
                        ******************** {0} ********************
                        ************************************************************
                        
                        """;
        internal static readonly string SubTitle_ExperimentNumber_OutputMessage = """
                            
                            ================================
                            ======= Experiment {0} =======
                            ================================
                            
                            """;
        internal static readonly string Body_ConfigurationDetailsSection_OutputMessage = """
                            Configuration details:
                                Undirected graph with {0} vertices and values between [0,{1}) 
                                The waiting time between measurements: {2} ms
                            """;
        internal static readonly string Body_TimeRecorded_OutputMessage = "\nTimes recorded after the following events:";
        internal static readonly string Body_TimeAction_OutputMessage = "\t{0} : {1} s";
        internal static readonly string Body_TotalMemoryMST_OutputMessage = "\nThe memory used during the process of finding the MST: \n{0}";
        internal static readonly string Body_TotalProcessorTime_OutputMessage = "\tTotal processor time : {0} s";
    }
}
