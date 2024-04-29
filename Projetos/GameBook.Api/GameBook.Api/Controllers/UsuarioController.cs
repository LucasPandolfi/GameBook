using GameBook.Biz.Interfaces;
using GameBook.Biz.Repositories;
using GameBook.Data.Models;
using GameBook.Entities;
using GameBook.Entities.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace GameBook.Api.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private const string RESPONSAVEL = "Sistema";
        IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios ativos e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de usuarios</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet("/listarusuarios")]
        public IActionResult ListarTodosUsuarios()
        {
            try
            {
                return Ok(_usuarioRepository.ListarTodosUsuarios());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista todos os usuarios ativos
        /// </summary>
        /// <returns>Uma lista de usuarios ativos e um status code 200 - Ok</returns>
        /// <response code="200">Retorna uma lista de usuarios ativos</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet("/listarusuariosativos")]
        public IActionResult ListarTodosUsuariosAtivos()
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

        /// <summary>
        /// Lista um usuario pelo id do usuario
        /// </summary>
        /// <returns>Retorna um usuario e um status code 200 - Ok</returns>
        /// <response code="200">Retorna um usuario</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet("/listarusuarioporid")]
        public IActionResult ListarUsuarioPorIdUsuario(int idUsuario)
        {
            try
            {
                return Ok(_usuarioRepository.ListarUsuarioPorIdUsuario(idUsuario));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Lista um usuario pelo id do usuario
        /// </summary>
        /// <returns>Retorna um usuario e um status code 200 - Ok</returns>
        /// <response code="200">Retorna um usuario</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpGet("/listarusuariopordoc")]
        public IActionResult ListarUsuarioPorDocumento(string documento)
        {
            try
            {
                return Ok(_usuarioRepository.ListarUsuarioPorDocumento(documento));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Adiciona um usuario
        /// </summary>
        /// <returns>Retorna um CreatedAtAction e um status code 201 - Ok</returns>
        /// <response code="200">Retorna um CreatedAtAction</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPost("/adicionarusuario")]
        public IActionResult AdicionarUsuario(UsuarioRequest usuario)
        {
            Resposta<UsuarioResponse> resp = _usuarioRepository.AdicionarUsuario(usuario, RESPONSAVEL);

            if(resp.Sucesso)
                return CreatedAtAction(nameof(ListarUsuarioPorIdUsuario), new { Id = resp.Objeto?.Id }, resp);

            return BadRequest(resp.Mensagem);       
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <returns>Retorna um Ok e um status code 200 - Ok</returns>
        /// <response code="200">Retorna um Ok</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpPut("/atualizarusuario")]
        public IActionResult EditarUsuario(UsuarioRequest usuario)
        {
            Resposta<UsuarioResponse> resp = _usuarioRepository.EditarUsuario(usuario, RESPONSAVEL);

            if (resp.Sucesso)
                return Ok(resp);

            return BadRequest(resp.Mensagem);
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <returns>Retorna um Ok e um status code 200 - Ok</returns>
        /// <response code="200">Retorna um Ok</response>
        /// <response code="400">Retorna o erro gerado</response>
        [HttpDelete("/deletarusuario")]
        public IActionResult DeletarUsuario(int id)
        {
            bool deletado = _usuarioRepository.DeletarUsuario(id, RESPONSAVEL);

            if (deletado)
                return Ok();

            return BadRequest($"Ocorreu um erro ao deletar o usuário com o seguinte ID {id}.");
        }
    }
}
