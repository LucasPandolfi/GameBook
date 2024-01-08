using GameBook.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace GameBook.Biz.Repositories.Base
{
    public class BaseContextRepository<TEntidade> : IDisposable
        where TEntidade : class, new()
    {

        internal GameBookContext _context;

        internal BaseContextRepository(GameBookContext context)
        {
            _context = context;
        }

        internal BaseContextRepository()
        {
            _context = new GameBookContext();
        }


        public virtual IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
            => Listar(includeProperties).Where(where);

        public virtual IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (includeProperties.Any())
                return Include(_context.Set<TEntidade>(), includeProperties);

            return query;
        }

        public virtual IQueryable<TEntidade> ListarAtivos(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (PropriedadeExiste(query, "Fl_Ativo"))
            {
                query = query.Where("Fl_Ativo != false").AsQueryable();
            }

            if (includeProperties.Any())
                return Include(_context.Set<TEntidade>(), includeProperties);

            return query;
        }

        public virtual TEntidade Adicionar(TEntidade entidade, string responsavel)
        {
            if (PropriedadeExiste(entidade, "Fl_Ativo") && PropriedadeExiste(entidade, "Dt_Criacao") && PropriedadeExiste(entidade, "Ds_Responsavel"))
            {
                ((dynamic)entidade).Fl_Ativo = true;
                ((dynamic)entidade).Dt_Criacao = DateTime.Now;
                ((dynamic)entidade).Ds_Responsavel = responsavel;

                _context.Set<TEntidade>().Attach(entidade);
                _context.Entry(entidade).State = EntityState.Added;

                return entidade;
            }

            return new();
        }

        public virtual TEntidade Editar(TEntidade entidade, string responsavel)
        {
            if (PropriedadeExiste(entidade, "Fl_Ativo") && PropriedadeExiste(entidade, "Dt_Criacao") && PropriedadeExiste(entidade, "Dt_UltimaAlteracao") && PropriedadeExiste(entidade, "Ds_Responsavel"))
            {
                _context.Entry(entidade).Property("Fl_Ativo").IsModified = false;
                _context.Entry(entidade).Property("Dt_Criacao").IsModified = false;

                ((dynamic)entidade).Dt_UltimaAlteracao = DateTime.Now;
                ((dynamic)entidade).Ds_Responsavel = responsavel;

                _context.Entry(entidade).State = EntityState.Modified;

                return entidade;
            }

            return new();
        }

        public virtual TEntidade Remover(int id, string responsavel)
        {
            TEntidade entidade = _context.Set<TEntidade>().Find(id);

            if (PropriedadeExiste(entidade, "Fl_Ativo") && PropriedadeExiste(entidade, "Dt_UltimaAlteracao") && PropriedadeExiste(entidade, "Ds_Responsavel"))
            {
                ((dynamic)entidade).Fl_Ativo = false;
                ((dynamic)entidade).Dt_UltimaAlteracao = DateTime.Now;
                ((dynamic)entidade).Ds_Responsavel = responsavel;

                _context.Entry(entidade).State = EntityState.Modified;
            }

            return entidade ?? new();
        }

        private static bool PropriedadeExiste(TEntidade entidade, string nomePropriedade)
            => entidade.GetType().GetProperty(nomePropriedade) != null;

        private static bool PropriedadeExiste(IQueryable<TEntidade> entidades, string nomePropriedade)
        {
            foreach (var entidade in entidades)
            {
                if (!PropriedadeExiste(entidade, nomePropriedade))
                    return false;
            }

            return true;
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
                query = query.Include(property);

            return query;
        }

        public virtual bool Commit() => _context.SaveChanges() > 0;
        public virtual void Dispose() => _context.Dispose();
    }
}
