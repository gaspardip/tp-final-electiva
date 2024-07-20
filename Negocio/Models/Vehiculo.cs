using Business.Enums;
using System.Collections.Generic;

namespace Business.Models
{
    public class Vehiculo
    {
        public Vehiculo(string dominio)
        {
            Dominio = dominio;
            Infracciones = new List<Infraccion>();
        }

        public Vehiculo(int id, string dominio): this(dominio)
        {
            ID = id;
        }

        public List<Infraccion> Infracciones { get; set; }
        public int ID { get; set; }
        public string Dominio { get; set; }
    }
}