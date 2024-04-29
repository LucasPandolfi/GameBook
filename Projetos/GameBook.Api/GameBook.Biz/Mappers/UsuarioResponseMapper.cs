using GameBook.Data.Models;
using GameBook.Entities.Usuario;

namespace GameBook.Biz.Mappers
{
    public class UsuarioResponseMapper
    {
        internal static List<UsuarioResponse> Converter(List<Usuario> usuarios)
        {
            if(usuarios == null) return new();

            List<UsuarioResponse> usuariosConvertidos = new List<UsuarioResponse>();

            foreach (var item in usuarios)
            {
                usuariosConvertidos.Add(Converter(item));
            }

            return usuariosConvertidos;
        }

        internal static UsuarioResponse Converter(Usuario usuario)
        {
            if(usuario == null) return new();

            return new UsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nm_Usuario,
                Documento = usuario.Ds_Documento,
                Email = usuario.Ds_Email,
                Ativo = usuario.Fl_Ativo,
                DataCriacao = usuario.Dt_Criacao,
                DataUltimaAlteracao = usuario.Dt_UltimaAlteracao,
                Responsavel = usuario.Ds_Responsavel
            };
        }
    }
}
