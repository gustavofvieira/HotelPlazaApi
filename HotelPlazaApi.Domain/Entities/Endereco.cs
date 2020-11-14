
namespace HotelPlazaApi.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public int Cep { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }

    }
}
