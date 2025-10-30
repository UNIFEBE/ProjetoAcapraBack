using System.Linq;
using Acapra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Acapra.Infra.Auth;
using Acapra.Domain.DTOs;
using Acapra.Domain.Interfaces.Repositories;
using Acapra.Infra.Context;

namespace Acapra.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AcapraDbContext _context;
        // private readonly JwtService _jwtService;

        public UsuarioRepository(AcapraDbContext context)
        {
            _context = context;
            // _jwtService = jwtService;
        }

        public bool EmailJaUtilizado(string email) =>
            _context.Set<UsuarioModel>().Any(u => u.email == email && u.ativo == true);

        private bool CpfJaUtilizado(string cpf) =>
            _context.Set<UsuarioModel>().Any(u => u.cpf == cpf && u.ativo == true);

        // Cadastrar usuário
        public ApiResponse<UsuarioModel> CadastrarUsuario(UsuarioModel usuario)
        {
            if (EmailJaUtilizado(usuario.email))
                return new ApiResponse<UsuarioModel>(409, "O e-mail informado já está em uso");

            if (CpfJaUtilizado(usuario.cpf))
                return new ApiResponse<UsuarioModel>(409, "O CPF informado já está em uso");

            usuario.senha = BCrypt.Net.BCrypt.HashPassword(usuario.senha);

            _context.Set<UsuarioModel>().Add(usuario);
            _context.SaveChanges();

            return new ApiResponse<UsuarioModel>(201, "Usuário cadastrado com sucesso", usuario);
        }

        // Login com JWT
        public ApiResponse<UsuarioModel> Login(string email, string senha)
        {
            var usuario = _context.Set<UsuarioModel>().FirstOrDefault(u => u.email == email);

            if (usuario == null)
                return new ApiResponse<UsuarioModel>(404, "Usuário não encontrado");

            if (usuario.ativo == false)
                return new ApiResponse<UsuarioModel>(404, "Usuário inativo");

            if (!BCrypt.Net.BCrypt.Verify(senha, usuario.senha))
                return new ApiResponse<UsuarioModel>(401, "Senha inválida");

            // var token = _jwtService.GerarToken(usuario);

            return new ApiResponse<UsuarioModel>(200, "Login realizado com sucesso", usuario);
        }

        public ApiResponse<UsuarioModel> RedefinirSenha(int id, string senhaNova)
        {
            var usuario = _context.Set<UsuarioModel>().Find(id);

            if (usuario == null)
                return new ApiResponse<UsuarioModel>(404, "Usuário não encontrado");

            usuario.senha = BCrypt.Net.BCrypt.HashPassword(senhaNova);

            _context.SaveChanges();

            return new ApiResponse<UsuarioModel>(200, "Senha atualizada com sucesso", usuario);
        }

        // Buscar usuário por ID
        public ApiResponse<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            var usuario = _context.Set<UsuarioModel>().Find(id);

            if (usuario == null)
                return new ApiResponse<UsuarioModel>(404, "Usuário não encontrado");

            return new ApiResponse<UsuarioModel>(200, "Usuário encontrado", usuario);
        }

        // Atualizar usuário
        public ApiResponse<UsuarioModel> AtualizarUsuario(int id, UsuarioModel usuarioAtualizado)
        {
            var usuario = _context.Set<UsuarioModel>().Find(id);

            if (usuario == null)
                return new ApiResponse<UsuarioModel>(404, "Usuário não encontrado");

            usuario.nome = string.IsNullOrWhiteSpace(usuarioAtualizado.nome) || usuarioAtualizado.nome == "string" ? usuario.nome : usuarioAtualizado.nome;
            usuario.email = string.IsNullOrWhiteSpace(usuarioAtualizado.email) || usuarioAtualizado.email == "string" ? usuario.email : usuarioAtualizado.email;
            usuario.cpf = string.IsNullOrWhiteSpace(usuarioAtualizado.cpf) || usuarioAtualizado.cpf == "string" ? usuario.cpf : usuarioAtualizado.cpf;
            usuario.celular = string.IsNullOrWhiteSpace(usuarioAtualizado.celular) || usuarioAtualizado.celular == "string" ? usuario.celular : usuarioAtualizado.celular;
            usuario.telefone = string.IsNullOrWhiteSpace(usuarioAtualizado.telefone) || usuarioAtualizado.telefone == "string" ? usuario.telefone : usuarioAtualizado.telefone;
            usuario.cep = string.IsNullOrWhiteSpace(usuarioAtualizado.cep) || usuarioAtualizado.cep == "string" ? usuario.cep : usuarioAtualizado.cep;
            usuario.cidade = string.IsNullOrWhiteSpace(usuarioAtualizado.cidade) || usuarioAtualizado.cidade == "string" ? usuario.cidade : usuarioAtualizado.cidade;
            usuario.estado = string.IsNullOrWhiteSpace(usuarioAtualizado.estado) || usuarioAtualizado.estado == "string" ? usuario.estado : usuarioAtualizado.estado;
            usuario.bairro = string.IsNullOrWhiteSpace(usuarioAtualizado.bairro) || usuarioAtualizado.bairro == "string" ? usuario.bairro : usuarioAtualizado.bairro;
            usuario.endereco = string.IsNullOrWhiteSpace(usuarioAtualizado.endereco) || usuarioAtualizado.endereco == "string" ? usuario.endereco : usuarioAtualizado.endereco;
            usuario.complemento = string.IsNullOrWhiteSpace(usuarioAtualizado.complemento) || usuarioAtualizado.complemento == "string" ? usuario.complemento : usuarioAtualizado.complemento;
            usuario.numero = string.IsNullOrWhiteSpace(usuarioAtualizado.numero) || usuarioAtualizado.numero == "string" ? usuario.numero : usuarioAtualizado.numero;

            usuario.tipo_usuario = usuarioAtualizado.tipo_usuario;

            usuario.ativo = usuarioAtualizado.ativo;

            _context.SaveChanges();

            var usuarioNovo = _context.Set<UsuarioModel>().Find(id);
            return new ApiResponse<UsuarioModel>(200, "Usuário atualizado com sucesso", usuarioNovo);
        }


        // Deletar usuário
        public ApiResponse<bool> DeletarUsuario(int id)
        {
            var usuario = _context.Set<UsuarioModel>().Find(id);

            if (usuario == null)
                return new ApiResponse<bool>(404, "Usuário não encontrado", false);

            usuario.ativo = false;
            // _context.Set<UsuarioModel>().Remove(usuario);
            _context.SaveChanges();

            return new ApiResponse<bool>(200, "Usuário deletado com sucesso", true);
        }
        public List<UsuarioModel> BuscarUsuarios()
        {
            var usuarios = _context.Set<UsuarioModel>().ToList();

            return usuarios;
        }
    }
}
