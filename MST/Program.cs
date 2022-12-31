using CustomBenchmark.Core.Helpers.Labels;
using MST.Algorithms;
using MST.Entities;

var printResults = false;
var graph = new Graph();
BaseAlgorithm algorithm;

if (args.Length == 0)
{
    throw new ArgumentException("Arguments are missing: (input printResults)!!");
}

if (!bool.TryParse(args[1],out printResults))
{
    throw new ArgumentException("Invalid argument!");
}

using (_ = new Label("[Start]Load graph"))
{
    graph.LoadGraph(args[0]);
}

using (_ = new Label("[Start]Prim's algorithm - initializations and memory allocation"))
{
    algorithm = new PrimAlgorithm(graph);
}

using (_ = new Label("[Start]Prim's algorithm - run algoritm"))
{
    algorithm.Run();
}

if (printResults)
{
    using (_ = new Label("[Start]Prim's algorithm - print MST"))
    {
        algorithm.PrintMST("Prim's");
    }
}

using (_ = new Label("[Start]Kruskal's algorithm - initializations and memory allocation"))
{
    algorithm = new KruskalAlgorithm(graph);
}

using (_ = new Label("[Start]Kruskal's algorithm - run algoritm"))
{
    algorithm.Run();
}

if (printResults)
{
    using (_ = new Label("[Start]Kruskal's algorithm - print MST"))
    {
        algorithm.PrintMST("Kruskal's");
    }
}




