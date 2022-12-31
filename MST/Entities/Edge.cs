namespace MST.Entities
{
    internal sealed class Edge : IComparable<Edge>
    {
        internal int Source { get; set; }
        internal int Destination { get; set; }
        internal int Weight { get; set; }

        public int CompareTo(Edge? edge) => Weight - edge!.Weight;
    }
}
