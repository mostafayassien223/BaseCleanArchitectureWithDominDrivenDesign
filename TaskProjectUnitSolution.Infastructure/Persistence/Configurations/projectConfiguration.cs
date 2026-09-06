using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskProjectUnitSolution.Domain.Aggreagte.ProductAggreagte;

namespace TaskProjectUnitSolution.Infastructure.Persistence.Configurations
{
    public class projectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.ProjectCode)
                .HasMaxLength(5);

            builder.Property(c => c.Name)
                .HasMaxLength(100);

            builder.Property(c => c.Descrption)
                .HasMaxLength(1000);

            builder.Property(c => c.ProjectLocation)
                .HasMaxLength(100);

            builder.Property(c => c.NumberOfUnits)
            .IsRequired()
            .HasColumnType("int")
            .HasDefaultValue(1);

           

        }
    }
}
