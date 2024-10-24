using System.ComponentModel.DataAnnotations;
using CSharpFunctionalExtensions;

namespace DesktopApp.DTO;

public class RegisterRequest
{
    private RegisterRequest(string login, string password)
    {
        Login = login;
        Password = password;
    }
    
    public string Login { get; }
    public string Password { get; }

    public static Result<RegisterRequest> Create(string login, string password)
    {
        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            return Result.Failure<RegisterRequest>("Логин или пароль не могут быть пустыми полями.");
        }

        return Result.Success(new RegisterRequest(login, password));
    }
}