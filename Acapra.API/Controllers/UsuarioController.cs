using Acapra.Application.Interfaces;
using Acapra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Acapra.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("cadastrar-usuario")]
        public IActionResult CadastrarUsuario([FromBody] UsuarioModel usuario)
        {
            var response = _usuarioService.CadastrarUsuario(usuario);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] dynamic dadosLogin)
        {
            string email = dadosLogin.email;
            string senha = dadosLogin.senha;

            var response = _usuarioService.Login(email, senha);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        [Route("buscar-usuario/{id}")]
        public IActionResult BuscarUsuarioPorId(int id)
        {
            var response = _usuarioService.BuscarUsuarioPorId(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [Route("atualizar-usuario")]
        public IActionResult AtualizarUsuario([FromBody] UsuarioModel usuario)
        {
            var response = _usuarioService.AtualizarUsuario(usuario);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("deletar-usuario/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            var response = _usuarioService.DeletarUsuario(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
