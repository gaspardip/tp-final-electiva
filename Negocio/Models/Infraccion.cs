using Business.Enums;

namespace Business.Models
{
    public class Infraccion
    {
        public Infraccion(string descripcion, decimal importe, TipoInfraccion tipo)
        {
            Descripcion = descripcion;
            Importe = importe;
            Tipo = tipo;
        }

        public Infraccion(int id)
        {
            ID = id;
        }

        public Infraccion(int id, string descripcion, decimal importe, TipoInfraccion tipo) : this(descripcion, importe,
            tipo)
        {
            ID = id;
        }

        public int ID { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public TipoInfraccion Tipo { get; set; }
    }
}