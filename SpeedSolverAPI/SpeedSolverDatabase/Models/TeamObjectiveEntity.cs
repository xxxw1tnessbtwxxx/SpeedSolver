namespace SpeedSolverDatabase.Models;

public class TeamObjectiveEntity
{
    public int TeamObjectiveId { get; set; }
    public int TeamId { get; set; }
    public int ObjectiveId { get; set; }

    public TeamEntity? Team { get; set; }
    public List<ObjectiveEntity>? Objectives { get; set; }
}