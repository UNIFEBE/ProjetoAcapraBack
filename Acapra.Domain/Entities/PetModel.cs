using Acapra.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Acapra.Domain.Entities
{
    public class PetModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string sexo { get; set; }
        public string raca { get; set; }
        public DateTime data_nascimento { get; set; }
        public string pelagem { get; set; }
        public byte[]? imagem { get; set; }
        public bool castrado { get; set; }
        public bool vacinado { get; set; }

        public string porte { get; set; }

        public StatusPet status { get; set; }

    }
}
