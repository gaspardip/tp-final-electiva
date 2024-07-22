using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class VehiculosDAL : BaseDAL
    {
        public VehiculosDAL() : base("Vehiculos")
        {
        }

        public DataTable GetAllVehiculos()
        {
            return GetAll();
        }

        public DataTable GetVehiculo(string dominio)
        {
            return ExecuteQuery("SELECT * FROM Vehiculos WHERE Dominio = ?", new OleDbParameter("Dominio", dominio));
        }

        public void Insert(string dominio)
        {
            if (Exists(new OleDbParameter("Dominio", dominio)))
            {
                throw new DuplicateNameException("Ya existe un vehículo con ese dominio");
            }

            Insert(new OleDbParameter("Dominio", dominio));
        }

        public void Delete(int id)
        {
            OleDbParameter[] parameters =
            {
                new OleDbParameter("ID", id)
            };

            Delete("ID = ?", parameters);
        }
    }
}