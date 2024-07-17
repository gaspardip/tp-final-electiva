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

        public void Update(string dominio, bool domEditado, string propietario)
        {
            if (domEditado == true)
            {
                if (Exists(new OleDbParameter("Dominio", dominio)))
                {
                    throw new DuplicateNameException("Ya existe un vehículo con ese dominio");
                }
            }

            var setParameters = new OleDbParameter[]
            {
                new OleDbParameter("Propietario", propietario)
            };

            var whereClause = "Dominio = ?";

            var whereParameters = new OleDbParameter[]
            {
                new OleDbParameter("Dominio", dominio)
            };

            Update(setParameters, whereClause, whereParameters);
        }
    }
}