using System;

namespace Business.Models
{
    public class RegistroInfraccionLeve : RegistroInfraccion
    {
        public RegistroInfraccionLeve(int infraccion, string vehiculo, DateTime fs, DateTime fv) : base(infraccion, vehiculo, fs, fv)
        {
        }

        public override decimal CalcularDescuento(DateTime fechaPago)
        {
            return 0;
        }
    }
}
