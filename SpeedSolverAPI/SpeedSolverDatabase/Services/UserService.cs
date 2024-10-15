using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Repo;
using SpeedSolverDatabase.Services.abc;

namespace SpeedSolverDatabase.Services
{
    public class UserService: Service<User>
    {
        public UserService()
        {
            this._repository = new UserRepository();
        }
        
    }
}
