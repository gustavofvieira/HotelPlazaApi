using HotelPlazaApi.Domain.Interfaces.Repository;
using HotelPlazaApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HotelPlazaApi.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected BDHotelPlazaContext _Db;
        // Flag: Has Dispose already been called?
        bool disposed = false;

        public IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            var tEntities = _Db.Set<TEntity>().Where(predicate);
            return tEntities;
        }


        /// <summary>
        /// Obtem O registro de uma determinada entidade a partir do seu Id.
        /// </summary>
        /// <param name="id">Id da Entidade.</param>
        /// <returns></returns>
        public virtual TEntity ObtemPorId(params object[] id)
        {
            return _Db.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// GetBy, Metodo de busca Dinamica da Entidade.
        /// </summary>
        /// <param name="predicate"> Expresão lambda para Consulta ex: x=>x.id == varId </param>
        /// <param name="includes"> Array de Includes Necessarios caso precisde de proxyLoad para o objeto retornado , ex: x=>x.Table1, x=>x.table2 </param>
        /// <returns>Retorna a Entidade.</returns>
        protected TEntity GetBy(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return GetByAsQueryable(predicate, includes).FirstOrDefault();
        }

        /// <summary>
        /// Metodo de busca Dinamica da Entidade como IQueryable.
        /// </summary>
        /// <param name="predicate"> Expresão lambda para para Consulta ex: x=>x.id == varId </param>
        /// <param name="includes"> Array de Includes Necessarios caso precisde de proxyLoad para o objeto retornado , ex: x=>x.Table1, x=>x.table2 </param>
        /// <returns>Retorna uma lista da entidade.</returns>
        public IEnumerable<TEntity> GetByToList(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return GetByAsQueryable(predicate, includes).ToList();
        }

        /// <summary>
        /// GetBy, Metodo de busca Dinamica da Entidade como IQueryable.
        /// </summary>
        /// <param name="predicate"> Expresão lambda para para Consulta ex: x=>x.id == varId </param>
        /// <param name="includes"> Array de Includes Necessarios caso precisde de proxyLoad para o objeto retornado , ex: x=>x.Table1, x=>x.table2 </param>
        /// <returns>Retorna como IQueryable.</returns>
        public IQueryable<TEntity> GetByAsQueryable(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> result = Entity();
            if (predicate != null)
            {
                result = result.Where(predicate);
            }
            if (includes.Any())
            {
                result = includes.Aggregate(result, (current, include) => current.Include(include));
            }
            return result;
        }

     

        /// <summary>
        /// Obtém a Entidade do Repositório Atual.
        /// </summary>
        /// <returns></returns>
        public DbSet<TEntity> Entity()
        {
            return _Db.Set<TEntity>();
        }

      
        public void Update(TEntity obj, params Expression<Func<TEntity, object>>[] properties)
        {
            _Db.Set<TEntity>().Attach(obj);
            var entityToUpdate = _Db.Entry(obj);

            foreach (var property in properties)
            {
                entityToUpdate.Property(property).IsModified = true;
            }
            _Db.SaveChanges();
        }

        /// <summary>
        /// Deleta o registro fisicamente no banco de dados.
        /// </summary>
        /// <param name="obj">Objeto a ser excluído.</param>
        public void Remove(TEntity obj)
        {
            _Db.Set<TEntity>().Remove(obj);
            _Db.SaveChanges();
        }

        /// <summary>
        /// Salva o registro no banco e retorna o Id do registro gravado.
        /// </summary>
        /// <param name="obj">Objeto a ser Salvo.</param>
        /// <returns></returns>
        public TEntity Add(TEntity obj)
        {
            _Db.Set<TEntity>().Add(obj);
            _Db.SaveChanges();

            return obj;
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ///// <summary>
        ///// Retorna o GETDATE() do banco de dados
        ///// </summary>
        ///// <returns></returns>
        public DateTime GetDbDate()
        {
            // está pegando temporariamento o horário do sistema,
            // mas futuramente precisa pegar a hora do Banco.
            return DateTime.Now;
        }

        public IQueryable<TEntity> ObtemTodos()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
