using System.ComponentModel.DataAnnotations;

namespace SpeedSolverCore;

public record AuthorizeRequest
{
    [Required] public string Login { get; init; }
    [Required] public string Password { get; init; }
    
}