using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace SpeedSolverDatabase.Models;

public class UserEntity
{

    public int UserId { get; set; }  
    public string Login { get; set; }
    public string Password { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? PhoneNumber { get; set; }
    
    public virtual List<TeamEntity>? Teams { get; set; }
    public virtual List<ProjectModeratorEntity>? ProjectModerated { get; set; }
    public virtual List<InvitationEntity>? Invites { get; set; }

}