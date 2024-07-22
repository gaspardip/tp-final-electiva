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
            _registros.Insert(ri.Infraccion.ID, ri.VehiculoDominio, ri.FechaSuceso);
        }

        public void Editar(RegistroInfraccion ri)
        {
            _registros.Update(ri.ID, ri.Infraccion.ID, ri.VehiculoDominio, ri.FechaSuceso, ri.FechaVencimiento);
        }

        public void Eliminar(int id)
        {
            _registros.Delete(id);
        }

        public void Pagar(int id)
        {
            _registros.Pay(id);
        }

        public static RegistroInfraccion MapRegistroInfraccion(DataRow row)
        {
            var tipo = (TipoInfraccion)row.Field<int>("Tipo");

            var infraccion = new Infraccion(
                row.Field<int>("InfraccionID"),
                row.Field<string>("Descripcion"),
                row.Field<decimal>("Importe"),
                tipo);

            return tipo == TipoInfraccion.Leve
                ? new RegistroInfraccionLeve(
                    row.Field<int>("ID"),
                    infraccion,
                    row.Field<string>("VehiculoDominio"),
                    row.Field<DateTime>("FechaSuceso"),
                    row.Field<DateTime>("FechaVencimiento"),
                    row.Field<bool>("Pagada"))
                : (RegistroInfraccion)new RegistroInfraccionGrave(
                    row.Field<int>("ID"),
                    infraccion,
                    row.Field<string>("VehiculoDominio"),
                    row.Field<DateTime>("FechaSuceso"),
                    row.Field<DateTime>("FechaVencimiento"),
                    row.Field<bool>("Pagada"));
        }

        public List<RegistroInfraccion> GetAllRegistros()
        {
            var dataTable = _registros.GetAllRegistros();

            return (from DataRow row in dataTable.Rows
                    select MapRegistroInfraccion(row)).ToList();
        }

        public List<RegistroInfraccion> GetRegistrosPendientes(string dominio)
        {
            var dataTable = _registros.GetRegistrosPendientes(dominio);

            return (from DataRow row in dataTable.Rows
                    select MapRegistroInfraccion(row)).ToList();
        }

        public List<RegistroInfraccion> GetRegistrosPagos(string dominio)
        {
            var dataTable = _registros.GetRegistrosPagos(dominio);

            return (from DataRow row in dataTable.Rows
                    select MapRegistroInfraccion(row)).ToList();
        }
    }
}