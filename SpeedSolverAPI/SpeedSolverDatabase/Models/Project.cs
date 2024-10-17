namespace SpeedSolverDatabase.Models;

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectTitle { get; set; }
    public string ProjectDescription { get; set; }
    
    public virtual List<Objective>? Objectives { get; set; }
    public virtual List<ProjectModerator>? Moderators { get; set; }
    public virtual List<InProjectMessage>? ChatHistory { get; set; }
}