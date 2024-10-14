using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Repo.abc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Insert(User entity)
        {
            
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
