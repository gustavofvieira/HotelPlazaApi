
using System;

namespace HotelPlazaApi.Domain.Models
{
   public class Hospedagem
    {
        public int HospedagemId { get; set; }
        public int HospedeId { get; set; }
        public Hospede Hospede { get; set; }
        public int QuartoId { get; set; }
        public Quarto Quarto { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public bool Garagem { get; set; }

        public decimal Valor { get; set; }
        public bool Finalizado { get; set; }

        public decimal TotalEstadia { get; set; }

        public int QtDiasUteis { get; set; }
        public int QtDiasNaoUteis { get; set; }
        public decimal CalculaEstadia()
        {

            return TotalEstadia;
        }
    }
}
