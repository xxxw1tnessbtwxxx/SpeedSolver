using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using SpeedSolverCore.DTO.User;
using SpeedSolverDatabase.Models;

namespace SpeedSolverAPI.Mapper.Profiles;

public class TeamMapper: Profile
{
    public TeamMapper()
    {
        CreateMap<TeamEntity, Team>();
        CreateMap<TeamObjectiveEntity, TeamObjective>();
        CreateMap<UnderObjectiveEntity, UnderObjective>();
        CreateMap<InvitationEntity, Invitation>();
    }
}