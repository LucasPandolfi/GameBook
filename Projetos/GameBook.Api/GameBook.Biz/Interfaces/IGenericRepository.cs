using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameBook.Biz.Interfaces
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
