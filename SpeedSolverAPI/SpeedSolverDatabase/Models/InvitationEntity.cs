namespace SpeedSolverDatabase.Models;

public class InvitationEntity
{
    public int InviteId { get; set; }
    public int InvitedByLeaderId { get; set; }
    public int UserId { get; set; }
    public int ToTeamId { get; set; }
    
    public virtual UserEntity? User { get; set; }
    public virtual UserEntity? InvitedByLeader { get; set; }
    public virtual TeamEntity? ToTeam { get; set; }
}