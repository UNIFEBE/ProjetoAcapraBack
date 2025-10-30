using Acapra.Application.Interfaces;
using Acapra.Domain.DTOs;
using Acapra.Domain.Entities;
using Acapra.Domain.Interfaces.Repositories;
using AutoMapper;

namespace Acapra.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public ApiResponse<UsuarioModel> CadastrarUsuario(UsuarioModel usuario)
        {
            return _usuarioRepository.CadastrarUsuario(usuario);
        }

        public ApiResponse<UsuarioModel> Login(string email, string senha)
        {
            return _usuarioRepository.Login(email, senha);
        }

        public ApiResponse<UsuarioModel> RedefinirSenha(string email, string novaSenha)
        {
            return _usuarioRepository.RedefinirSenha(email, novaSenha);
        }

        public ApiResponse<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            return _usuarioRepository.BuscarUsuarioPorId(id);
        }

        public ApiResponse<UsuarioModel> AtualizarUsuario(int id, UsuarioModel usuario)
        {
            return _usuarioRepository.AtualizarUsuario(id, usuario);
        }

        public ApiResponse<bool> DeletarUsuario(int id)
        {
            return _usuarioRepository.DeletarUsuario(id);
        }

        public List<UsuarioModel> BuscarUsuarios()
        {
            var usuarios = _usuarioRepository.BuscarUsuarios();
            if (!(usuarios.Count > 0))
                return new List<UsuarioModel>();
            return usuarios;
        }

        public bool VerificarEmail(string email)
        {
            return _usuarioRepository.EmailJaUtilizado(email);
        }
    }
}
