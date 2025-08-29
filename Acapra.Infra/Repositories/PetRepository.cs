using Acapra.Domain.Entities;
using Acapra.Domain.Interfaces.Repositories;
using Acapra.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Acapra.Infra.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly DbSet<PetModel> _dbSet;
        private readonly AcapraDbContext _dbContext;

        public PetRepository(AcapraDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<PetModel>();
        }

        public List<PetModel> ListPets()
        {
            return _dbSet.ToList();
        }

        public PetModel? GetPetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.id == id);
        }

        public List<PetModel> ListPetsAvailable()
        {
            return _dbSet.Where(x => x.status == Domain.Enums.StatusPet.Disponivel).ToList();
        }

        public bool InsertImagePet(int id, byte[] imageBlob)
        {
            var pet = _dbSet.FirstOrDefault(p => p.id == id);

            if (pet == null)
                return false;

            pet.imagem = imageBlob;
            _dbContext.Update(pet);
            if(_dbContext.SaveChanges() > 0)
                return true;
            return false;

        }

        public PetModel? InsertPet(PetModel pet)
        {
            _dbContext.Add(pet);
            if(_dbContext.SaveChanges() > 0)
                return pet;
            return null;
        }

        public PetModel? UpdatePet(int id, PetModel varPet)
        {
            var pet = GetPetById(id);

            if (pet == null) return null;

            pet.nome = varPet.nome == "" ? pet.nome : varPet.nome;
            pet.descricao = varPet.descricao == "" ? pet.descricao : varPet.descricao;
            pet.sexo = varPet.sexo == "" ? pet.sexo : varPet.sexo;
            pet.raca = varPet.raca == "" ? pet.raca : varPet.raca;
            pet.porte = varPet.porte == "" ? pet.porte : varPet.porte;
            pet.data_nascimento = varPet.data_nascimento == DateTime.MinValue ? pet.data_nascimento : varPet.data_nascimento;
            pet.pelagem = varPet.pelagem == "" ? pet.pelagem : varPet.pelagem;
            pet.castrado = varPet.castrado;
            pet.vacinado = varPet.vacinado;

            _dbContext.Update(pet);
            if (_dbContext.SaveChanges() > 0)
                return pet;
            return null;

         }

    }
}
