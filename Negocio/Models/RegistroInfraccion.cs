using System;

namespace Business.Models
{
    public abstract class RegistroInfraccion
    {
        private Infraccion infraccion;
        private Vehiculo vehiculo;

        protected RegistroInfraccion(int infraccion, int vehiculo, DateTime fs, DateTime fv)
        {
            InfraccionID = infraccion;
            VehiculoDominio = vehiculo;
            Fecha = fs;
            FechaVencimiento = fv;
        }

        public int ID { get; set; }
        public int VehiculoDominio { get; set; }
        public int InfraccionID { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Pagada { get; set; }

        public void Pagar(DateTime fechaPago)
        {
            if (Pagada) return;

            Pagada = true;
        }

        public abstract decimal CalcularDescuento(DateTime fechaPago);
    }
}