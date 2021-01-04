using HotelPlazaApi.Domain.Interfaces.Repository;
using HotelPlazaApi.Domain.Interfaces.Service;
using HotelPlazaApi.Domain.Models;

namespace HotelPlazaApi.Services.Services
{
    public class QuartoService : BaseService<Quarto>, IQuartoService
    {
        public QuartoService(IQuartoRepository quartoRepositorio)
         : base(quartoRepositorio)
        {

        }
    }
}
