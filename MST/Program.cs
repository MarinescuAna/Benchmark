using MinimumSpanningTree.Algorithms;
using MinimumSpanningTree.Models;

// load the graph
var graph = new Graph();
graph.LoadGraph();

var kruskalAlg = new KruskalAlgorithm(graph);
kruskalAlg.Run();
