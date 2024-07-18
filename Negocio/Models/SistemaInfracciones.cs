using System;
using System.Collections.Generic;
using Business.BLL;
using Business.Enums;

namespace Business.Models
{
    public class SistemaInfracciones
    {
        private readonly InfraccionesBLL _infracciones = new InfraccionesBLL();
        private readonly VehiculosBLL _vehiculos = new VehiculosBLL();
        private readonly RegistrosInfraccionesBLL _registros = new RegistrosInfraccionesBLL();


        public List<Infraccion> Infracciones => _infracciones.GetAllInfracciones();
        public List<Vehiculo> Vehiculos => _vehiculos.GetAllVehiculos();
        //public List<Vehiculo> Vehiculos => _vehiculos.GetVehiculosConInfracciones();
        //public List<RegistroInfraccion> Registros => _registros.GetRegistrosConImporte();

        public void CrearInfraccion(int codigo, string descripcion, decimal importe, TipoInfraccion tipo)
        {
            _infracciones.Agregar(new Infraccion(codigo, descripcion, importe, tipo));
        }

        public void EditarInfraccion(int id, int codigo, string descripcion, decimal importe, TipoInfraccion tipo)
        {
            _infracciones.Editar(new Infraccion(id, codigo, descripcion, importe, tipo));
        }

        public void DarBajaInfraccion(int codigo)
        {
            _infracciones.Eliminar(codigo);
        }

        public void CrearVehiculo(string dominio, string propietario)
        {
            _vehiculos.Agregar(new Vehiculo(dominio, propietario));
        }

        public void EditarVehiculo(int id, string dominio, string propietario)
        {
            _vehiculos.Editar(new Vehiculo(id, dominio, propietario));
        }

        public void DarBajaVehiculo(string dominio)
        {
            _vehiculos.Eliminar(dominio);
        }

        public void CrearRegistro(int infCod, string vehDom, DateTime fs, DateTime fv)
        {
            _registros.Agregar(new RegistroInfraccion(infCod, vehDom, fs, fv));
        }
    }
}