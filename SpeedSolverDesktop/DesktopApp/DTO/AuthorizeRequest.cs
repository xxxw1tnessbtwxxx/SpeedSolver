using System.ComponentModel.DataAnnotations;

namespace DesktopApp.DTO;

public record AuthorizeRequest
{
    [Required] public string Login { get; init; }
    [Required] public string Password { get; init; }
    
}