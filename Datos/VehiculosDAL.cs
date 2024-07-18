using System.Data;
using System.Data.OleDb;
using System.Net;

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

        public void Insert(string dominio, string propietario)
        {


            if (Exists(new OleDbParameter("Dominio", dominio)))
            {
                throw new DuplicateNameException("Ya existe un vehículo con ese dominio");
            }

            Insert(new OleDbParameter("Dominio", dominio),
                               new OleDbParameter("Propietario", propietario));
        }

        public void Delete(string dominio)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
            {
                new OleDbParameter("Dominio", dominio)
            };

            Delete("Dominio = ?", parameters);
        }

        public void Update(int id, string dominio, string propietario)
        {
            if (Exists(new OleDbParameter("Dominio", dominio)))
            {
                throw new DuplicateNameException("Ya existe un vehículo con ese dominio");
            }

            var setParameters = new OleDbParameter[]
            {
                new OleDbParameter("Dominio", dominio),
                new OleDbParameter("Propietario", propietario)
            };

            var whereClause = "ID = ?";

            var whereParameters = new OleDbParameter[]
            {
                new OleDbParameter("ID", id)
            };

            Update(setParameters, whereClause, whereParameters);
        }
    }
}