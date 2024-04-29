using GameBook.Data.Models;
using GameBook.Entities.Usuario;

namespace GameBook.Biz.Mappers
{
    internal class UsuarioRequestMapper
    {
        internal static List<Usuario> Converter(List<UsuarioRequest> usuarios)
        {
            if (usuarios == null) return new();

            List<Usuario> usuariosConvertidos = new List<Usuario>();

            foreach (var item in usuarios)
            {
                usuariosConvertidos.Add(Converter(item));
            }

            return usuariosConvertidos;
        }

        internal static Usuario Converter(UsuarioRequest usuario)
        {
            if (usuario == null) return new();

            return new Usuario
            {
                Nm_Usuario = usuario.Nome,
                Ds_Documento = usuario.Documento,
                Ds_Email = usuario.Email,
            };
        }
    }
}
