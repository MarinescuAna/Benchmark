

using MST.Algorithms;
using MST.Models;



var graph = new Graph();
graph.LoadGraph();

var primAlg = new PrimAlgorithm(graph);
primAlg.Run();

var kruskalAlg = new KruskalAlgorithm(graph);
kruskalAlg.Run();




