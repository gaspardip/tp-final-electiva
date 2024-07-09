using System.Collections.Generic;
using System.Data;
using System.Linq;
using Business.Enums;
using Business.Models;
using DAL;

namespace Business.BLL
{
    public class InfraccionesBLL
    {
        private readonly InfraccionesDAL _infracciones = new InfraccionesDAL();

        public List<Infraccion> GetAllInfracciones()
        {
            var dataTable = _infracciones.GetAllInfracciones();

            return (from DataRow row in dataTable.Rows
                    select new Infraccion(row.Field<int>("ID"),
                        row.Field<string>("Descripcion"),
                        row.Field<decimal>("Importe"),
                        (TipoInfraccion)row.Field<int>("Tipo")
                    ))
                .ToList();
        }
    }
}