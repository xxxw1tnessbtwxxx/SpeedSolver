using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SpeedSolverDatabase.Models;

namespace SpeedSolverDatabaseAccess.Repo.abc
{
    public interface IRepository<T>
    {
        public IQueryable<T> Filtered(Expression<Func<T, bool>> expression);
        public bool Insert(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void DeleteAll();
        public T GetById(int id);
        public List<T> GetAll();
    }
}
