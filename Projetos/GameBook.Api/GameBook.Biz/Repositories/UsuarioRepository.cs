using GameBook.Biz.Interfaces;
using GameBook.Data.Context;
using GameBook.Data.Models;
using GameBook.Entities.RequestsViewModel;

namespace GameBook.Biz.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(GameBookContext context) : base(context)
        {
        }

        public UsuarioRepository() : base(new GameBookContext())
        {
        }

        GameBookContext gameBookCtx = new GameBookContext();
        GenericRepository<Usuario> genericCtx = new GenericRepository<Usuario>();

        public List<Usuario> ListarTodosUsuarios()
        {
            return genericCtx.Listar().ToList();
        }

        public List<Usuario> ListarTodosUsuariosAtivos()
        {
            return genericCtx.ListarAtivos().ToList();
        }

        public Usuario ListarUsuarioPorId(int id)
        {
            return genericCtx.ListarPor(c => c.Id == id).FirstOrDefault();
        }

        public void AdicionarUsuario(UsuarioRequestViewModel usuario, string responsavel)
        {
            try
            {
                /*Criar um método para validar se os dados passados estão corretos. Ex: Documento... talvez o fluentValidation*/
                Usuario usuarioConvertido = Converter(usuario);

                genericCtx.Adicionar(usuarioConvertido, responsavel);

                genericCtx.Commit();
                genericCtx.Dispose();
            }
            catch (Exception err)
            {
                /*Pensar em alguma forma de tratar essas Exceptions, talvez um banco de log?*/
                throw;
            }  
        }

        public void EditarUsuario(UsuarioRequestViewModel usuario, string responsavel)
        {
            try
            {
                /*Criar um método para validar se os dados passados estão corretos. Ex: Documento... talvez o fluentValidation*/
                Usuario usuarioConvertido = Converter(usuario);

                genericCtx.Editar(usuarioConvertido, responsavel);

                genericCtx.Commit();

                /*Poderia usuar o baseCtx.Dispose(); aqui?*/
            }
            catch (Exception err)
            {
                /*Pensar em alguma forma de tratar essas Exceptions, talvez um banco de log?*/
                throw;
            }
        }

        public void DeletarUsuario(int id, string responsavel)
        {
            try
            {
                genericCtx.Remover(id, responsavel);

                genericCtx.Commit();

                /*Poderia usuar o baseCtx.Dispose(); aqui?*/
            }
            catch (Exception err)
            {
                /*Pensar em alguma forma de tratar essas Exceptions, talvez um banco de log?*/
                throw;
            }
        }

        public Usuario Converter(UsuarioRequestViewModel usuario)
        {
            if (usuario == null) return null;

            return new Usuario
            {
                Nome = usuario.Nome,
                Documento = usuario.Documento,
                Email = usuario.Email,
            };
        }
    }
}
