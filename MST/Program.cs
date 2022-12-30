using CustomBenchmark.Helper;
using MST.Algorithms;
using MST.Models;

var graph = new Graph();
BaseAlgorithm algorithm;

using (_ = new Label("Load graph"))
{
    graph.LoadGraph();
}

using (_ = new Label("Prim's algorithm - initializations and memory allocation"))
{
    algorithm = new PrimAlgorithm(graph);
}

using (_ = new Label("Prim's algorithm - run algoritm"))
{
    algorithm.Run();
}

using (_ = new Label("Prim's algorithm - print MST"))
{
    algorithm.PrintMST("Prim's");
}

using (_ = new Label("Kruskal's algorithm - initializations and memory allocation"))
{
    algorithm = new KruskalAlgorithm(graph);
}

using (_ = new Label("Kruskal's algorithm - run algoritm"))
{
    algorithm.Run();
}

using (_ = new Label("Kruskal's algorithm - print MST"))
{
    algorithm.PrintMST("Kruskal's");
}




