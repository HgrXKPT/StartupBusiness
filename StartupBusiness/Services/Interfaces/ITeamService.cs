using StartupBusiness.DTOs.TeamDto;

namespace StartupBusiness.Services.Interfaces
{
    public interface ITeamService
    {
        Task CreateTeam(CreateTeamDto createTeamDto);
        Task DeleteTeam(int TeamId);
    }
}
