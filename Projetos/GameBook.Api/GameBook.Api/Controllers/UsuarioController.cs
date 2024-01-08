using GameBook.Biz.Interfaces;
using GameBook.Biz.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GameBook.Api.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de usuarios</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet]
        public IActionResult ListarAtivos()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodosUsuariosAtivos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }
    }
}
