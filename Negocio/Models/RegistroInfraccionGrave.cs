using System;

namespace Business.Models
{
    public class RegistroInfraccionGrave : RegistroInfraccion
    {
        public RegistroInfraccionGrave(int id, Infraccion infraccion, string vehiculo, DateTime fs, DateTime fv,
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

                return diasRestantes >= 25 ? 0.2m : 0;
            }
        }
    }
}