using CustomBenchmark.Core;
using CustomBenchmark.Core.Configuration;
using System.Text.Json;

Config? config = null;

var projectFolderPath = args[0] ?? throw new Exception(Constants.MissingArguments_Exception);

// Get the settings from the config.json file
config = JsonSerializer.Deserialize<Config>(File.ReadAllText(Constants.ConfigFileName)) ?? throw new Exception(Constants.InvalidConfigFile_Exception);

if (config == null)
{
    throw new Exception(Constants.ConfigurationFileMissing_Exception);
}

// Run the processes
var runner = new Runner(config,projectFolderPath);
runner.Run();

