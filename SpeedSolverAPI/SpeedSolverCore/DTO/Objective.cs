namespace SpeedSolverCore.DTO.User;

public class Objective
{
    public int ObjectiveId { get; set; }
    public int ProjectId { get; set; }
    public string ObjectiveTitle { get; set; }
    public string ObjectiveDescription { get; set; }
    public virtual Project? Project { get; set; }
    public virtual List<UnderObjective>? UnderObjectives { get; set; }
}