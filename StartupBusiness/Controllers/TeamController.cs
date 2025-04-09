using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using StartupBusiness.Core.Exceptions;
using StartupBusiness.DTOs.TeamDto;
using StartupBusiness.Services.Interfaces;

namespace StartupBusiness.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {

        private readonly ITeamService _teamservice;

        public TeamController(ITeamService teamservice)
        {
            _teamservice = teamservice;
        }

        [HttpPost("CreateTeam")]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamDto createTeamDto)
        {

            try
            {
                await _teamservice.CreateTeam(createTeamDto);
                return CreatedAtAction(nameof(CreateTeam), new
                {
                    message = "Team craeted sucessfuly"
                });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(DbExistingDataExeception ex)
            {
                return Conflict(ex.Message);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }



        }

    }
}
