﻿namespace SpeedSolverAPI.DTO.Chat
{
    public class ProjectMessageCreateDto
    {
        // dto for api
        public string Content { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
    }
}
