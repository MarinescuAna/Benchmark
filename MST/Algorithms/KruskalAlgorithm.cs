using MST.Models;

namespace MST.Algorithms
{
    internal sealed class KruskalAlgorithm: BaseAlgorithm
    {
        internal KruskalAlgorithm(Graph graph):base(graph) { }
        internal override void Run()
        {
            /// Strep1: Sort all the edges in non-decreasing order of thier weight
            graph.Edges.Sort();

            // Set parents table
            var parents = Enumerable.Range(0, graph.VerticesNumber).ToArray();

            foreach (var edge in graph.Edges)
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

            PrintMST("Kruskal");
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
