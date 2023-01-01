using MST.Common;
using MST.Common.Entities;

namespace MST.KruskalAlgorithm
{
    internal sealed class KruskalAlgorithm
    {
        // Given graph
        private readonly Graph _graph;
        // Array to store constructed MST
        private readonly Graph _minimumSpanningTree;

        internal KruskalAlgorithm(Graph graph)
        {
            _graph = graph;
            _minimumSpanningTree = new();
        }
        internal void Run()
        {
            /// Strep1: Sort all the edges in non-decreasing order of thier weight
            _graph.Edges!.Sort();

            // Set parents table
            var parents = Enumerable.Range(0, _graph.VerticesNumber).ToArray();

            foreach (var edge in _graph.Edges)
            {
                var startNodeRoot = FindRoot(edge.Source, parents);
                var endNodeRoot = FindRoot(edge.Destination, parents);

                if (startNodeRoot != endNodeRoot)
                {
                    // Add edge to the spanning tree
                    _minimumSpanningTree.Edges!.Add(edge);

                    // Mark one root as parent of the other
                    parents[endNodeRoot] = startNodeRoot;
                }
            }

            Console.WriteLine(string.Format(Constants.GarbageCollector_InfoMessage, GC.GetTotalMemory(true) / 1024));
        }
        internal void PrintMST() => Console.WriteLine(_minimumSpanningTree.ToString());
        private static int FindRoot(int node, int[] parent)
        {
            var root = node;
            while (root != parent[root])
            {
                root = parent[root];
            }

            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }
    }
}
