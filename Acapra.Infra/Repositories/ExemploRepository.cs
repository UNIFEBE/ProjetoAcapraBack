using Acapra.Domain.Entities;
using Acapra.Domain.Interfaces.Repositories;
using Acapra.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Acapra.Infra.Repositories
{
    public class ExemploRepository : IExemploRepository
    {
        private readonly DbSet<PetModel> _dbSet;
        private readonly AcapraDbContext _dbContext;

        public ExemploRepository(AcapraDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<PetModel>();
        }

        public List<PetModel> ListPets()
        {
            return _dbSet.ToList();
        }

    }
}
