namespace TaskProjectUnitSolution.Domain.Repositories;

public interface IDeleteRepository<TEntity>
{
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}
