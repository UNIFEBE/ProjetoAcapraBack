using System.Linq;
using Acapra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using Acapra.Infra.Auth;
using Acapra.Domain.DTOs;
using Acapra.Domain.Interfaces.Repositories;

namespace Acapra.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbContext _context;
        private readonly JwtService _jwtService;

        public UsuarioRepository(DbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        private bool EmailJaUtilizado(string email) =>
            _context.Set<UsuarioModel>().Any(u => u.email == email);

        // Cadastrar usuário
        public ApiResponse<UsuarioModel> CadastrarUsuario(UsuarioModel usuario)
        {
            if (EmailJaUtilizado(usuario.email))
                return new ApiResponse<UsuarioModel>(409, "O e-mail informado já está em uso");

            usuario.senha = BCrypt.Net.BCrypt.HashPassword(usuario.senha);

            _context.Set<UsuarioModel>().Add(usuario);
            _context.SaveChanges();

            return new ApiResponse<UsuarioModel>(201, "Usuário cadastrado com sucesso", usuario);
        }

        // Login com JWT
        public ApiResponse<string> Login(string email, string senha)
        {
            var usuario = _context.Set<UsuarioModel>().FirstOrDefault(u => u.email == email);

            if (usuario == null)
                return new ApiResponse<string>(404, "Usuário não encontrado");

            if (!BCrypt.Net.BCrypt.Verify(senha, usuario.senha))
                return new ApiResponse<string>(401, "Senha inválida");

            var token = _jwtService.GerarToken(usuario);

            return new ApiResponse<string>(200, "Login realizado com sucesso", token);
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
        public ApiResponse<UsuarioModel> AtualizarUsuario(UsuarioModel usuarioAtualizado)
        {
            var usuario = _context.Set<UsuarioModel>().Find(usuarioAtualizado.id);

            if (usuario == null)
                return new ApiResponse<UsuarioModel>(404, "Usuário não encontrado");

            usuario.nome = usuarioAtualizado.nome;
            usuario.email = usuarioAtualizado.email;
            usuario.celular = usuarioAtualizado.celular;
            usuario.telefone = usuarioAtualizado.telefone;
            usuario.tipo_usuario = usuarioAtualizado.tipo_usuario;
            usuario.ativo = usuarioAtualizado.ativo;
            usuario.cep = usuarioAtualizado.cep;
            usuario.cidade = usuarioAtualizado.cidade;
            usuario.estado = usuarioAtualizado.estado;
            usuario.bairro = usuarioAtualizado.bairro;
            usuario.endereco = usuarioAtualizado.endereco;
            usuario.complemento = usuarioAtualizado.complemento;

            _context.SaveChanges();

            return new ApiResponse<UsuarioModel>(200, "Usuário atualizado com sucesso", usuario);
        }

        // Deletar usuário
        public ApiResponse<bool> DeletarUsuario(int id)
        {
            var usuario = _context.Set<UsuarioModel>().Find(id);

            if (usuario == null)
                return new ApiResponse<bool>(404, "Usuário não encontrado", false);

            _context.Set<UsuarioModel>().Remove(usuario);
            _context.SaveChanges();

            return new ApiResponse<bool>(200, "Usuário deletado com sucesso", true);
        }
    }
}
