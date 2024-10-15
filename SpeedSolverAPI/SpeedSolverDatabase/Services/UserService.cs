using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SpeedSolverCore;
using SpeedSolverDatabase.Helpers;
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
        
        public async Task<User?> Register(RegisterRequest registerRequest)
        {
            string password = Crypto.HashPassword(registerRequest.Password);
            bool registered = this._repository.Insert(new User
            {
                Login = registerRequest.Login,
                Password = password
            });

            if (registered)
            {
                var user = this._repository.Filtered(x => x.Login == registerRequest.Login && x.Password == password).FirstOrDefault();
                return user;
            }

            return null;
        }
        
    }
}
