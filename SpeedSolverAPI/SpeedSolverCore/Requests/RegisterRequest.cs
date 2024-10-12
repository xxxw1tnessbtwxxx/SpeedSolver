using System.ComponentModel.DataAnnotations;

namespace SpeedSolverCore;

public class RegisterRequests
{
    [Required] public string Login { get; set; }
    [Required] public string Password { get; set; }
}