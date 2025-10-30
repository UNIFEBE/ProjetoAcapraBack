using Acapra.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Acapra.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormularioPerguntaController : ControllerBase
    {
        private readonly IFormularioPerguntaService _formularioPerguntaService;

        public FormularioPerguntaController(IFormularioPerguntaService formularioPerguntaService)
        {
            _formularioPerguntaService = formularioPerguntaService;
        }

        [HttpGet]
        [Route("buscar-perguntas")]
        public IActionResult ListarPerguntas()
        {
            var response = _formularioPerguntaService.ListarPerguntas();
            if (response.Count > 0)
                return Ok(response);
            return NoContent();
        }
    }
}
