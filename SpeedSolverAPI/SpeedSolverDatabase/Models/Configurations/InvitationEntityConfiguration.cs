using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpeedSolverDatabase.Models.Configurations;

public class InvitationEntityConfiguration: IEntityTypeConfiguration<InvitationEntity>
{
    public void Configure(EntityTypeBuilder<InvitationEntity> builder)
    {
        builder.ToTable("invitations").HasKey(i => i.InviteId);

        builder.Property(i => i.UserId).IsRequired();
        builder.Property(i => i.ToTeamId).IsRequired();

        builder.HasOne(i => i.InvitedByLeader)
            .WithMany()
            .HasForeignKey(i => i.InvitedByLeaderId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(i => i.User)
            .WithMany(u => u.Invites)
            .HasForeignKey(i => i.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}