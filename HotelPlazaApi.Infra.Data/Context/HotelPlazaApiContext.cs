
using HotelPlazaApi.Domain.Models;
using HotelPlazaApi.Infra.Data.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace HotelPlazaApi.Infra.Data.Context
{
    public class HotelPlazaApiContext :DbContext
    {
        private readonly IHttpContextAccessor _accessor;

        public HotelPlazaApiContext(DbContextOptions<HotelPlazaApiContext> options) : base(options)
        {

        }

        public HotelPlazaApiContext(DbContextOptions<HotelPlazaApiContext> options, IHttpContextAccessor accessor) : base(options)
        {
            _accessor = accessor;
        }

        // Relação de models-tabelas
        public DbSet<Quarto> Quarto { get; set; }

        // Relação de mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new QuartoMap());
        }

    }
}
