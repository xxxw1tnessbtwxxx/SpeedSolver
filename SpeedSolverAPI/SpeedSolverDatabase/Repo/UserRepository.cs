using Microsoft.EntityFrameworkCore;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Repo.abc;

namespace SpeedSolverDatabase.Repo;

public class UserRepository() : IRepository<User>
{
    private SpeedContext _context = new SpeedContext();
    public void Insert(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
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