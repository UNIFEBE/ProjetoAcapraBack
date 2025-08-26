using Acapra.Application.Interfaces;
using Acapra.Domain.Entities;
using Acapra.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Application.Services
{
    public class ExemploService : IExemploService
    {
        private readonly IExemploRepository _exemploRepository;

        public ExemploService(IExemploRepository exemploRepository)
        {
            _exemploRepository = exemploRepository;
        }

        public List<PetModel> ListPets()
        {
            return _exemploRepository.ListPets();
        }
    }
}
