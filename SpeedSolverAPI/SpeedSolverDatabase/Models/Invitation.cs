namespace SpeedSolverDatabase.Models;

public class Invitation
{
    public int InviteId { get; set; }
    public int InvitedByLeaderId { get; set; }
    public int UserId { get; set; }
    public int ToTeamId { get; set; }
    
    public virtual User? User { get; set; }
    public virtual User? InvitedByLeader { get; set; }
    public virtual Team? ToTeam { get; set; }
}