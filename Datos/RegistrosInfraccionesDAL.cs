using System.Data.OleDb;
using System.Data;
using System;

namespace DAL
{
    public class RegistrosInfraccionesDAL : BaseDAL
    {
        public RegistrosInfraccionesDAL() : base("RegistrosInfracciones")
        {

        }

        public int ObtenerTipoInfraccion(int infCod)
        {
            var tipoInf = ExecuteScalar("SELECT Tipo FROM Infracciones WHERE Codigo = ?", new OleDbParameter("Codigo", infCod));

            return Convert.ToInt32(tipoInf);
        }

        public DataTable GetAllRegistros()
        {
            return ExecuteQuery("SELECT * FROM RegistrosInfracciones");
        }

        public DataTable GetRegistrosPendientes(string vehiculoDom)
        {
            return ExecuteQuery("SELECT * FROM RegistrosInfracciones WHERE VehiculoDom = ? AND FechaVencimiento >= Date() AND Pagada = FALSE", new OleDbParameter("VehiculoDom", vehiculoDom));
        }

        public void Insert(int infCod, string vehDom, DateTime fs, DateTime fv)
        {
            if(!ExistsInTable("Infracciones", new OleDbParameter("Codigo", infCod)))
            {
                throw new DuplicateNameException("No existe el código de infracción ingresado");
            }
            if(!ExistsInTable("Vehiculos", new OleDbParameter("Dominio", vehDom)))
            {
                throw new DuplicateNameException("No existe el dominio ingresado");
            }

            Insert(new OleDbParameter("InfraccionCod", infCod),
                   new OleDbParameter("VehiculoDom", vehDom),
                   new OleDbParameter("FechaSuceso", fs),
                   new OleDbParameter("FechaVencimiento", fv));
        }

    }
}