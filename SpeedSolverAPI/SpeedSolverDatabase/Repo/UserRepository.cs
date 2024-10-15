using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Repo.abc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverDatabase.Repo
{
    public class UserRepository() : AbcAccessProvider, IRepository<User>
    {
        public void Delete(User entity)
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

        public bool Insert(User entity)
        {
            var user = _context.Users.Where(x => x.Login == entity.Login).FirstOrDefault();
            if (user is null)
            {
                _context.Users.Add(entity);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
