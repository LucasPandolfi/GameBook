using System.Linq.Expressions;

namespace GameBook.Biz.IRepositories.Base
{
    internal interface IGenericRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> ListarPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);

        public IQueryable<TEntity> Listar(params Expression<Func<TEntity, object>>[] includeProperties);

        public IQueryable<TEntity> ListarAtivos(params Expression<Func<TEntity, object>>[] includeProperties);

        public TEntity Adicionar(TEntity entidade, string responsavel);

        public TEntity Editar(TEntity entidade, string responsavel);

        public TEntity Remover(int id, string responsavel);

        public bool PropriedadeExiste(string nomePropriedade);

        public bool PropriedadeExiste(IQueryable<TEntity> entidades, string nomePropriedade);

        IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties);

        public bool Commit();
        public void Dispose();
    }
}
