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
                return CreatedAtAction(nameof(CreateUser), 
                new
                {
                    message = "User created sucessfuly"
                } );

            }catch(ArgumentNullException)
            {
                return BadRequest(new
                {
                    message = "invalid data entry"
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

        [HttpPatch("UpdateUser")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody]UpdateUserDto userDto)
        {

            try
            {
                await _userService.UpdateUser(userId, userDto);
                return Ok(new
                {
                    message = "User updated sucessfuly"
                });
            }catch(KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = $"not found data: {ex.Message}"
                });
            }
            catch (ArgumentNullException)
            {
                return BadRequest(new
                {
                    message = "Enter valid data to update"
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = $"invalid data: {ex.Message}"
                });
            }


        }

        [HttpDelete("RemoveUser")]
        public async Task<IActionResult> RemoveUser(int userid)
        {

            try
            {

                await _userService.RemoveUser(userid);

                return Ok(new
                {
                    message = "User removed"
                });
            } catch(ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });

            }catch(KeyNotFoundException ex)
            {
                return NotFound(new
                {
                    message = ex.Message
                });
            }

        }


    }
}
