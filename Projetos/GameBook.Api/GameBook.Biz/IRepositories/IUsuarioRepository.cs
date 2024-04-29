using GameBook.Data.Models;
using GameBook.Entities;
using GameBook.Entities.Usuario;

namespace GameBook.Biz.Interfaces
{
    public interface IUsuarioRepository
    {
        List<UsuarioResponse> ListarTodosUsuarios();
        List<UsuarioResponse> ListarTodosUsuariosAtivos();
        UsuarioResponse? ListarUsuarioPorIdUsuario(int idUsuario);
        UsuarioResponse? ListarUsuarioPorDocumento(string documento);
        Resposta<UsuarioResponse> AdicionarUsuario(UsuarioRequest usuario, string responsavel);
        Resposta<UsuarioResponse> EditarUsuario(UsuarioRequest usuario, string responsavel);
        bool DeletarUsuario(int id, string responsavel);
        bool UsuarioExiste(string documento);
    }
}
