using System.ComponentModel.DataAnnotations;

namespace SpeedSolverCore;

public record AuthorizeRequest
{
    [Required] string Login { get; init; }
    [Required] string Password { get; init; }

    public string GenerateBearerToken()
    {
        return "login:password";
    }
}