using Acapra.Domain.DTOs;
using Acapra.Domain.Entities;

namespace Acapra.Application.Interfaces
{
    public interface IUsuarioService
    {
        ApiResponse<UsuarioModel> CadastrarUsuario(UsuarioModel usuario);
        ApiResponse<string> Login(string email, string senha);
        ApiResponse<UsuarioModel> BuscarUsuarioPorId(int id);
        ApiResponse<UsuarioModel> AtualizarUsuario(UsuarioModel usuario);
        ApiResponse<bool> DeletarUsuario(int id);
    }
}
