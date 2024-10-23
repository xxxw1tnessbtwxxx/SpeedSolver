namespace SpeedSolverDatabase.Models;

public class ObjectiveEntity
{
    public int ObjectiveId { get; set; }
    public int ProjectId { get; set; }
    public string ObjectiveTitle { get; set; }
    public string ObjectiveDescription { get; set; }
    public virtual ProjectEntity? Project { get; set; }
    public virtual List<UnderObjectiveEntity>? UnderObjectives { get; set; }
}