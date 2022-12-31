using CustomBenchmark.Core;
using CustomBenchmark.Core.Configuration;
using System.Text.Json;

Config? config = null;

try
{
    config = JsonSerializer.Deserialize<Config>(File.ReadAllText("config.json"));
}
catch
{
    throw new Exception("Can't read the config.json file!");
}

if (config == null)
{
    throw new Exception("The configuration file is missing!");
}

var runner = new Runner(config);
runner.Run();

