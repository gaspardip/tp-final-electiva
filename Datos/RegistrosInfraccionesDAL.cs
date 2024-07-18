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
            if(!Exists(new OleDbParameter("InfraccionCod", infCod)))
            {
                throw new DuplicateNameException("No existe el código de infracción ingresado");
            }
            if(!Exists(new OleDbParameter("VehiculoDom", vehDom)))
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