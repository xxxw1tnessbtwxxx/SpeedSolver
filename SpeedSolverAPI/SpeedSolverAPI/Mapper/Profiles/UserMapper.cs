using AutoMapper;
using SpeedSolverCore.DTO.User;
using SpeedSolverDatabase.Models;

namespace SpeedSolverAPI.Mapper.Profiles;

public class UserMapper: Profile
{
    public UserMapper()
    {
        CreateMap<UserEntity, User>();
        CreateMap<ProjectModeratorEntity, ProjectModerator>();
        
    }
}