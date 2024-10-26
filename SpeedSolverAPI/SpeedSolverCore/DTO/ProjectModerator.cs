using SpeedSolverDatabase.Models;

namespace SpeedSolverCore.DTO.User;

public class ProjectModerator
{
    public int ProjectModId { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public int SettedByUserId { get; set; }

    public Project? Project { get; set; }
    public User? User { get; set; }
    public User? SettedByUser { get; set; }
}