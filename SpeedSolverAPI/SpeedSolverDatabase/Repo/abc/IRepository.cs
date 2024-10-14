using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverDatabase.Repo.abc
{
    public interface IRepository<T>
    {
        public void Insert(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void DeleteAll();
        public T GetById(int id);
        public List<T> GetAll();
    }
}
