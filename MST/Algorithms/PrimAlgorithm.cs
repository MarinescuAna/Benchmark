using MST.Models;

namespace MST.Algorithms
{
    internal sealed class PrimAlgorithm : BaseAlgorithm
    {
        // Key values used to pick minimum weight edge in cut
        private int[] _key;
        // To represent set of vertices included in MST
        private bool[] _added;

        internal PrimAlgorithm(Graph graph) : base(graph)
        {
           _key = Enumerable.Repeat(int.MaxValue,graph.VerticesNumber).ToArray();
           _added = Enumerable.Repeat(false, graph.VerticesNumber).ToArray();
        }

        internal override void Run()
        {
            // Always include first 1st vertex in MST.
            // Make key 0 so that this vertex is picked as first vertex
            // First node is always root of MST
            _key[0] = 0;

            // The MST will have V vertices
            Enumerable.Range(0, graph.VerticesNumber - 1).ToList().ForEach(iterator =>
            {
                // Pick thd minimum key vertex from the set of vertices not yet included in MST
                var minVertex = FindMinKey();

                // Add the picked vertex to the MST Set
                _added[minVertex] = true;

                // Update key value and parent index of the adjacent vertices of the picked vertex. Consider
                // only those vertices which are not yet included in MST
                Enumerable.Range(0, graph.VerticesNumber).ToList().ForEach(vertex =>
                {
                    if (!_added[vertex] && graph.EdgeExists(minVertex, vertex) && graph.GetEdge(minVertex, vertex).Weight < _key[vertex])
                    {
                        var selectedEdge = graph.GetEdge(minVertex, vertex);
                        minimumSpanningTree.Add(selectedEdge);
                        _key[vertex] = selectedEdge.Weight;
                    }
                });
            });
        }

        // Find the vertex with minimum key value, from the set of vertices not yet included in MST
        private int FindMinKey() => 
            _key.Select((val, index) => (val, index)).Where(val => !_added[val.index]).Min().index;
    }
}
