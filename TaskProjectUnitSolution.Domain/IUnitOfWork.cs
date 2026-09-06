using TaskProjectUnitSolution.Domain.Repositories;

namespace TaskProjectUnitSolution.Domain;

public interface IUnitOfWork : IDisposable
{
    public IProjectRepository Project { get; }
    
    Task<int> CommitAsync(CancellationToken cancellationToken);
}
