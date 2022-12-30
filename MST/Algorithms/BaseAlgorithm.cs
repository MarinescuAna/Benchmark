﻿using MST.Models;

namespace MST.Algorithms
{
    internal abstract class BaseAlgorithm
    {
        // Given graph
        protected Graph graph;
        // Array to store constructed MST
        protected List<Edge> minimumSpanningTree;

        public BaseAlgorithm(Graph graph)
        {
            this.graph = graph;
            minimumSpanningTree = new List<Edge>();
        }

        internal abstract void Run();

        protected void PrintMST(string algorithmName)
        {
            Console.WriteLine($"----- MST - {algorithmName} Algorithm -----");
            foreach (var egde in minimumSpanningTree)
            {
                Console.WriteLine(egde.Source + " - " + egde.Destination + "\t"
                                + egde.Weight);
            }
            Console.WriteLine($"The weights sum for minimum spanning tree generated using {algorithmName} Algorithm is {minimumSpanningTree.Sum(u => u.Weight)}");
        }
    }
}
