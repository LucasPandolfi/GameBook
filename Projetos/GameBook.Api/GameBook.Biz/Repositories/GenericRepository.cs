using GameBook.Biz.Interfaces;
using GameBook.Data.Context;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace GameBook.Biz.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal GameBookContext _context;

        internal GenericRepository(GameBookContext context)
        {
            _context = context;
        }

        internal GenericRepository()
        {
            _context = new GameBookContext();
        }

        public IQueryable<TEntity> Listar(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeProperties.Any())
                return Include(_context.Set<TEntity>(), includeProperties);

            return query;
        }

        public IQueryable<TEntity> ListarPor(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties)
        => Listar(includeProperties).Where(where);

        //public IQueryable<TEntity> ListarAtivos(params Expression<Func<TEntity, object>>[] includeProperties)
        //{
        //    IQueryable<TEntity> query = _context.Set<TEntity>();

        //    if (PropriedadeExiste(query, "Fl_Ativo"))
        //    {
        //        query = query.Where("Fl_Ativo != false").AsQueryable();
        //    }

        //    if (includeProperties.Any())
        //        return Include(_context.Set<TEntity>(), includeProperties);

        //    return query;
        //}

        public IQueryable<TEntity> ListarAtivos(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            var entityType = typeof(TEntity);
            var hasFlAtivoProperty = PropriedadeExiste("Fl_Ativo");

            if (hasFlAtivoProperty)
            {
                query = query.Where(entity => EF.Property<bool>(entity, "Fl_Ativo"));
            }

            if (includeProperties.Any())
                return Include(query, includeProperties);

            return query;
        }

        public TEntity Adicionar(TEntity entidade, string responsavel)
        {
            if (PropriedadeExiste("Fl_Ativo") && PropriedadeExiste("Dt_Criacao") && PropriedadeExiste("Ds_Responsavel"))
            {
                ((dynamic)entidade).Fl_Ativo = true;
                ((dynamic)entidade).Dt_Criacao = DateTime.Now;
                ((dynamic)entidade).Ds_Responsavel = responsavel;

                _context.Set<TEntity>().Attach(entidade);
                _context.Entry(entidade).State = EntityState.Added;

                return entidade;
            }

            return Activator.CreateInstance<TEntity>();
        }

        public TEntity Editar(TEntity entidade, string responsavel)
        {
            if (PropriedadeExiste("Fl_Ativo") && PropriedadeExiste("Dt_Criacao") && PropriedadeExiste("Dt_UltimaAlteracao") && PropriedadeExiste("Ds_Responsavel"))
            {
                _context.Entry(entidade).Property("Fl_Ativo").IsModified = false;
                _context.Entry(entidade).Property("Dt_Criacao").IsModified = false;

                ((dynamic)entidade).Dt_UltimaAlteracao = DateTime.Now;
                ((dynamic)entidade).Ds_Responsavel = responsavel;

                _context.Entry(entidade).State = EntityState.Modified;

                return entidade;
            }

            return Activator.CreateInstance<TEntity>();
        }

        public TEntity Remover(int id, string responsavel)
        {
            TEntity entidade = _context.Set<TEntity>().Find(id);

            if (PropriedadeExiste("Fl_Ativo") && PropriedadeExiste("Dt_UltimaAlteracao") && PropriedadeExiste("Ds_Responsavel"))
            {
                ((dynamic)entidade).Fl_Ativo = false;
                ((dynamic)entidade).Dt_UltimaAlteracao = DateTime.Now;
                ((dynamic)entidade).Ds_Responsavel = responsavel;

                _context.Entry(entidade).State = EntityState.Modified;
            }

            return entidade ?? Activator.CreateInstance<TEntity>();
        }

        //public bool PropriedadeExiste(TEntity entidade, string nomePropriedade)
        //=> entidade.GetType().GetProperty(nomePropriedade) != null;

        public bool PropriedadeExiste(string nomePropriedade)
        {
            var entityType = typeof(TEntity);
            var property = entityType.GetProperty(nomePropriedade);

            return property != null;
        }

        public bool PropriedadeExiste(IQueryable<TEntity> entidades, string nomePropriedade)
        {
            foreach (var entidade in entidades)
            {
                if (!PropriedadeExiste(nomePropriedade))
                    return false;
            }

            return true;
        }

        public IQueryable<TEntity> Include(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
                query = query.Include(property);

            return query;
        }

        public bool Commit() => _context.SaveChanges() > 0;

        public void Dispose() => _context.Dispose();
    }
}
