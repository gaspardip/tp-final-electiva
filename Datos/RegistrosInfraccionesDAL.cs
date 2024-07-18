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

        public void Insert(int infCod, string vehDom, DateTime fs, DateTime fv)
        {
            if (Exists(new OleDbParameter("Infraccion", infCod)) && Exists(new OleDbParameter("Dominio", vehDom)))
            {
                throw new DuplicateNameException("Ya existe una infracción para ese vehículo");
            }

            Insert(new OleDbParameter("Infraccion", infCod),
                   new OleDbParameter("Dominio", vehDom),
                   new OleDbParameter("FechaSuceso", fs),
                   new OleDbParameter("FechaVencimiento", fv));
        }
    }
}