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
        public List<Vehiculo> VehiculosSinPagar => _vehiculos.GetVehiculosSinPagar();
        public List<RegistroInfraccion> Registros => _registros.GetAllRegistros();

        public List<RegistroInfraccion> GetRegistrosPendientes(string vehiculoDom)
        {
            return _registros.GetRegistrosPendientes(vehiculoDom);
        }

        public void CrearInfraccion(int codigo, string descripcion, decimal importe, TipoInfraccion tipo)
        {
            _infracciones.Agregar(new Infraccion(codigo, descripcion, importe, tipo));
        }

        public void EditarInfraccion(int id, int codigo, string descripcion, decimal importe, TipoInfraccion tipo)
        {
            _infracciones.Editar(new Infraccion(id, codigo, descripcion, importe, tipo));
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

        public void CrearRegistro(int infCod, string vehDom, DateTime fs, DateTime fv)
        {
            _registros.Agregar(new RegistroInfraccion(infCod, vehDom, fs, fv));
        }

        public void RegistrarPagoVehiculo(RegistroInfraccion registro)
        {
            _vehiculos.Pagar(registro);
        }
    }
}