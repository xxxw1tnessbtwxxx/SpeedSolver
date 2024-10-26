using SpeedSolverDatabase.Models;

namespace SpeedSolverCore.DTO.User;

public class Team
{
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public string TeamDescription { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int CreatorId { get; set; }
    public UserEntity? Creator { get; set; }
    public List<TeamObjective>? Objectives { get; set; }
    public List<Project>? Projects { get; set; }
}