using System;

namespace Business.Models
{
    public class RegistroInfraccionLeve : RegistroInfraccion
    {
        public RegistroInfraccionLeve(int id, int infraccion, string vehiculo, DateTime fs, DateTime fv, decimal resultado) : base(id, infraccion, vehiculo, fs, fv)
        {
        }

        public override decimal CalcularDescuento(DateTime fechaPago, decimal i)
        {
            DateTime fechaVencimiento = this.FechaVencimiento;
            TimeSpan diferenciaDias = fechaVencimiento - fechaPago;
            int diasRestantes = diferenciaDias.Days;

            decimal descuento = 0;

            if (diasRestantes >= 20)
            {
                descuento = i * 0.25m;
            }
            else if (diasRestantes >= 10)
            {
                descuento = i * 0.15m;
            }

            return i - descuento;
        }

    }
}
