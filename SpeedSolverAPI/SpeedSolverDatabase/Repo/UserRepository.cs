using Microsoft.EntityFrameworkCore;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Repo.abc;

namespace SpeedSolverDatabase.Repo;

public class UserRepository() : IRepository<User>
{
    private SpeedContext? _context = new SpeedContext();
    public void Insert(User entity)
    {
        this._context?.Users.AddAsync(entity);
        this._context?.SaveChanges();
    }

    public List<User> FindAll()
    {
        throw new NotImplementedException();
    }

    public User FindById(int id)
    {
        throw new NotImplementedException();
    }
}