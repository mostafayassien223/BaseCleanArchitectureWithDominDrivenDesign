namespace TaskProjectUnitSolution.Domain.Repositories;

public interface IAddRepository<TEntity>
{
    Task Add(TEntity entity, CancellationToken cancellationToken);
    Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
}
