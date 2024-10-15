using SpeedSolverDatabase.Repo.abc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverDatabase.Services.abc
{
    public abstract class Service<T> where T : class
    {
        public IRepository<T> _repository;
    }
}
