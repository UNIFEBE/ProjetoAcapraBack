using Acapra.Domain.Entities;
using Acapra.Domain.Interfaces.Repositories;
using Acapra.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Acapra.Infra.Repositories
{
    public class FormularioPerguntaRepository : IFormularioPerguntaRepository
    {
        private readonly DbSet<FormularioPerguntaModel> _dbSet;
        private readonly AcapraDbContext _dbContext;

        public FormularioPerguntaRepository(AcapraDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<FormularioPerguntaModel>();
        }

        public List<FormularioPerguntaModel> ListarPerguntas()
        {
            return _dbSet.ToList();
        }

    }
}
