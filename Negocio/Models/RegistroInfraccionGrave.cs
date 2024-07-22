using System;

namespace Business.Models
{
    public class RegistroInfraccionGrave : RegistroInfraccion
    {
        public RegistroInfraccionGrave(int id, Infraccion infraccion, string vehiculo, DateTime fs, DateTime fv) : base(
            id,
            infraccion, vehiculo, fs, fv)
        {
        }

        public override decimal CalcularDescuento(DateTime fechaPago, decimal i)
        {
            var fechaVencimiento = FechaVencimiento;
            var diasRestantes = fechaVencimiento - fechaPago;

            if (diasRestantes.TotalDays >= 25)
            {
                var descuento = i * 0.2m;
                return i - descuento;
            }

            return 0;
        }
    }
}