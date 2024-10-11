using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class ObjectiveConfiguration: IEntityTypeConfiguration<Objective>
{
    public void Configure(EntityTypeBuilder<Objective> builder)
    {
        builder.ToTable("objectives");

        builder.HasKey(o => o.ObjectiveId);
        
        builder.Property(o => o.ObjectiveTitle)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasOne(o => o.Project)
            .WithMany(p => p.Objectives)
            .HasForeignKey(o => o.ProjectId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}