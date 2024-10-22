using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using SpeedSolverDatabase.Models;

namespace SpeedSolverDatabaseAccess.Repo.abc
{
    public interface IRepository<T>
    {
        public IQueryable<T> Filtered(Expression<Func<T, bool>> expression);
        public Result<T> Insert(T entity);
        public Result<T> Update(T entity);
        public bool Delete(T entity);
        public void DeleteAll();
        public T GetById(int id);
        public List<T> GetAll();
    }
}
