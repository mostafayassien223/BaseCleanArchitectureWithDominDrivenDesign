using Microsoft.EntityFrameworkCore;
using TaskProjectUnitSolution.Domain.Aggreagte.ProductAggreagte;
using TaskProjectUnitSolution.Domain.Aggreagte.ProjectAggreagte;

namespace TaskProjectUnitSolution.Infastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; } = default!;
        public DbSet<Units> Units { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }
    }
}
