using Acapra.Domain.DTOs;
using Acapra.Domain.Entities;

namespace Acapra.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        ApiResponse<UsuarioModel> CadastrarUsuario(UsuarioModel usuario);
        ApiResponse<string> Login(string email, string senha);
        ApiResponse<UsuarioModel> BuscarUsuarioPorId(int id);
        ApiResponse<UsuarioModel> AtualizarUsuario(UsuarioModel usuario);
        ApiResponse<bool> DeletarUsuario(int id);
    }
}
