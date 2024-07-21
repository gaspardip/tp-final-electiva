using System;

namespace Business.Models
{
    public class RegistroInfraccionGrave : RegistroInfraccion
    {
        public RegistroInfraccionGrave(int id, int infraccion, string vehiculo, DateTime fs, DateTime fv, decimal resultado) : base(id, infraccion, vehiculo, fs, fv)
        {
        }

        public override decimal CalcularDescuento(DateTime fechaPago, decimal i)
        {
            DateTime fechaVencimiento = this.FechaVencimiento;
            TimeSpan diasRestantes = fechaVencimiento - fechaPago;

            if (diasRestantes.TotalDays >= 25)
            {
                decimal descuento = i * 0.2m;
                return i - descuento;
            }
            else
            {
                return 0;
            }
        }
    }
}
