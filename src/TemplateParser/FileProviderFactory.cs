using Microsoft.TeamFoundation.DistributedTask.Pipelines;
using Microsoft.TeamFoundation.DistributedTask.Pipelines.Yaml;

internal class FileProviderFactory : IFileProviderFactory
{
    private readonly Dictionary<string, RepositoryResource> _repos = new();
    private readonly string _root;

    public FileProviderFactory(string root) => _root = root;

    public void AddRepository(RepositoryResource repository) => _repos.Add(repository.Alias, repository);

    public IFileProvider GetProvider(string repositoryAlias) => new FileProvider(_root, GetRepository(repositoryAlias));

    public IEnumerable<RepositoryResource> GetRepositories() => _repos.Values;

    public RepositoryResource GetRepository(string alias)
    {
        if (!_repos.TryGetValue(alias, out var repo))
        {
            repo = new RepositoryResource { Alias = alias };
            _repos.Add(alias, repo);
        }

        return repo;
    }
}
