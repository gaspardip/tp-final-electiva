using System.Collections.Generic;
using Business.BLL;

namespace Business.Models
{
    public class SistemaInfracciones
    {
        private readonly InfraccionesBLL _infracciones = new InfraccionesBLL();
        public List<Infraccion> Infracciones => _infracciones.GetAllInfracciones();
        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
        public List<RegistroInfraccion> Registros { get; set; } = new List<RegistroInfraccion>();
    }
}