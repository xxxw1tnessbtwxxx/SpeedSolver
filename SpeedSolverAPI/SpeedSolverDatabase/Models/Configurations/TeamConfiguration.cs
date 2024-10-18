using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("teams").HasKey(t => t.TeamId);


        builder.Property(t => t.CreatedAt).HasColumnType("timestamp without time zone");

        builder.Property(t => t.TeamName)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(t => t.TeamDescription)
            .HasMaxLength(100);
        
        builder.HasOne(t => t.Creator)
            .WithMany(c => c.Teams)
            .HasForeignKey(t => t.CreatorId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.HasMany(t => t.Projects)
            .WithOne(t => t.Team)
            .HasForeignKey(p => p.TeamId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}