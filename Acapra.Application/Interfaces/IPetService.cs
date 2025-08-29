using Acapra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Application.Interfaces
{
    
    public interface IPetService
    {
        public List<PetModel> ListPets();

        PetModel? GetPetById(int id);
        List<PetModel> ListPetsAvailable();

        bool InsertImagePet(int id, byte[] imageBlob);

        PetModel? InsertPet(PetModel pet);

        PetModel? UpdatePet(int id, PetModel pet);


    }
}
