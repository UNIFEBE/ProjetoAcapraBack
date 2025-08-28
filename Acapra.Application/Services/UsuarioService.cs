using Acapra.Application.Interfaces;
using Acapra.Domain.DTOs;
using Acapra.Domain.Entities;
using Acapra.Domain.Interfaces.Repositories;

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

        public ApiResponse<string> Login(string email, string senha)
        {
            return _usuarioRepository.Login(email, senha);
        }

        public ApiResponse<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            return _usuarioRepository.BuscarUsuarioPorId(id);
        }

        public ApiResponse<UsuarioModel> AtualizarUsuario(UsuarioModel usuario)
        {
            return _usuarioRepository.AtualizarUsuario(usuario);
        }

        public ApiResponse<bool> DeletarUsuario(int id)
        {
            return _usuarioRepository.DeletarUsuario(id);
        }
    }
}
