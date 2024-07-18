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
        //private readonly RegistrosBLL _registros = new RegistrosBLL();


        public List<Infraccion> Infracciones => _infracciones.GetAllInfracciones();
        public List<Vehiculo> Vehiculos => _vehiculos.GetAllVehiculos();
        public List<RegistroInfraccion> Registros { get; set; } = new List<RegistroInfraccion>();

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

        public void CrearRegistro(int infraccion, string vehiculo, DateTime fs, DateTime fv)
        {
            //_registros.Agregar(new RegistroInfraccion(infraccion, vehiculo, fs, fv));
        }
    }
}