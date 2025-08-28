using System;

namespace Acapra.Domain.Entities
{
    public class UsuarioModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string telefone { get; set; }
        public string senha { get; set; }
        public string tipo_usuario { get; set; }
        public bool ativo { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string bairro { get; set; }
        public string endereco { get; set; }
        public string complemento { get; set; }
        public int numero { get; set; }
    }
}
