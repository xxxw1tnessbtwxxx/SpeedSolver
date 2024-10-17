namespace SpeedSolverAPI.DTO.Chat
{
    public class ProjectMessageCreateDto
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
