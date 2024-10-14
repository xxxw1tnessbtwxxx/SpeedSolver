using SpeedSolverDatabase.Repo.abc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverDatabase.Services.abc
{
    public class AbcService<T>(IRepository<T> _repository) where T: class
    {

    }
}
