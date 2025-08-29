using Acapra.Application.Interfaces;
using Acapra.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Acapra.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        [Route("buscar-pets")]
        public IActionResult ListarPets()
        {
            var response = _petService.ListPets();
            if (response.Count > 0)
                return Ok(response);
            return NoContent();
        }

        [HttpGet]
        [Route("buscar-por-id/{id}")]
        public IActionResult GetPetByI(int id)
        {
            var response = _petService.GetPetById(id);
            if (response != null)
                return Ok(response);
            return NoContent();
        }

        [HttpGet]
        [Route("buscar-pets-disponiveis")]
        public IActionResult ListPetsAvailable()
        {
            var response = _petService.ListPetsAvailable();
            if (response.Count > 0)
                return Ok(response);
            return NoContent();
        }

        [HttpPost]
        [Route("inserir-imagem-pet/{id}")]
        public IActionResult InsertImagePet(int id, [FromForm] IFormFile image) 
        {
            if (image == null || image.Length == 0)
                return BadRequest("Nenhuma imagem enviada");


            byte[] imageBlob;

            using (var ms = new MemoryStream())
            {
                image.CopyTo(ms);
                imageBlob = ms.ToArray();
            }
            
            var response = _petService.InsertImagePet(id, imageBlob);
            if (response)
                return Ok(new {Id = id, Mensagem = "Imagem cadastrada com sucesso"});
            return BadRequest("Não foi possivel inserir a imagem");

        }

        [HttpPost]
        [Route("inserir-pet")]
        public IActionResult InsertPet([FromBody] PetModel pet)
        {
            var response = _petService.InsertPet(pet);
            if(response != null)
                return Ok(response);
            return BadRequest("Não foi possivel inserir o Pet");
        }

        [HttpPut]
        [Route("atualizar-pet/{id}")]
        public IActionResult UpdatePet(int id, [FromBody] PetModel pet)
        {
            var response = _petService.UpdatePet(id, pet);
            if (response != null)
                return Ok(response);
            return BadRequest("Não foi possivel alterar o pet");
        }

    }
}
