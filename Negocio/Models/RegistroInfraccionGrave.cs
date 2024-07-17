using System;

namespace Business.Models
{
    public class RegistroInfraccionGrave : RegistroInfraccion
    {
        public RegistroInfraccionGrave(int infraccion, int vehiculo, DateTime fs, DateTime fv) : base(infraccion, vehiculo, fs, fv)
        {
        }

        public override decimal CalcularDescuento(DateTime fechaPago)
        {
            return 0;
        }
    }
}
