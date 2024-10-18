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
        public void Delete(InProjectMessage entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<InProjectMessage> Filtered(Expression<Func<InProjectMessage, bool>> expression)
        {
            return _context.InProjectMessages.Where(expression);
        }

        public List<InProjectMessage> GetAll()
        {
            throw new NotImplementedException();
        }

        public InProjectMessage GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(InProjectMessage entity)
        {
            try
            {
                _context.InProjectMessages.Add(entity);
                _context.SaveChanges();
                Console.WriteLine("really added");
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public void Update(InProjectMessage entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
