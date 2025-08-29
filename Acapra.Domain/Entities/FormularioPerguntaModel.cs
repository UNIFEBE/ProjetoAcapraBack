using Acapra.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Acapra.Domain.Entities
{
    public class FormularioPerguntaModel
    {
        public int id { get; set; }

        public int formulario_adocao_id { get; set; }

        public string pergunta { get; set; }

        public TipoResposta tipo_resposta { get; set; }

        public bool obrigatorio { get; set; } 

    }
}
