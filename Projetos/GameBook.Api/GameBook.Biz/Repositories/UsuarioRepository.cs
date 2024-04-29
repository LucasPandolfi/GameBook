using FluentValidation;
using GameBook.Biz.Interfaces;
using GameBook.Biz.Mappers;
using GameBook.Data.Models;
using GameBook.Entities;
using GameBook.Entities.Usuario;

namespace GameBook.Biz.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly GenericRepository<Usuario> _genericRepository;

        private readonly IValidator<Usuario> _validator;


        public UsuarioRepository(GenericRepository<Usuario> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public UsuarioRepository()
        {
            _genericRepository = new GenericRepository<Usuario>();
        }

        public List<UsuarioResponse> ListarTodosUsuarios()
        {
            List<Usuario> usuariosEncontrados = _genericRepository.Listar().ToList();

            if (usuariosEncontrados == null) return new();

            List<UsuarioResponse> usuariosConvertidos = UsuarioResponseMapper.Converter(usuariosEncontrados).ToList();

            return usuariosConvertidos;
        }

        public List<UsuarioResponse> ListarTodosUsuariosAtivos()
        {
            List<Usuario> usuariosEncontrados = _genericRepository.ListarAtivos().ToList();
            if (usuariosEncontrados == null) return new();

            List<UsuarioResponse> usuariosConvertidos = UsuarioResponseMapper.Converter(usuariosEncontrados).ToList();

            return usuariosConvertidos;
        }

        public UsuarioResponse? ListarUsuarioPorIdUsuario(int idUsuario)
        {
            Usuario? usuarioEncontrado = _genericRepository.ListarPor(c => c.Id == idUsuario).FirstOrDefault();
            if(usuarioEncontrado == null) return null;

            UsuarioResponse usuarioConvertido = UsuarioResponseMapper.Converter(usuarioEncontrado);

            return usuarioConvertido;
        }

        public UsuarioResponse? ListarUsuarioPorDocumento(string documento)
        {
            Usuario? usuarioEncontrado = _genericRepository.ListarPor(c => c.Ds_Documento == documento).FirstOrDefault();
            if (usuarioEncontrado == null) return null;

            UsuarioResponse usuarioConvertido = UsuarioResponseMapper.Converter(usuarioEncontrado);

            return usuarioConvertido;
        }

        public Resposta<UsuarioResponse> AdicionarUsuario(UsuarioRequest usuario, string responsavel)
        {
            try
            {
                if(UsuarioExiste(usuario.Documento))
                    return new Entities.Resposta<UsuarioResponse>(false, $"O seguinte documento {usuario.Documento} já possui cadastro no sistema", null);

                Usuario usuarioModel = UsuarioRequestMapper.Converter(usuario);

                Usuario usuarioAdicionado = _genericRepository.Adicionar(usuarioModel, responsavel);

                _genericRepository.Commit();
                _genericRepository.Dispose();

                UsuarioResponse resp = UsuarioResponseMapper.Converter(usuarioAdicionado);

                return new Entities.Resposta<UsuarioResponse>(true, "", resp);
            }
            catch (Exception err)
            {
                /*Pensar em alguma forma de tratar essas Exceptions, talvez um banco de log?*/
                Console.WriteLine(err);
                return new Entities.Resposta<UsuarioResponse>(false, $"Error: {err.Message}", null);
            }
        }

        public Resposta<UsuarioResponse> EditarUsuario(UsuarioRequest usuario, string responsavel)
        {
            try
            {
                UsuarioResponse? usuarioEncontrado = ListarUsuarioPorDocumento(usuario.Documento);
                if (usuarioEncontrado == null)
                    return new Entities.Resposta<UsuarioResponse>(false, $"O usuário com o seguinte documento {usuario.Documento} não possui cadastro no sistema", null);

                Usuario usuarioModel = UsuarioRequestMapper.Converter(usuario);

                Usuario usuarioEditado = _genericRepository.Editar(usuarioModel, responsavel);

                _genericRepository.Commit();
                _genericRepository.Dispose();

                UsuarioResponse resp = UsuarioResponseMapper.Converter(usuarioEditado);

                return new Entities.Resposta<UsuarioResponse>(true, "", resp);
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return new Entities.Resposta<UsuarioResponse>(false, $"Error: {err.Message}", null);
            }
        }

        public bool DeletarUsuario(int id, string responsavel)
        {
            try
            {
                Usuario usuarioDeletado = _genericRepository.Remover(id, responsavel);

                _genericRepository.Commit();
                _genericRepository.Dispose();

                if(usuarioDeletado == null)
                    return false;

                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        public bool UsuarioExiste(string documento)
        {
            if(documento == null)
                return false;

            Usuario? usuarioEncontrado = _genericRepository.ListarPor(c => c.Ds_Documento == documento).FirstOrDefault();

            if (usuarioEncontrado == null) return false;

            return true;
        }
    }
}
