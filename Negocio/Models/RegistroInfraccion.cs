using System;

namespace Business.Models
{
    public class RegistroInfraccion
    {
        public int ID { get; set; }
        public int VehiculoID { get; set; }
        public Infraccion Infraccion { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Pagada { get; set; }

        public void Pagar(DateTime fechaPago)
        {
            if (Pagada) return;

            Pagada = true;
        }

        public virtual decimal CalcularDescuento(DateTime fechaPago)
        {
            return 0;
        }
    }
}