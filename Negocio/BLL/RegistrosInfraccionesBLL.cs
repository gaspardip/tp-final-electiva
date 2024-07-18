using System.Collections.Generic;
using System.Data;
using System.Linq;
using Business.Enums;
using Business.Models;
using DAL;

namespace Business.BLL
{
    public class RegistrosInfraccionesBLL
    {
        private readonly RegistrosInfraccionesDAL _registros = new RegistrosInfraccionesDAL();

        //public void Agregar(RegistroInfraccion ri)
        //{
        //    _registros.Insert(ri.InfraccionCodigo, ri.VehiculoDominio, ri.Fecha, ri.FechaVencimiento);
        //}

    }
}

