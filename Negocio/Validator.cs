using Business.Enums;
using System;

namespace Business
{
    public static class Validator
    {
        public static int ValidateCodigo(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El código no puede estar vacío");
            }

            if (!int.TryParse(value, out var cod))
            {
                throw new ArgumentException("El código debe ser un número");
            }

            return cod;
        }

        public static bool CodigoEditado (int codigo, int codigoEditado)
        {
            return codigo != codigoEditado;
        }

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
