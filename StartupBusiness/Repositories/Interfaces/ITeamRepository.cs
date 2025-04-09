using StartupBusiness.DTOs.TeamDto;
using StartupBusiness.Models;

namespace StartupBusiness.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task CreateTeam(Team team);
    }
}
