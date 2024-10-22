using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<Result<User?>> Register(RegisterRequest registerRequest)
        {
            string password = Crypto.HashPassword(registerRequest.Password);
            var insert = this._repository.Insert(User.Create(registerRequest.Login, registerRequest.Password).Value);
            if (insert.IsFailure)
            {
                return Result.Failure<User?>(insert.Error);
            }

            var userFromDb = this._repository.Filtered(x => x.Login == registerRequest.Login && x.Password == password).FirstOrDefault();
            return Result.Success<User?>(userFromDb);
        }

        public async Task<User?> Authorize(AuthorizeRequest authorizeRequest)
        {
            string password = Crypto.HashPassword(authorizeRequest.Password);
            var user = this._repository
                .Filtered(x => x.Login == authorizeRequest.Login && x.Password == password)
                .AsNoTracking()
                .FirstOrDefault();

            if (user is null)
            {
                throw new FailedLoginException();
            }

            return user;
        }
        
    }
}
