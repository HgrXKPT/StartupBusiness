using Microsoft.AspNetCore.Mvc;
using StartupBusiness.Data;
using StartupBusiness.Models;

namespace StartupBusiness.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {



        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            //Provisorio para não ocorrer mais erros durante a criação
            await Task.Delay(100);

            return Ok(new { mensagem = "Usuario criado com sucesso" } );

        }
       

    }
}
