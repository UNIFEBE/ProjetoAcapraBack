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
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public List<PetModel> ListPets()
        {
            return _petRepository.ListPets();
        }

        public PetModel? GetPetById(int id)
        {
            return _petRepository.GetPetById(id);
        }

        public List<PetModel> ListPetsAvailable()
        {
            return _petRepository.ListPetsAvailable();
        }

        public bool InsertImagePet(int id, byte[] imageBlob)
        {
            return _petRepository.InsertImagePet(id, imageBlob);
        }

        public PetModel? InsertPet(PetModel pet)
        {
            return _petRepository.InsertPet(pet);
        }

        public PetModel? UpdatePet(int id, PetModel pet)
        {
            return _petRepository.UpdatePet(id, pet);
        }
    }
}
