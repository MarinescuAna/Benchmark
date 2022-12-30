using MinimumSpanningTree.Models;

namespace MinimumSpanningTree.Algorithms
{
    internal sealed class KruskalAlgorithm
    {
        private Graph _graph;

        internal KruskalAlgorithm(Graph graph)
        {
            _graph = graph;
        }

        internal void Run()
        {
            // This array is used for storing the minimum spanning tree
            var minimumSpanningTree = new List<Edge>();

            /// Strep1: Sort all the edges in non-decreasing order of thier weight
            _graph.Edges.Sort();

            // Set parents table
            var parents = Enumerable.Range(0, _graph.VerticesNumber).ToArray();

            foreach (var edge in _graph.Edges)
            {
                var startNodeRoot = FindRoot(edge.Source, parents);
                var endNodeRoot = FindRoot(edge.Destination, parents);

                if (startNodeRoot != endNodeRoot)
                {
                    // Add edge to the spanning tree
                    minimumSpanningTree.Add(edge);

                    // Mark one root as parent of the other
                    parents[endNodeRoot] = startNodeRoot;
                }
            }

            Console.WriteLine(string.Format(Constants.TextDisplayKruskalAlg, minimumSpanningTree.Sum(u => u.Weight)));
        }
        private int FindRoot(int node, int[] parent)
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
