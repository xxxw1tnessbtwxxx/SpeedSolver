using SpeedSolverCore;

namespace SpeedSolverDatabase.Services.abc;

public interface IUserService
{
    Task Register(RegisterRequests registerRequest);
}