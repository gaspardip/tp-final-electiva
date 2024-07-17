using System.Collections.Generic;
using Business.BLL;
using Business.Enums;

namespace Business.Models
{
    public class SistemaInfracciones
    {
        private readonly InfraccionesBLL _infracciones = new InfraccionesBLL();
        //private readonly VehiculosBLL _vehiculos = new VehiculosBLL();
        //private readonly RegistrosBLL _registros = new RegistrosBLL();


        public List<Infraccion> Infracciones => _infracciones.GetAllInfracciones();
        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
        public List<RegistroInfraccion> Registros { get; set; } = new List<RegistroInfraccion>();

        public void CrearInfraccion(int codigo, string descripcion, decimal importe, TipoInfraccion tipo)
        {
            _infracciones.Agregar(new Infraccion(codigo, descripcion, importe, tipo));
        }

        public void EditarInfraccion(int codigo, bool codEditado, string descripcion, decimal importe, TipoInfraccion tipo)
        {
            _infracciones.Editar(new Infraccion(codigo, codEditado, descripcion, importe, tipo));
        }

        public void DarBajaInfraccion(int codigo)
        {
            _infracciones.Eliminar(codigo);
        }

        public void CrearVehiculo(string patente, string marca, string modelo, string anio)
        {
            //_vehiculos.CreateVehiculo(patente, marca, modelo, anio);
        }
    }
}