namespace SpeedSolverCore.DTO.User;

public class UnderObjective
{
    public int UnderObjectiveId { get; set; }
    public string UnderObjectiveTitle { get; set; }
    public int GeneralObjectiveId { get; set; }
    
    public virtual Objective? GeneralObjective { get; set; }
}