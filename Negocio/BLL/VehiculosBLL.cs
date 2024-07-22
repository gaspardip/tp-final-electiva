using System.Collections.Generic;
using System.Data;
using System.Linq;
using Business.Models;
using DAL;

namespace Business.BLL
{
    public class VehiculosBLL
    {
        private readonly VehiculosDAL _vehiculos = new VehiculosDAL();

        public void Agregar(Vehiculo vehiculo)
        {
            _vehiculos.Insert(vehiculo.Dominio);
        }

        public void Eliminar(int id)
        {
            _vehiculos.Delete(id);
        }

        public void Pagar(RegistroInfraccion registro)
        {
            _vehiculos.Pagar(registro.ID, registro.VehiculoDominio);
        }

        private static Vehiculo MapVehiculo(DataRow row)
        {
            return new Vehiculo(
                row.Field<int>("ID"),
                row.Field<string>("Dominio"),
                row.Field<string>("Propietario")
            );
        }

        public List<Vehiculo> GetVehiculosSinPagar()
        {
            var dataTable = _vehiculos.GetVehiculosSinPagar();

            return (from DataRow row in dataTable.Rows
                    select MapVehiculo(row)).ToList();
        }

        public List<Vehiculo> GetAllVehiculos()
        {
            var dataTable = _vehiculos.GetAllVehiculos();

            return (from DataRow row in dataTable.Rows
                    select MapVehiculo(row)).ToList();
        }
    }
}