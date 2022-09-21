using Microsoft.TeamFoundation.DistributedTask.Pipelines;
using Microsoft.TeamFoundation.DistributedTask.Pipelines.Artifacts;

internal class ArtifactResolver : IArtifactResolver
{
    public Guid GetArtifactDownloadTaskId(Resource resource) => Guid.Empty;

    public void PopulateMappedTaskInputs(Resource resource, TaskStep taskStep)
    {
    }

    public bool ResolveStep(IPipelineContext pipelineContext, JobStep step, out IList<TaskStep> resolvedSteps)
    {
        resolvedSteps = Array.Empty<TaskStep>();
        return true;
    }

    public bool ResolveStep(IResourceStore resourceStore, TaskStep taskStep, out string errorMessage)
    {
        errorMessage = string.Empty;
        return true;
    }

    public bool ValidateDeclaredResource(Resource resource, out PipelineValidationError error)
    {
        error = null;
        return true;
    }
}