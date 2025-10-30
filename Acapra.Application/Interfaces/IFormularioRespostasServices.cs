using Acapra.Domain.DTOs;
using Acapra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Application.Interfaces
{
    public interface IFormularioRespostasServices
    {
        List<FormularioRespostasModel> ListarRespostas();
        bool CadastrarRespostas(int id, List<CadastroRespostas> respostas);
        IEnumerable<ConsultaRespostasUsuario> ConsultaRespostas(int id);
    }
}
