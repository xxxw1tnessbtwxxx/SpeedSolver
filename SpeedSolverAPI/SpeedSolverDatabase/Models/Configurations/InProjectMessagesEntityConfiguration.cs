using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class InProjectMessagesEntityConfiguration : IEntityTypeConfiguration<InProjectMessageEntity>
{
    public void Configure(EntityTypeBuilder<InProjectMessageEntity> builder)
    {
        builder.ToTable("messages").HasKey(p => p.MessageId);

        builder.Property(p => p.SendedAt).HasColumnType("timestamp without time zone");

        builder.HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(msg => msg.Project)
            .WithMany(p => p.ChatHistory)
            .HasForeignKey(p => p.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}