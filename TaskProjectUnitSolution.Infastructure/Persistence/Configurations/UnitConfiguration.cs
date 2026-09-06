using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskProjectUnitSolution.Domain.Aggreagte.ProjectAggreagte;

namespace TaskProjectUnitSolution.Infastructure.Persistence.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Units>
    {
        public void Configure(EntityTypeBuilder<Units> builder)
        {
            builder.ToTable("Units");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descrption)
           .HasMaxLength(1000);

            builder.Property(c => c.Location)
                .HasMaxLength(100);

            builder.Property(c => c.UnitArea)
            .IsRequired()
            .HasColumnType("int");

            builder.Property(c => c.NumberOfRooms)
            .IsRequired()
            .HasColumnType("int");


            builder.HasOne(e => e.Project)
               .WithMany(e => e.Units)
               .HasForeignKey(e => e.ProjectId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
