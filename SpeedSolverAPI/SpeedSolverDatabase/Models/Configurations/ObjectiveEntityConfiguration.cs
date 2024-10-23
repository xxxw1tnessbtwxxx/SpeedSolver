using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class ObjectiveEntityConfiguration: IEntityTypeConfiguration<ObjectiveEntity>
{
    public void Configure(EntityTypeBuilder<ObjectiveEntity> builder)
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