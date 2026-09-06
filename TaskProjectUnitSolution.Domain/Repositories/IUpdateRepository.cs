namespace TaskProjectUnitSolution.Domain.Repositories;
public interface IUpdateRepository<TEntity>
{
    void Update(TEntity entity);
    void UpdateRange(IEnumerable<TEntity> entitsies);
}
