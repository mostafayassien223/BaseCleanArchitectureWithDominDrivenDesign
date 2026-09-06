using Microsoft.EntityFrameworkCore;
using NewtonAffendi.Course.Domain.Common;
using TaskProjectUnitSolution.Domain.Aggreagte.ProductAggreagte;
using TaskProjectUnitSolution.Domain.Repositories;

namespace TaskProjectUnitSolution.Infastructure.Persistence.Repositories
{
    public class ProjectRepository : Repository<Project>,IProjectRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProjectRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        }

        public async Task<bool> CheckProjectExist(Guid id)
         => await _dbContext.Projects.AnyAsync(e => e.Id == id);

        public async Task<bool> CheckUniqueProjectCode(string projectcode,Guid? projectId)
        => await _dbContext.Projects.AnyAsync(e=>e.ProjectCode == projectcode && (projectId == null || e.Id != projectId));

        public async Task<Project> GetProjectById(Guid id)
        => await _dbContext.Projects.Include(e => e.Units).FirstOrDefaultAsync(e => e.Id == id);

        public async Task<BaseQueryResultModel<Project>> GetProjectList(int pageNumber, int pageSize, string? projectcode, string? projectname)
        {
            var query = _dbContext.Projects.AsQueryable();
            
            if (projectcode != null)
                query = query.Where(e => e.ProjectCode.Contains(projectcode));

            if (projectname != null)
                query = query.Where(e => e.Name.Contains(projectname));
            var items = await query.OrderByDescending(e => e.Created).AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var count = await query.CountAsync();

            return new BaseQueryResultModel<Project>(items, count);

        }
    }
}
