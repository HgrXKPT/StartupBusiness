using Microsoft.EntityFrameworkCore;
using StartupBusiness.Core.Exceptions;
using StartupBusiness.Data;
using StartupBusiness.DTOs.TeamDto;
using StartupBusiness.Models;
using StartupBusiness.Repositories.Interfaces;

namespace StartupBusiness.Repositories.Implementations
{
    public class TeamRepository : ITeamRepository
    {

        private readonly AppDbContext _context;

        public TeamRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task CreateTeam(Team team)
        {
        
            var existingTeam = await _context.Teams.AnyAsync(t => t.TeamName == team.TeamName);
            if (existingTeam)
                throw new DbExistingDataExeception($"The team: {team.TeamName} alredy exists");

            _context.Add(team);
            await _context.SaveChangesAsync();

           
        }
    }
}
