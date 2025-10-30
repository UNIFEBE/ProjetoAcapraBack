using Acapra.Domain.DTOs;
using Acapra.Domain.Entities;

namespace Acapra.Application.Interfaces
{
    public interface IUsuarioService
    {
        ApiResponse<UsuarioModel> CadastrarUsuario(UsuarioModel usuario);
        ApiResponse<UsuarioModel> Login(string email, string senha);
        ApiResponse<UsuarioModel> RedefinirSenha(string email, string novaSenha);
        ApiResponse<UsuarioModel> BuscarUsuarioPorId(int id);
        ApiResponse<UsuarioModel> AtualizarUsuario(int id, UsuarioModel usuario);
        ApiResponse<bool> DeletarUsuario(int id);
        List<UsuarioModel> BuscarUsuarios();
        bool VerificarEmail(string email);
    }
}
