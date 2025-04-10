using StartupBusiness.DTOs.TeamDto;
using StartupBusiness.Models;
using StartupBusiness.Repositories.Interfaces;
using StartupBusiness.Services.Interfaces;

namespace StartupBusiness.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository ?? throw new ArgumentNullException(nameof(teamRepository));
        }
        public async Task CreateTeam(CreateTeamDto createTeamDto)
        {
            if (createTeamDto.ProjectCount < 0 || createTeamDto.ProjectCount >4)
                    throw new ArgumentException("A valid number must be provided");
            if (createTeamDto.MemberCount < 0)
                throw new ArgumentException("A valid number must be provided");

            if (string.IsNullOrWhiteSpace(createTeamDto.TeamName))
                throw new ArgumentNullException("Team name must be a valid argument");

            var team = new Team(createTeamDto.TeamName, createTeamDto.MemberCount, createTeamDto.ProjectCount);

            await _teamRepository.CreateTeam(team);

        }

        public async Task DeleteTeam(int teamId)
        {
            if (teamId < 0)
                throw new ArgumentException("Invalid teamId number");

            await _teamRepository.DeleteTeam(teamId);
        }
    }
}
