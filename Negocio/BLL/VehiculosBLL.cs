using System.Collections.Generic;
using System.Data;
using System.Linq;
using Business.Enums;
using Business.Models;
using DAL;

namespace Business.BLL
{
    public class VehiculosBLL
    {
        private readonly VehiculosDAL _vehiculos = new VehiculosDAL();

        public void Agregar(Vehiculo vehiculo)
        {
            _vehiculos.Insert(vehiculo.Dominio, vehiculo.Propietario);
        }

        public void Editar(Vehiculo vehiculo)
        {
            _vehiculos.Update(vehiculo.ID, vehiculo.Dominio, vehiculo.Propietario);
        }

        public void Eliminar(string dominio)
        {
            _vehiculos.Delete(dominio);
        }

        //public List<Vehiculo> GetVehiculosConInfracciones()
        //{
        //    var dataTable = _vehiculos.GetVehiculosConInfracciones();

        //    return (from DataRow row in dataTable.Rows
        //                               select new Vehiculo(
        //                                                          row.Field<int>("ID"),
        //                                                                                 row.Field<string>("Dominio"),
        //                                                                                                        row.Field<string>("Propietario")
        //                                                                                                                           ))
        //        .ToList();
        //}

        public List<Vehiculo> GetAllVehiculos()
        {
            var dataTable = _vehiculos.GetAllVehiculos();

            return (from DataRow row in dataTable.Rows
                    select new Vehiculo(
                        row.Field<int>("ID"),
                        row.Field<string>("Dominio"),
                        row.Field<string>("Propietario")
                    ))
                .ToList();
        }


    }
}