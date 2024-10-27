using AutoMapper;
using SpeedSolverCore.DTO.User;
using SpeedSolverDatabase.Models;

namespace SpeedSolverAPI.Mapper.Profiles;

public class ProjectMapper: Profile
{
    public ProjectMapper()
    {
        CreateMap<ProjectEntity, Project>();
    }
}