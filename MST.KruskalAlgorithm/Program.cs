using CustomBenchmark.Core.Helpers.Labels;
using MST.Common;
using MST.Common.Entities;
using MST.KruskalAlgorithm;

// Use this variable to choose if the MST generated is displayed or not
var printResults = false;
// Given graph
Graph graph = new();
// Kruskal's Algorithm
KruskalAlgorithm? algorithm = null;

// Read the arguments (input printResults) : the input file path and the value for printResults [which is optional]
using (_ = new Label(Constants.ReadArguments_InfoMessage))
{
    if (args.Length == 0)
    {
        throw new ArgumentException(Constants.MissingArguments_ExceptionMessage);
    }
    if (args.Length == 2)
    {
        bool.TryParse(args[1], out printResults);
    }
}

// Read the adjacency matrix from the file and convert it into a Graph object
using (_ = new Label(Constants.ReadAdjacencyMatrixAndGraphConvertion_InfoMessage))
{
    graph.LoadGraph(args[0]);
}

// Initialize the variables and allocate memory
using (_ = new Label(Constants.InitializationAndMemoryAllocation_InfoMessage))
{
    algorithm = new(graph);
}

// Run algoritm for finding MST
using (_ = new Label(Constants.RunProgram_InfoMessage))
{
    algorithm.Run();
}

// Print the results if are requierd
if (printResults)
{
    using (_ = new Label(Constants.PrintMstAndSum_InfoMessage))
    {
        algorithm.PrintMST();
    }
}




