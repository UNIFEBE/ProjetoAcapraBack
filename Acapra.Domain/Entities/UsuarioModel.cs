using System;
using Acapra.Domain.Enums;

namespace Acapra.Domain.Entities
{
    public class UsuarioModel
    {
        public int id { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? cpf { get; set; }
        public string? celular { get; set; }
        public string? telefone { get; set; }
        public string? senha { get; set; }
        public TipoUsuario? tipo_usuario { get; set; }
        public bool? ativo { get; set; }
        public string? cep { get; set; }
        public string? cidade { get; set; }
        public string? estado { get; set; }
        public string? bairro { get; set; }
        public string? endereco { get; set; }
        public string? complemento { get; set; }
        public string? numero { get; set; }
    }
}
