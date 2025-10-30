using Acapra.Domain.DTOs;
using Acapra.Domain.Entities;

namespace Acapra.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        ApiResponse<UsuarioModel> CadastrarUsuario(UsuarioModel usuario);
        ApiResponse<UsuarioModel> Login(string email, string senha);
        ApiResponse<UsuarioModel> RedefinirSenha(int id, string senhaNova);
        ApiResponse<UsuarioModel> BuscarUsuarioPorId(int id);
        ApiResponse<UsuarioModel> AtualizarUsuario(int id, UsuarioModel usuario);
        ApiResponse<bool> DeletarUsuario(int id);
        List<UsuarioModel> BuscarUsuarios();
        bool EmailJaUtilizado(string email);
    }
}
