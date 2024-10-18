using SpeedSolverDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedSolverDatabaseAccess.Repo.abc
{
    public abstract class AbcAccessProvider
    {
        internal readonly SpeedContext _context = new SpeedContext();
    }
}
