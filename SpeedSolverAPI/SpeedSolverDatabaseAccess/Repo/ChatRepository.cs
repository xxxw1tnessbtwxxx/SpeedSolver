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
    public class ChatRepository : AbcAccessProvider, IRepository<InProjectMessageEntity>
    {
        public bool Delete(InProjectMessageEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<InProjectMessageEntity> Filtered(Expression<Func<InProjectMessageEntity, bool>> expression)
        {
            return _context.InProjectMessages.Where(expression);
        }

        public Result<List<InProjectMessageEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Result<InProjectMessageEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Result<InProjectMessageEntity> Insert(InProjectMessageEntity entity)
        {
            throw new NotImplementedException();
        }

        public Result<InProjectMessageEntity> Update(InProjectMessageEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
