using System;

namespace Business.Models
{
    public class RegistroInfraccionLeve : RegistroInfraccion
    {
        public RegistroInfraccionLeve(int id, Infraccion infraccion, string vehiculo, DateTime fs, DateTime fv,
            bool pagada) : base(
            id,
            infraccion, vehiculo, fs, fv, pagada)
        {
        }

        public override decimal Descuento
        {
            get
            {
                var diasRestantes = (FechaVencimiento - DateTime.Now).Days;

                decimal descuento = 0;

                if (diasRestantes >= 20)
                {
                    descuento = 0.25m;
                }
                else if (diasRestantes >= 10)
                {
                    descuento = 0.15m;
                }

                return descuento;
            }
        }
    }
}