
namespace HotelPlazaApi.Domain.Models
{
    public class Quarto
    {
        public int QuartoId { get; set; }
        public int Numero { get; set; }
        public string Descricao { get; set; }

        public bool ArCondicionado { get; set; }
        public bool Ventilador { get; set; }
        public bool Tv { get; set; }

        public bool Ocupado { get; set; }
        public void ArOuVentilador()
        {
            if (ArCondicionado == true)
            {
                ArCondicionado = true;
                Ventilador = false;
            }
            else
            {
                Ventilador = true;
                ArCondicionado = false;
            }
        }
    }
}
