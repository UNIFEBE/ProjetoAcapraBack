using Acapra.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Acapra.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExemploController : ControllerBase
    {
        private readonly IExemploService _exemploService;

        public ExemploController(IExemploService exemploService)
        {
            _exemploService = exemploService;
        }

        [HttpGet]
        [Route("buscar-pets-exemplo")]
        public IActionResult ListarPets()
        {
            var response = _exemploService.ListPets();
            if (response.Count > 0)
                return Ok(response);
            return NoContent();
        }
    }
}
