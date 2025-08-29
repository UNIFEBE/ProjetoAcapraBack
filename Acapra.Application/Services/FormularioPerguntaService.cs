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
    public class FormularioPerguntaService : IFormularioPerguntaService
    {
        private readonly IFormularioPerguntaRepository _formularioPerguntaRepository;

        public FormularioPerguntaService(IFormularioPerguntaRepository formularioPerguntaRepository)
        {
            _formularioPerguntaRepository = formularioPerguntaRepository;
        }

        public List<FormularioPerguntaModel> ListarPerguntas()
        {
            return _formularioPerguntaRepository.ListarPerguntas();
        }
    }
}
