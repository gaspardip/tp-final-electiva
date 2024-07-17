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

        // Constructor que utilizo para editar un vehículo, ya que necesito saber si el dominio fue editado o no para hacer la validación correspondiente en la base de datos.
        public Vehiculo(string dominio, string domViejo, string propietario, bool domEditado) : this(dominio, propietario)
        {
            DomEditado = domEditado;
            DomViejo = domViejo;
        }

        public string DomViejo { get; set; }
        public bool DomEditado { get; set; }
        public string Dominio { get; set; }
        public string Propietario { get; set; }
    }
}