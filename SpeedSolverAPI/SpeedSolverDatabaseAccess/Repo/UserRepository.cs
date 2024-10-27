using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using SpeedSolverDatabase.Models;
using SpeedSolverDatabaseAccess.Repo.abc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using SpeedSolverCore.DTO.User;
using SpeedSolverDatabase.Helpers.Errors;

namespace SpeedSolverDatabaseAccess.Repo
{
    public class UserRepository() : AbcAccessProvider, IRepository<UserEntity>
    {
        public bool Delete(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Result<List<UserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Result<UserEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<UserEntity, string>> GetByLogin(string login)
        {
            var userFromDb = _context.Users.Where(x => x.Login == login)
                .AsNoTracking()
                .FirstOrDefault()
                .ToResult(error: "User not found");

            return userFromDb;
        }
        
        public IQueryable<UserEntity> Filtered(Expression<Func<UserEntity, bool>> expression)
        {
            return _context.Users.Where(expression);
        }

        public Result<UserEntity> Insert(UserEntity entity)
        {
            bool exists = _context.Users.Where(x => x.Login == entity.Login)
                .AsNoTracking()
                .FirstOrDefault() is null;
            if (exists)
            {
                _context.Users.Add(entity);
                _context.SaveChanges();
                return Result.Success<UserEntity>(entity);
            }

            return Result.Failure<UserEntity>("The user is still exists. Try new credentials");
        }

        public Result<UserEntity> Update(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
