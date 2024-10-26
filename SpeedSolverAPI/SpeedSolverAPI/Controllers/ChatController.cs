using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedSolverAPI.DTO.Chat;
using SpeedSolverDatabaseAccess.Services;
using System.Formats.Asn1;
using Microsoft.AspNetCore.Authorization;


namespace SpeedSolverAPI.Controllers
{
    [Route("api/v1/inprojectchats")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        [HttpPost("postMessage")]
        public async Task<IActionResult> PostMessage(ProjectMessageCreateDto messageModel)
        {
            return NotFound();
        }
        
        [Authorize]
        [HttpGet("getMessageHistory")]
        public async Task<IActionResult> GetMessageHistory(int projectId)
        {
            ChatService chatService = ChatService.Create();
            return Ok(await chatService.GetMessageHistory(projectId));
        }


    }
}
