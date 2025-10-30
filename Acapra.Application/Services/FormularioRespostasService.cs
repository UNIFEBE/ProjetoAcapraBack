using Acapra.Application.Interfaces;
using Acapra.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acapra.Domain.Entities;
using Acapra.Domain.DTOs;

namespace Acapra.Application.Services
{
    public class FormularioRespostasService : IFormularioRespostasServices
    {
        private readonly IFormularioRespostasRepository _formularioRespostasRepository;
        public FormularioRespostasService(IFormularioRespostasRepository formularioRespostasRepository)
        {
            _formularioRespostasRepository = formularioRespostasRepository;
        }

        public List<FormularioRespostasModel> ListarRespostas()
        {
            return _formularioRespostasRepository.ListarRespostas();
        }

        public bool CadastrarRespostas(int id, List<CadastroRespostas> respostas)
        {
            return _formularioRespostasRepository.CadastrarRespostas(id, respostas);
        }

        public IEnumerable<ConsultaRespostasUsuario> ConsultaRespostas(int id)
        {
            return _formularioRespostasRepository.ConsultaRespostas(id);
        }
    }
}
