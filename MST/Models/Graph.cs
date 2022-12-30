﻿namespace MinimumSpanningTree.Models
{
    internal sealed class Graph
    {
        internal int VerticesNumber { get; private set; }
        internal List<Edge> Edges { get; private set; }

        internal void LoadGraph()
        {
            // load the adjacency matrix from the file
            var streamReader = new StreamReader(Constants.ReadFilePath);
            var adjacencyMatrix = streamReader.ReadToEnd().Trim().Split(Environment.NewLine).Select(line => line.Trim().Split(" ").Select(u => int.Parse(u)).ToArray()).ToArray();

            // initialize the edges number,  the edges list and the index used to add the edges into the list
            VerticesNumber = adjacencyMatrix.Count();
            Edges = new List<Edge>();

            // build the graph from adjacency matrix stored into the file
            for (var i = 1; i < VerticesNumber; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (adjacencyMatrix[i][j] != 0)
                    {
                        Edges.Add(new Edge()
                            {
                                Source = i,
                                Destination = j,
                                Weight = adjacencyMatrix[i][j]
                            });
                    }
                }
            }

        }
    }
}
