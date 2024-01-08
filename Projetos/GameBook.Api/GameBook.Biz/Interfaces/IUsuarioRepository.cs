using GameBook.Data.Models;
using GameBook.Entities.RequestsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBook.Biz.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarTodosUsuarios();
        List<Usuario> ListarTodosUsuariosAtivos();
        Usuario ListarUsuarioPorId(int id);
        void AdicionarUsuario(UsuarioRequestViewModel usuario, string responsavel);
        void EditarUsuario(UsuarioRequestViewModel usuario, string responsavel);
        void DeletarUsuario(int id, string responsavel);
        Usuario Converter(UsuarioRequestViewModel usuario);
    }
}
