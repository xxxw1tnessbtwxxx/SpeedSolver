namespace SpeedSolverDatabase.Models;

public class ProjectModeratorEntity
{
    public int ProjectModId { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public int SettedByUserId { get; set; }

    public ProjectEntity? Project { get; set; }
    public UserEntity? User { get; set; }
    public UserEntity? SettedByUser { get; set; }
}