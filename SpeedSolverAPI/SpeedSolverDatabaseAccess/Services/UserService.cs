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
    public class UserService: Service<UserEntity>
    {

        public static UserService Create() => new UserService();
        private UserService()
        {
            this._repository = new UserRepository();
        }
        
        public async Task<Result<UserEntity>> Register(RegisterRequest registerRequest)
        {
            var insertingResult = _repository.Insert(new UserEntity
            {
                Login = registerRequest.Login,
                Password = registerRequest.Password
            });
            
            if (insertingResult.IsSuccess)
            {
                return Result.Success(insertingResult.Value);
            }

            return Result.Failure<UserEntity>("This user still exists. Try again with new credentials");

        }

        public async Task<Result<UserEntity>> Authorize(AuthorizeRequest authorizeRequest)
        {
            return Result.Failure<UserEntity>(string.Empty);
        }
        
    }
}
