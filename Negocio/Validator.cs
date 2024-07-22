using System;

namespace Business
{
    public static class Validator
    {
        public static decimal ValidateImporte(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El importe no puede estar vacío");
            }

            if (!decimal.TryParse(value, out var importe))
            {
                throw new ArgumentException("El importe debe ser un número");
            }

            if (importe <= 0)
            {
                throw new ArgumentException("El importe debe ser mayor a 0");
            }

            return importe;
        }
    }
}