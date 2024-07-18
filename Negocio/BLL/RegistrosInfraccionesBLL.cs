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

        public void Agregar(RegistroInfraccion ri)
        {
            _registros.Insert(ri.InfraccionCod, ri.VehiculoDom, ri.FechaSuceso, ri.FechaVencimiento);
        }

        //public List<RegistroInfraccion> GetRegistrosSinPagar()
        //{
        //    var registros = _registros.GetAll();
        //    return registros.Where(r => !r.Pagada).ToList();
        //}

        //public List<RegistroInfraccion> GetRegistrosConImporte()
        //{
        //    var registros = _registros.GetRegistrosConImporte();
        //    return registros.Select(r => new RegistroInfraccion(r.ID, r.InfraccionCod, r.VehiculoDom, r.FechaSuceso, r.FechaVencimiento)
        //    {
        //        Pagada = r.Pagada
        //    }).ToList();
        //}

    }
}

