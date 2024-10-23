namespace SpeedSolverDatabase.Models;

public class TeamEntity
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public string TeamDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int CreatorId { get; set; }
    public UserEntity? Creator { get; set; }
    public List<TeamObjectiveEntity>? Objectives { get; set; }
    public List<ProjectEntity>? Projects { get; set; }
}