namespace MinimumSpanningTree.Models
{
    internal sealed class Edge : IComparable<Edge>
    {
        public int Source { get; set; }
        public int Destination { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Edge edge) => Weight - edge.Weight;
    }
}
