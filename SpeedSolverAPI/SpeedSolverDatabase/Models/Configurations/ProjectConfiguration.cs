using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class ProjectConfiguration: IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("projects");

        builder.HasKey(p => p.ProjectId);
        builder.Property(p => p.ProjectTitle)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(p => p.ProjectDescription)
            .HasMaxLength(300);
        
        
    }
}