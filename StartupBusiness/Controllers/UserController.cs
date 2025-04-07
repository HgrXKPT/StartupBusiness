using Microsoft.AspNetCore.Mvc;
using StartupBusiness.Core.Exceptions;
using StartupBusiness.Data;
using StartupBusiness.DTOs.UserDto;
using StartupBusiness.Models;
using StartupBusiness.Services.Implementations;
using StartupBusiness.Services.Interfaces;

namespace StartupBusiness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }



        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            try
            {
                await _userService.CreateUser(createUserDto);
                return Ok(new
                {
                    mensagem = "Usuario criado com sucesso"
                });
            }catch(ArgumentNullException)
            {
                return BadRequest(new
                {
                    mensagem = "invalid data entry"
                });
            }catch(DbExistingUserExeception ex)
            {
                return Conflict(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            }


        }
}
