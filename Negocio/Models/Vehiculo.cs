using System.Collections.Generic;

namespace Business.Models
{
    public class Vehiculo
    {
        public Vehiculo(string dominio)
        {
            Dominio = dominio;
            Registros = new List<RegistroInfraccion>();
        }

        public Vehiculo(int id, string dominio) : this(dominio)
        {
            ID = id;
        }

        public List<RegistroInfraccion> Registros { get; set; }
        public int ID { get; set; }
        public string Dominio { get; set; }
    }
}