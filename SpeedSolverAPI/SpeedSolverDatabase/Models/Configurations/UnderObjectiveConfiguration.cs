using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class UnderObjectiveConfiguration: IEntityTypeConfiguration<UnderObjective>
{
    public void Configure(EntityTypeBuilder<UnderObjective> builder)
    {
        builder.ToTable("underobjectives").HasKey(u => u.UnderObjectiveId);
        
        builder.Property(u => u.UnderObjectiveTitle)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasOne(u => u.GeneralObjective)
            .WithMany(g => g.UnderObjectives)
            .HasForeignKey(u => u.GeneralObjectiveId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}