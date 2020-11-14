
using System;

namespace HotelPlazaApi.Domain.Entities
{
    public class Hospede
    {
        public int HospedeId { get; set; }
        public string NomeCompleto { get; set; }
        public int Cpf { get; set; }
        public int Rg { get; set; }
        public int Telefone1 { get; set; }
        public int Telefone2 { get; set; }
        public string Email { get; set; }
        public bool Hospedado { get; set; }
        public DateTime DataCadastro { get; set; }

        public int EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }

        public decimal TotalValorHospedagens { get; set; }

        public DateTime UltimaEstadia { get; set; }
    }
}
