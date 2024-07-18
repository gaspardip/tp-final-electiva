using Business.Enums;

namespace Business.Models
{
    public class Vehiculo
    {
        public Vehiculo(string domino, string propietario)
        {
            Dominio = domino;
            Propietario = propietario;
        }

        public Vehiculo(int id, string domino, string propietario): this(domino, propietario)
        {
            ID = id;
        }

        public int ID { get; set; }
        public string Dominio { get; set; }
        public string Propietario { get; set; }
    }
}