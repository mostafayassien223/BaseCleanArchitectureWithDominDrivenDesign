using TaskProjectUnitSolution.Domain;
using TaskProjectUnitSolution.Domain.Repositories;

namespace TaskProjectUnitSolution.Infastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed = false;
    private readonly ApplicationDbContext _applicationDbContext;

    public IProjectRepository Project { get; }


    public UnitOfWork(ApplicationDbContext applicationDbContext
        , IProjectRepository Project
       )
    {
        _applicationDbContext = applicationDbContext;
        this.Project = Project;
    
    }
    public async Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(this.GetType().FullName);
        }

        return await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;

        if (disposing && _applicationDbContext != null)
        {
            _applicationDbContext.Dispose();
        }

        _disposed = true;
    }
}
