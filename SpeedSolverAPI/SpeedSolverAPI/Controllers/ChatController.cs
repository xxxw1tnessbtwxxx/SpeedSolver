using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedSolverAPI.DTO.Chat;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Services;


namespace SpeedSolverAPI.Controllers
{
    [Route("api/v1/inprojectchats")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        [HttpPost("postMessage")]
        public async Task<IActionResult> PostMessage(ProjectMessageCreateDto messageModel)
        {
            var chatService = ChatService.Create();
            var isComplete = await chatService.InsertMessage(messageModel);
            if (isComplete) return Ok();
            return BadRequest();
        }

    }
}
