using Business.Enums;

namespace Business.Models
{
    public class Infraccion
    {
        public Infraccion(int id, string descripcion, decimal importe, TipoInfraccion tipo)
        {
            ID = id;
            Descripcion = descripcion;
            Importe = importe;
            Tipo = tipo;
        }

        public int ID { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public TipoInfraccion Tipo { get; set; }
    }
}