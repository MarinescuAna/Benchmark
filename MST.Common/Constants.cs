namespace MST.Common
{
    public static class Constants
    {
        public static readonly string GarbageCollector_InfoMessage = "[Other] Memory used by garbage collector: {0}KB";
        public static readonly string ReadArguments_InfoMessage = "Read the arguments from command-line";
        public static readonly string ReadAdjacencyMatrixAndGraphConvertion_InfoMessage = "Read the adjacency matrix from the file and convert it into a Graph object";
        public static readonly string InitializationAndMemoryAllocation_InfoMessage = "Initialize the variables and allocate memory";
        public static readonly string RunProgram_InfoMessage = "Run algorithm for finding MST";
        public static readonly string PrintMstAndSum_InfoMessage = "Print MST and the weights sum";

        public static readonly string MissingArguments_ExceptionMessage = "Arguments are missing!";
        public static readonly string InvalidArguments_ExceptionMessage = "Invalid arguments!";
        public static readonly string InvalidFilePath_ExceptionMessage = "Invalid file path!";
        public static readonly string InvalidAdjacencyMatrix_ExceptionMessage = "Invalid adjacency matrix!";

        public static readonly string FileNameReadInput = "{0}_{1}_Graph.txt";
        public static readonly string FilePathReadInput = "{0}\\{1}";
    }
}
