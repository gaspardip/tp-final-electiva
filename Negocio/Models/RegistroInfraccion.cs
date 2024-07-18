using System;

namespace Business.Models
{
    public class RegistroInfraccion
    {

        public RegistroInfraccion(int infCod, string vehDom, DateTime fs, DateTime fv)
        {
            InfraccionCod = infCod;
            VehiculoDom = vehDom;
            FechaSuceso = fs;
            FechaVencimiento = fv;
        }

        public int ID { get; set; }
        public int InfraccionCod { get; set; }
        public string VehiculoDom { get; set; }
        public DateTime FechaSuceso { get; set; }
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