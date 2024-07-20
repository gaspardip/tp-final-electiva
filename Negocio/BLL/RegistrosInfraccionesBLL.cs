using System;
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

        public List<RegistroInfraccion> GetAllRegistros()
        {
            var dataTable = _registros.GetAllRegistros();

            return (from DataRow row in dataTable.Rows
                    select new RegistroInfraccion(
                        row.Field<int>("ID"),
                        row.Field<int>("InfraccionCod"),
                        row.Field<string>("VehiculoDom"),
                        row.Field<DateTime>("FechaSuceso"),
                        row.Field<DateTime>("FechaVencimiento")
                    ))
                .ToList();
        }

        public void Agregar(RegistroInfraccion ri)
        {
            _registros.Insert(ri.InfraccionCod, ri.VehiculoDom, ri.FechaSuceso, ri.FechaVencimiento);
        }

        public List<RegistroInfraccion> GetRegistrosPendientes(string vehiculoDom)
        {
            var dataTable = _registros.GetRegistrosPendientes(vehiculoDom);

            return (from DataRow row in dataTable.Rows
                    select new RegistroInfraccion(
                    row.Field<int>("ID"),
                    row.Field<int>("InfraccionCod"),
                    row.Field<string>("VehiculoDom"),
                    row.Field<DateTime>("FechaSuceso"),
                    row.Field<DateTime>("FechaVencimiento")))
                .ToList();
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

