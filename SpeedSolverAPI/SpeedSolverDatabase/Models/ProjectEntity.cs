namespace SpeedSolverDatabase.Models;

public class ProjectEntity
{
    public int ProjectId { get; set; }
    public string ProjectTitle { get; set; }
    public string ProjectDescription { get; set; }
    public int TeamId { get; set; }
    public virtual TeamEntity? Team { get; set; }
    public virtual List<ObjectiveEntity>? Objectives { get; set; }
    public virtual List<ProjectModeratorEntity>? Moderators { get; set; }
    public virtual List<InProjectMessageEntity>? ChatHistory { get; set; }
}