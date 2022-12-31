using System.Text.Json.Serialization;

namespace CustomBenchmark.Core.Configuration
{
    public sealed class ConfigGenerator
    {
        [JsonPropertyName("exeGeneratorPath")]
        public required string ExeGeneratorPath { get; init; }
        [JsonPropertyName("graphConfig")]
        public required GraphConfiguration[] GraphConfigurations { get; init; }  
    }
}
