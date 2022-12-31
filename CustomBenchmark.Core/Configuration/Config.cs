using System.Text.Json.Serialization;

namespace CustomBenchmark.Core.Configuration
{
    public sealed class Config
    {
        [JsonPropertyName("inputFilePath")]
        public required string InputFilePath { get; init; }
        [JsonPropertyName("outputFolderPath")]
        public required string OutputFolderPath { get; init;}
        [JsonPropertyName("configGenerator")]
        public required ConfigGenerator ConfigGenerator { get; init; }
        [JsonPropertyName("collectionTime")]
        public required int CollectionTime { get; init; }
        [JsonPropertyName("exeMSTPath")]
        public required string ExeMstPath { get; init; }
    }
}
