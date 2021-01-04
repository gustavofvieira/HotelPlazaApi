

using HotelPlazaApi.Domain.Interfaces.Repository;
using HotelPlazaApi.Domain.Interfaces.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HotelPlazaApi.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public BaseService(IQuartoRepository quartoRepositorio)
        {
            this.quartoRepositorio = quartoRepositorio;
        }

        public TEntity Add(TEntity obj)
        {
            return _repository.Add(obj);
        }

        public IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Buscar(predicate);
        }

        public DbSet<TEntity> Entity()
        {
            return _repository.Entity();
        }

        public TEntity ObtemPorId(params object[] id)
        {
            return _repository.ObtemPorId(id);
        }

        public IQueryable<TEntity> ObtemTodos()
        {
            return _repository.ObtemTodos();
        }

        public void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Update(TEntity obj, params Expression<Func<TEntity, object>>[] properties)
        {
            _repository.Update(obj, properties);
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
    }
}
