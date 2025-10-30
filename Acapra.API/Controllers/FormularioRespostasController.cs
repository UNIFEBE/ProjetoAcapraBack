using Acapra.Application.Interfaces;
using Acapra.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Acapra.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormularioRespostasController : ControllerBase
    {
        private readonly IFormularioRespostasServices _formularioRespostasService;

        public FormularioRespostasController(IFormularioRespostasServices formularioRespostasService)
        {
            _formularioRespostasService = formularioRespostasService;
        }

        [HttpGet]
        [Route("buscar-respostas")]
        public IActionResult ListarRespostas()
        {
            var response = _formularioRespostasService.ListarRespostas();
            if (response.Count > 0)
                return Ok(response);
            return NoContent();
        }

        [HttpPost]
        [Route("cadastrar-respostas/{id}")]
        public bool CadastrarRespostas(int id, [FromBody] List<CadastroRespostas> respostas)
        {
            return _formularioRespostasService.CadastrarRespostas(id, respostas);

        }

        [HttpGet]
        [Route("busca-respostas-usuario/{id}")]
        public IActionResult BuscarRespostasUsuario(int id)
        {
            var response = _formularioRespostasService.ConsultaRespostas(id);
            if (response.Any())
                return Ok(response);
            return NoContent();
        } 
    }
}


