using System;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class RegistrosInfraccionesDAL : BaseDAL
    {
        public RegistrosInfraccionesDAL() : base("RegistrosInfracciones")
        {
        }

        public DataTable GetAllRegistros()
        {
            const string query =
                "SELECT RI.*, I.Descripcion, I.Importe, I.Tipo FROM RegistrosInfracciones RI " +
                "INNER JOIN Infracciones I ON RI.InfraccionID = I.ID";

            return ExecuteQuery(query);
        }

        public DataTable GetRegistrosPendientes(string dominio)
        {
            const string query =
                "SELECT RI.*, I.Descripcion, I.Importe, I.Tipo FROM RegistrosInfracciones RI " +
                "INNER JOIN Infracciones I ON RI.InfraccionID = I.ID " +
                "WHERE RI.VehiculoDominio = ? AND RI.FechaVencimiento >= Date() AND RI.Pagada = FALSE";

            return ExecuteQuery(
                query,
                new OleDbParameter("VehiculoDominio", dominio));
        }

        public DataTable GetRegistrosPagos(string dominio)
        {
            const string query =
                "SELECT RI.*, I.Descripcion, I.Importe, I.Tipo FROM RegistrosInfracciones RI " +
                "INNER JOIN Infracciones I ON RI.InfraccionID = I.ID " +
                "WHERE VehiculoDominio = ? AND Pagada = TRUE";

            return ExecuteQuery(
                query,
                new OleDbParameter("VehiculoDominio", dominio));
        }

        public void Insert(int idInfraccion, string dominio, DateTime fs)
        {
            Insert(new OleDbParameter("InfraccionID", idInfraccion),
                new OleDbParameter("VehiculoDominio", dominio),
                new OleDbParameter("FechaSuceso", OleDbType.Date) { Value = fs },
                new OleDbParameter("FechaVencimiento", OleDbType.Date) { Value = fs.AddDays(30) });
        }

        public void Update(int idRegistro, int idInfraccion, string dominio, DateTime fs, DateTime fv)
        {
            Update(new[]
                {
                    new OleDbParameter("InfraccionID", idInfraccion),
                    new OleDbParameter("VehiculoDominio", dominio),
                    new OleDbParameter("FechaSuceso", OleDbType.Date) { Value = fs },
                    new OleDbParameter("FechaVencimiento", OleDbType.Date) { Value = fs.AddDays(30) }
                },
                "ID = ?", new OleDbParameter("ID", idRegistro));
        }

        public void Pay(int id)
        {
            Update(new[]
                {
                    new OleDbParameter("Pagada", true)
                },
                "ID = ?", new OleDbParameter("ID", id));
        }

        public void Delete(int id)
        {
            Delete("ID = ?", new OleDbParameter("ID", id));
        }
    }
}