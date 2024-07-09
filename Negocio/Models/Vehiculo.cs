namespace Business.Models
{
    public class Vehiculo
    {
        public Vehiculo(string domino)
        {
            Dominio = domino;
        }

        public string Dominio { get; set; }
    }
}