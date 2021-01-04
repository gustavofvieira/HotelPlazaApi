

using HotelPlazaApi.Domain.Interfaces.Services;

namespace HotelPlazaApi.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> : IBaseService<TEntity> where TEntity : class
    {
    }
}
