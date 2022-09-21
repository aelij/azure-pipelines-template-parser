using Microsoft.TeamFoundation.DistributedTask.Pipelines;
using Microsoft.TeamFoundation.DistributedTask.Pipelines.Yaml;

internal class FileProvider : IFileProvider
{
    private readonly string _root;

    public RepositoryResource Repository { get; }

    public FileProvider(string root, RepositoryResource repository)
    {
        _root = root;
        Repository = repository;
    }

    public string GetDirectoryName(string path) => Path.GetDirectoryName(path);

    public string GetFileContent(string path) => File.ReadAllText(path);

    public string GetFileName(string path) => Path.GetFileName(path);

    public string ResolvePath(string defaultRoot, string path) => Path.Combine(string.IsNullOrEmpty(defaultRoot) ? _root : defaultRoot, path);

    public string GetFileUuid(string path) => throw new NotSupportedException();

    public string GetFileContentByUuid(string uuid) => throw new NotSupportedException();
}
