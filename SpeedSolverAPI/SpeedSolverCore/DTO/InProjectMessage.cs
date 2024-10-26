using SpeedSolverDatabase.Models;

namespace SpeedSolverCore.DTO.User;

public class InProjectMessage
{
    public int MessageId { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public int ProjectId { get; set; }

    public DateTime SendedAt { get; set; } = DateTime.Now;
    public virtual Project? Project { get; set; }
    public virtual UserEntity? User { get; set; }
}