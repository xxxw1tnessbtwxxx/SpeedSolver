using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SpeedSolverCore;
using SpeedSolverDatabase.Helpers;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabase.Repo;
using SpeedSolverDatabase.Repo.Exceptions;
using SpeedSolverDatabaseAccess.Repo;
using SpeedSolverDatabaseAccess.Services.abc;

namespace SpeedSolverDatabaseAccess.Services
{
    public class UserService: Service<User>
    {

        public static UserService Create() => new UserService();
        private UserService()
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

        public async Task<User?> Authorize(AuthorizeRequest authorizeRequest)
        {
            string password = Crypto.HashPassword(authorizeRequest.Password);
            var user = this._repository
                .Filtered(x => x.Login == authorizeRequest.Login && x.Password == password)
                .FirstOrDefault();

            if (user is null)
            {
                throw new FailedLoginException();
            }

            return user;
        }
        
    }
}
