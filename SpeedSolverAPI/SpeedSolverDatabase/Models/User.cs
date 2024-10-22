using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace SpeedSolverDatabase.Models;

public class User
{

    public User()
    {

    }

    public int UserId { get; set; }  
    public string Login { get; set; }
    public string Password { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? PhoneNumber { get; set; }
    
    public virtual List<Team>? Teams { get; set; }
    public virtual List<ProjectModerator>? ProjectModerated { get; set; }
    public virtual List<Invitation>? Invites { get; set; }

    public static Result<User> Create(string login,
        string password,
        string name = null,
        string surname = null,
        string patronymic = null,
        string phonenumber = null)
    {
        if (string.IsNullOrEmpty(password) ||  string.IsNullOrEmpty(login))
        {
            return Result.Failure<User>("Login or password cannot be null");
        }

        return Result.Success(new User
        {
            Login = login,
            Password = password
        });
    }
}