using System.Data;
using System.Data.OleDb;
using System;

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

        public DataTable GetVehiculosSinPagar()
        {
            return ExecuteQuery("SELECT * FROM Vehiculos WHERE Dominio IN (SELECT VehiculoDom FROM RegistrosInfracciones WHERE Pagada = FALSE AND FechaVencimiento >= Date())");
        }

        public void Pagar (int id, string vehDom)
        {
            var parameters = new OleDbParameter[]
            {
                new OleDbParameter("ID", id),
                new OleDbParameter("VehiculoDom", vehDom)
            };

            ExecuteNonQuery("UPDATE RegistroInfracciones SET Pagada = TRUE WHERE ID = ? AND VehiculoDom = ?", parameters);
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
            OleDbParameter[] parameters = new OleDbParameter[]
            {
                new OleDbParameter("ID", id)
            };

            Delete("ID = ?", parameters);
        }
    }
}