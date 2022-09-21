using System.CommandLine;

var rootPathOption = new Option<string>(
    "--root",
    "The root path for the pipeline. All YAML files must be contained within.")
{ IsRequired = true };
var yamlPathOption = new Option<string>(
    "--yaml",
    "Relative path to the main YAML file to be processed")
{ IsRequired = true };
var outputPathOption = new Option<string>(
    "--output",
    "Path to the output YAML file");

var parseCommand = new Command("parse", "Parses a YAML template")
{
    rootPathOption, yamlPathOption, outputPathOption
};

var parseHandler = new ParseHandler();
parseCommand.SetHandler(parseHandler.Invoke, rootPathOption, yamlPathOption, outputPathOption);

return parseCommand.Invoke(args);
