using System.Text.Json.Serialization;

namespace CustomBenchmark.Core.Configuration
{
    public sealed class Config
    {
        [JsonPropertyName("inputFolderPath")]
        public required string InputFolderPath { get; init; }
        [JsonPropertyName("outputFolderPath")]
        public required string OutputFolderPath { get; init;}
        [JsonPropertyName("configGenerator")]
        public required ConfigGenerator ConfigGenerator { get; init; }
        [JsonPropertyName("collectionTime")]
        public required int CollectionTime { get; init; }
        [JsonPropertyName("applicationsExePaths")]
        public required Dictionary<string,string> ApplicationsExePaths { get; init; }
    }
}
