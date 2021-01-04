using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HotelPlazaApi.Domain.Interfaces.Services
{
    public interface IBaseService <TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Salva o registro no banco e retorna o Id do registro gravado.
        /// </summary>
        /// <param name="obj">Objeto a ser Salvo.</param>
        /// <returns></returns>
        TEntity Add(TEntity obj);


        /// <summary>
        /// Obtem O registro de uma determinada entidade a partir do seu Id.
        /// </summary>
        /// <param name="predicate">Expression<Func<TEntity, bool>></param>
        /// <returns>IEnumerable<TEntity></returns>
        IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Obtem O registro de uma determinada entidade a partir do seu Id.
        /// </summary>
        /// <param name="id">Id da Entidade.</param>
        /// <returns></returns>
        TEntity ObtemPorId(params object[] id);

        /// <summary>
        /// Obtem uma lista de todos os registros de uma determinada entidade.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> ObtemTodos();

        /// <summary>
        /// Obtém a Entidade do Repositório Atual.
        /// </summary>
        /// <returns></returns>
        DbSet<TEntity> Entity();

        /// <summary>
        /// Atualiza o registro no banco de dados.
        /// </summary>
        /// <param name="obj">Objeto a ser atualizado.</param>
        void Update(TEntity obj);

        /// <summary>
        /// Atualiza o registro no banco de dados.
        /// </summary>
        /// <param name="obj">Objeto a ser atualizado.</param>
        /// <param name="properties">Expression<Func<TEntity, object>>[] properties Propriedades a ser atualizadas</param>
        void Update(TEntity obj, params Expression<Func<TEntity, object>>[] properties);

        /// <summary>
        /// Deleta o registro fisicamente no banco de dados.
        /// </summary>
        /// <param name="obj">Objeto a ser excluído.</param>
        void Remove(TEntity obj);


    }
}
