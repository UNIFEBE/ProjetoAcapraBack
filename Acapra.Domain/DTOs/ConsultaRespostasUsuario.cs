using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acapra.Domain.DTOs
{
    public class ConsultaRespostasUsuario
    {
        public int id {  get; set; }
        public string usuario { get; set; }
        public string pergunta { get; set; }
        public string resposta { get; set; }
    }
}
