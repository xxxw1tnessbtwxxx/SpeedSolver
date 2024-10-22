using CSharpFunctionalExtensions;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabaseAccess.Repo.abc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverDatabaseAccess.Repo
{
    public class UserRepository() : AbcAccessProvider, IRepository<User>
    {
        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> Filtered(Expression<Func<User, bool>> expression)
        {
            return _context.Users.Where(expression);
        }

        public Result<User> Insert(User entity)
        {
            var user = _context.Users.Where(x => x.Login == entity.Login).FirstOrDefault();
            if (user is null)
            {
                _context.Users.Add(entity);
                _context.SaveChanges();
                return Result.Success<User>(entity);
            }

            return Result.Failure<User>("The user is still exists");
        }

        public Result<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
