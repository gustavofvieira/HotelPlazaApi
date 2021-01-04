
using HotelPlazaApi.Domain.Models;
using HotelPlazaApi.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace HotelPlazaApi.Infra.Data.Context
{
    public class BDHotelPlazaContext : DbContext
    {
        public DbSet<Quarto> Quarto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new QuartoMap());
        }
    }
}
