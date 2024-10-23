namespace SpeedSolverDatabase.Models;

public class UnderObjectiveEntity
{
    public int UnderObjectiveId { get; set; }
    public string UnderObjectiveTitle { get; set; }
    public int GeneralObjectiveId { get; set; }
    
    public virtual ObjectiveEntity? GeneralObjective { get; set; }
}