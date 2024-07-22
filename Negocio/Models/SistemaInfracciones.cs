using System;
using System.Collections.Generic;
using Business.BLL;
using Business.Enums;

namespace Business.Models
{
    public class SistemaInfracciones
    {
        private readonly InfraccionesBLL _infracciones = new InfraccionesBLL();
        private readonly RegistrosInfraccionesBLL _registros = new RegistrosInfraccionesBLL();
        private readonly VehiculosBLL _vehiculos = new VehiculosBLL();

        public List<Infraccion> Infracciones => _infracciones.GetAllInfracciones();
        public List<Vehiculo> Vehiculos => _vehiculos.GetAllVehiculos();
        public List<Vehiculo> VehiculosSinPagar => _vehiculos.GetVehiculosSinPagar();
        public List<RegistroInfraccion> Registros => _registros.GetAllRegistros();

        public List<RegistroInfraccion> GetRegistrosPendientes(string vehiculoDom)
        {
            return _registros.GetRegistrosPendientes(vehiculoDom);
        }

        public void CrearInfraccion(string descripcion, decimal importe, TipoInfraccion tipo)
        {
            _infracciones.Agregar(new Infraccion(descripcion, importe, tipo));
        }

        public void EditarInfraccion(int id, string descripcion, decimal importe, TipoInfraccion tipo)
        {
            _infracciones.Editar(new Infraccion(id, descripcion, importe, tipo));
        }

        public void DarBajaInfraccion(int id)
        {
            _infracciones.Eliminar(id);
        }

        public void CrearVehiculo(string dominio)
        {
            _vehiculos.Agregar(new Vehiculo(dominio));
        }

        public void DarBajaVehiculo(int id)
        {
            _vehiculos.Eliminar(id);
        }

        public void RegistrarPagoVehiculo(RegistroInfraccion registro)
        {
            _vehiculos.Pagar(registro);
        }

        public void CrearRegistro(Infraccion infraccion, string dominio, DateTime fs)
        {
            _registros.Agregar(new RegistroInfraccion(infraccion, dominio, fs));
        }

        public void EditarRegistro(int id, Infraccion infraccion, string dominio, DateTime fs)
        {
            _registros.Editar(new RegistroInfraccion(id, infraccion, dominio, fs));
        }

        public void EliminarRegistro(int id)
        {
            _registros.Eliminar(id);
        }
    }
}