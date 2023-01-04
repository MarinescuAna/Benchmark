using System.Text;

namespace MST.Common.Entities
{
    public sealed class Graph
    {
        // No of vertices
        public int VerticesNumber { get; private set; }
        // List with all the edges and their weights
        public List<Edge> Edges { get; private set; } = new();

        public void LoadGraph(string inputPath)
        {
            // load the adjacency matrix from the file
            var streamReader = new StreamReader(inputPath) ?? throw new Exception(Constants.InvalidFilePath_ExceptionMessage);
            int[][]? adjacencyMatrix = 
                adjacencyMatrix = streamReader.ReadToEnd().Trim().Split(Environment.NewLine)
                            .Select(line => line.Trim().Split(" ").Select(u => int.Parse(u)).ToArray()).ToArray()
                            ?? throw new Exception(Constants.InvalidAdjacencyMatrix_ExceptionMessage);

            // initialize the edges number,  the edges list and the index used to add the edges into the list
            VerticesNumber = adjacencyMatrix.Length;
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
        public bool EdgeExists(int source, int destination) =>
            Edges!.Any(e => (e.Source == source && e.Destination == destination) ||
                         (e.Destination == source && e.Source == destination));
        public Edge GetEdge(int source, int destination) =>
            Edges!.FirstOrDefault(e => (e.Source == source && e.Destination == destination) ||
                                    (e.Destination == source && e.Source == destination))!;
        public override string ToString()
        {
            var output = new StringBuilder().Append("\n----- MST -----\n");

            Edges.ForEach(edge => output.Append($"{edge.Source} - {edge.Destination} : {edge.Weight}\n"));

            output.Append($"The weights sum for minimum spanning tree generated is {Edges!.Sum(u => u.Weight)}");

            return output.ToString();
        }
    }
}
