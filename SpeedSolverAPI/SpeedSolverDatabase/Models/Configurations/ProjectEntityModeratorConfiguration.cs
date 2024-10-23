using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class ProjectEntityModeratorConfiguration: IEntityTypeConfiguration<ProjectModeratorEntity>
{
    public void Configure(EntityTypeBuilder<ProjectModeratorEntity> builder)
    {
        builder.ToTable("projectmoderators").HasKey(p => p.ProjectModId);

        builder.HasOne(p => p.User)
            .WithMany(u => u.ProjectModerated)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.SettedByUser)
            .WithMany()
            .HasForeignKey(f => f.SettedByUserId);
    }
}