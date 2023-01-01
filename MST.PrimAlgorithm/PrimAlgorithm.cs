using MST.Common;
using MST.Common.Entities;

namespace MST.Algorithms
{
    internal sealed class PrimAlgorithm
    {
        // Key values used to pick minimum weight edge in cut
        private readonly int[] _key;
        // To represent set of vertices included in MST
        private readonly bool[] _added;
        // Given graph
        private readonly Graph _graph;
        // MST
        private readonly Graph _minimumSpanningTree;

        internal PrimAlgorithm(Graph graph)
        {
            _graph = graph;
            _minimumSpanningTree = new();
            _key = Enumerable.Repeat(int.MaxValue, graph.VerticesNumber).ToArray();
            _added = Enumerable.Repeat(false, graph.VerticesNumber).ToArray();
        }

        internal void Run()
        {
            // Always include first 1st vertex in MST.
            // Make key 0 so that this vertex is picked as first vertex
            // First node is always root of MST
            _key[0] = 0;

            // The MST will have V vertices
            Enumerable.Range(0, _graph.VerticesNumber - 1).ToList().ForEach(iterator =>
            {
                // Pick thd minimum key vertex from the set of vertices not yet included in MST
                var minVertex = FindMinKey();

                // Add the picked vertex to the MST Set
                _added[minVertex] = true;

                // Update key value and parent index of the adjacent vertices of the picked vertex. Consider
                // only those vertices which are not yet included in MST
                Enumerable.Range(0, _graph.VerticesNumber).ToList().ForEach(vertex =>
                {
                    if (!_added[vertex] && _graph.EdgeExists(minVertex, vertex) && _graph.GetEdge(minVertex, vertex).Weight < _key[vertex])
                    {
                        var selectedEdge = _graph.GetEdge(minVertex, vertex);
                        _minimumSpanningTree.Edges.Add(selectedEdge);
                        _key[vertex] = selectedEdge.Weight;
                    }
                });
            });

            Console.WriteLine(string.Format(Constants.GarbageCollector_InfoMessage, GC.GetTotalMemory(true) / 1024));
        }

        /// <summary>
        /// Find the vertex with minimum key value, from the set of vertices not yet included in MST
        /// </summary>
        /// <returns></returns>
        private int FindMinKey() =>
            _key.Select((val, index) => (val, index)).Where(val => !_added[val.index]).Min().index;
        internal void PrintMST() => Console.WriteLine(_minimumSpanningTree.ToString());
    }
}
