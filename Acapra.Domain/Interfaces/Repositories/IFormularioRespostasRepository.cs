using Acapra.Domain.DTOs;
using Acapra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Domain.Interfaces.Repositories
{
    public interface IFormularioRespostasRepository
    {
        List<FormularioRespostasModel> ListarRespostas();

        bool CadastrarRespostas(int parm_id, List<CadastroRespostas> respostas);

        IEnumerable<ConsultaRespostasUsuario> ConsultaRespostas(int id);
    }
}
