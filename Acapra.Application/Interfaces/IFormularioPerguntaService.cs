using Acapra.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Application.Interfaces
{
    public interface IFormularioPerguntaService
    {
        List<FormularioPerguntaModel> ListarPerguntas();
    }
}
