using System.Text.Json.Serialization;

namespace CustomBenchmark.Core.Configuration
{
    public sealed class GraphConfiguration
    {
        [JsonPropertyName("vertices")]
        public required int Vertices { get; init; }
        [JsonPropertyName("maxValueWeight")]
        public required int MaxValueWeight { get; init; }
    }
}
