using System;

namespace Business.Models
{
    public class RegistroInfraccion
    {
        public RegistroInfraccion(Infraccion infraccion, string dominio, DateTime fs)
        {
            Infraccion = infraccion;
            VehiculoDominio = dominio;
            FechaSuceso = fs;
        }

        public RegistroInfraccion(Infraccion infraccion, string dominio, DateTime fs, DateTime fv) : this(infraccion,
            dominio, fs)
        {
            FechaVencimiento = fv;
        }

        public RegistroInfraccion(int id, Infraccion infraccion, string dominio, DateTime fs) : this(
            infraccion,
            dominio,
            fs)
        {
            ID = id;
        }

        public RegistroInfraccion(int id, Infraccion infraccion, string dominio, DateTime fs, DateTime fv) : this(
            infraccion,
            dominio,
            fs, fv)
        {
            ID = id;
        }

        public RegistroInfraccion()
        {
        }

        public int ID { get; set; }
        public Infraccion Infraccion { get; set; }
        public string VehiculoDominio { get; set; }
        public DateTime FechaSuceso { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Pagada { get; set; }

        public virtual decimal CalcularDescuento(DateTime fechaPago, decimal importe)
        {
            return 0;
        }
    }
}