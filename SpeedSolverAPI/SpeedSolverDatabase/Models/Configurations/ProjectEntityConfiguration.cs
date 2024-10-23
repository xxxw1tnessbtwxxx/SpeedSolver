using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class ProjectEntityConfiguration: IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("projects");

        builder.HasKey(p => p.ProjectId);
        builder.Property(p => p.ProjectTitle)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(p => p.ProjectDescription)
            .HasMaxLength(300);


        builder.HasOne(p => p.Team)
            .WithMany(t => t.Projects)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}
