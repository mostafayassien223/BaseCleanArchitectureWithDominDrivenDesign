using TaskProjectUnitSolution.Domain.Repositories;

namespace TaskProjectUnitSolution.Infastructure.Persistence.Repositories
{
    public class Repository<TEntity> : IAddRepository<TEntity>, IUpdateRepository<TEntity>, IDeleteRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(TEntity entity, CancellationToken cancellationToken)
         => await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        public async Task AddRange(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        => await _dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        public void Update(TEntity entity)
            => _dbContext.Set<TEntity>().Update(entity);

        public void UpdateRange(IEnumerable<TEntity> entities)
            => _dbContext.Set<TEntity>().UpdateRange(entities);

        public void Remove(TEntity entity)
         => _dbContext.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities)
            => _dbContext.Set<TEntity>().RemoveRange(entities);

    }
}
