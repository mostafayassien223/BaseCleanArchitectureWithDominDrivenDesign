namespace TaskProjectUnitSolution.Domain.Repositories;

public interface IRepository<TEntity> : IAddRepository<TEntity>, IUpdateRepository<TEntity>, IDeleteRepository<TEntity> where TEntity : class
{
    
    
}
