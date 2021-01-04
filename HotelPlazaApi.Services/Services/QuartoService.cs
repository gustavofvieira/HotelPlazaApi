using HotelPlazaApi;

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
