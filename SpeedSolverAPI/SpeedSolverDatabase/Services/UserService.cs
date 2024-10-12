using SpeedSolverCore;
using SpeedSolverDatabase.Helpers;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Repo;
using SpeedSolverDatabase.Repo.abc;
using SpeedSolverDatabase.Services.abc;

namespace SpeedSolverDatabase.Services;

public class UserService(IRepository<User> repo): IUserService
{
    public async Task Register(RegisterRequests registerRequest)
    {
        try
        {
            repo.Insert(new User
            {
                Login = registerRequest.Login,
                Password = Crypto.HashPassword(registerRequest.Password)
            });
        }
        catch (Exception ex)
        {

        }
        
    }
    
}
