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

        public void Agregar(RegistroInfraccion ri)
        {
            _registros.Insert(ri.InfraccionCod, ri.VehiculoDom, ri.FechaSuceso, ri.FechaVencimiento);
        }

        public static RegistroInfraccion MapRegistroInfraccion(DataRow row)
        {
            var infraccionCod = row.Field<int>("InfraccionCod");

            var infraccionTipo = ObtenerTipoInfraccion(infraccionCod);

            return infraccionTipo == 1
                ? new RegistroInfraccionLeve(
                    row.Field<int>("ID"),
                    row.Field<int>("InfraccionCod"),
                    row.Field<string>("VehiculoDom"),
                    row.Field<DateTime>("FechaSuceso"),
                    row.Field<DateTime>("FechaVencimiento"))
                : (RegistroInfraccion)new RegistroInfraccionGrave(
                    row.Field<int>("ID"),
                    row.Field<int>("InfraccionCod"),
                    row.Field<string>("VehiculoDom"),
                    row.Field<DateTime>("FechaSuceso"),
                    row.Field<DateTime>("FechaVencimiento"));
        }

        private static int ObtenerTipoInfraccion(int infraccionCod)
        {
             var registrosInfraccionesDAL = new RegistrosInfraccionesDAL();
             var infraccionTipo = registrosInfraccionesDAL.ObtenerTipoInfraccion(infraccionCod);

             return infraccionTipo;
        }


        public List<RegistroInfraccion> GetAllRegistros()
        {
            var dataTable = _registros.GetAllRegistros();

            return (from DataRow row in dataTable.Rows
                    select MapRegistroInfraccion(row)).ToList();
        }


        public List<RegistroInfraccion> GetRegistrosPendientes(string vehiculoDom)
        {
            var dataTable = _registros.GetRegistrosPendientes(vehiculoDom);

            return (from DataRow row in dataTable.Rows
                    select MapRegistroInfraccion(row)).ToList();
        }
    }
}

