using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Domain.Entities
{
    public class FormularioRespostasModel
    {
        public int id {  get; set; }
        public int usuarioId { get; set; }
        public int formularioPerguntaId {  get; set; }
        public string? resposta { get; set; }
        public DateTime ultimaAlteracao { get; set; }



    }
}
