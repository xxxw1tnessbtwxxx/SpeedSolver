using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class InProjectMessagesConfiguration : IEntityTypeConfiguration<InProjectMessage>
{
    public void Configure(EntityTypeBuilder<InProjectMessage> builder)
    {
        builder.ToTable("messages").HasKey(p => p.MessageId);

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