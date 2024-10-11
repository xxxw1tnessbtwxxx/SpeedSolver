namespace SpeedSolverDatabase.Models;

public class TeamObjective
{
    public int TeamObjectiveId { get; set; }
    public int TeamId { get; set; }
    public int ObjectiveId { get; set; }

    public Team? Team { get; set; }
    public List<Objective>? Objectives { get; set; }
}