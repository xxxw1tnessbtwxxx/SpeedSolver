using CSharpFunctionalExtensions;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabaseAccess.Repo.abc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverDatabaseAccess.Repo
{
    public class ChatRepository : AbcAccessProvider, IRepository<InProjectMessage>
    {
        public bool Delete(InProjectMessage entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<InProjectMessage> Filtered(Expression<Func<InProjectMessage, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public List<InProjectMessage> GetAll()
        {
            throw new NotImplementedException();
        }

        public InProjectMessage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Result<InProjectMessage> Insert(InProjectMessage entity)
        {
            throw new NotImplementedException();
        }

        public Result<InProjectMessage> Update(InProjectMessage entity)
        {
            throw new NotImplementedException();
        }
    }
}
