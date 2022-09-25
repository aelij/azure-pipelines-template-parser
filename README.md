# Azure Pipelines Template Parser

## Building

1. Install the .NET 6 SDK
1. Download the [Azure Pipelines agent](https://github.com/microsoft/azure-pipelines-agent/releases) and unzip it into the directory `pipelineagent` under the repo root (there should be a `bin` directory directly under it)
1. Compile using VS or `dotnet build`

## Running

```
dotnet run --project src\TemplateParser --root <root-path-for-yamls> --yaml <main-yaml-path> --output <output-yaml-path>
```

Make sure all dependent templates are in the root directory
