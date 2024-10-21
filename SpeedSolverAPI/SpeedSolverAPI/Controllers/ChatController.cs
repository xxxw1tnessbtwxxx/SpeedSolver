using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedSolverAPI.DTO.Chat;
using SpeedSolverDatabaseAccess.Services;
using System.Formats.Asn1;


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
            return BadRequest("fail");
        }

        [HttpGet("getMessageHistory")]
        public async Task<IActionResult> GetMessageHistory(int projectId)
        {
            ChatService chatService = ChatService.Create();
            return Ok(await chatService.GetMessageHistory(projectId));
        }

        [HttpGet("prikolchik")]
        public async Task<IActionResult> Prikolyamba()
        {
            // asdasdasd
            return Ok(200);
        }

        [HttpGet("lalalala")]
        public async Task<IActionResult> ALalalala()
        {
            // asdasdasd
            return Ok(200);
        }

    }
}
