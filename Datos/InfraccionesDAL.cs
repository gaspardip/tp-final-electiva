using System.Data;

namespace DAL
{
    public class InfraccionesDAL : BaseDAL
    {
        public InfraccionesDAL() : base("Infracciones")
        {
        }

        public DataTable GetAllInfracciones()
        {
            return GetAll();
        }
    }
}