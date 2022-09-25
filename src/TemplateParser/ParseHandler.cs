using Microsoft.TeamFoundation.DistributedTask.Pipelines;
using Microsoft.TeamFoundation.DistributedTask.Pipelines.Yaml;
using Microsoft.TeamFoundation.DistributedTask.WebApi;
using System.Collections.Immutable;

internal class ParseHandler
{
    public void Invoke(string rootPath, string yamlPath, string outputPath)
    {
        var options = new ParseOptions
        {
            EnableDynamicVariables = true,
            EnableEachExpressions = true,
            EnableParameterReferenceErrors = true,
            EnableStages = true,
            EvaluateAfterAddingToVariablesMap = true,
            RetrieveOptions = RetrieveOptions.All
        };

        var yamlWriter = new YamlTraceWriter();
        var traceWriter = new TraceWriter();
        var parser = new PipelineParser(traceWriter, options, new FileProviderFactory(rootPath), yamlWriter);
        var template = parser.LoadPipeline(yamlPath,
            systemVariables: ImmutableDictionary<string, VariableValue>.Empty,
            parameters: ImmutableDictionary<string, object>.Empty,
            repositoryOverrides: ImmutableDictionary<string, RepositoryResource>.Empty,
            tasks: ImmutableList<TaskDefinition>.Empty,
            new ArtifactResolver(),
            CancellationToken.None,
            out var composition);

        traceWriter.Info("----- SUMMARY -----");
        traceWriter.Info("Files: " + composition.Files.Count);

        if (template.Errors.Count > 0)
        {
            traceWriter.Error("----- ERRORS -----");

            foreach (var error in template.Errors)
            {
                traceWriter.Error(error.Message);
            }

            return;
        }

        if (template.Stages.Count(t => t.DependsOn.Count == 0) is var startNodeCount && startNodeCount == 0)
        {
            traceWriter.Error("No starting nodes found");

            foreach (var stage in template.Stages)
            {
                traceWriter.Error($"  Stage {stage.Name}: {string.Join(", ", stage.DependsOn)}");
            }
        }

        if (outputPath is not null)
        {
            File.WriteAllText(outputPath, yamlWriter.ToString());
            traceWriter.Info($"Wrote result to {outputPath}");
        }
        else
        {
            traceWriter.Info("----- Processed YAML -----");
            Console.WriteLine(yamlWriter.ToString());
        }
    }
}
