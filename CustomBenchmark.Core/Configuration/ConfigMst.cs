using System.Text.Json.Serialization;

namespace CustomBenchmark.Core.Configuration
{
    public sealed class ConfigMst
    {
        [JsonPropertyName("collectionTime")]
        public required int CollectionTime { get; init; }
        [JsonPropertyName("exeMSTPath")]
        public required string ExeMstPath { get; init; }
    }
}
