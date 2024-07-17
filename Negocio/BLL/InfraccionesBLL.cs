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

        public void Agregar(Infraccion infraccion)
        {
            _infracciones.Insert(infraccion.Codigo, infraccion.Descripcion, infraccion.Importe, (int)infraccion.Tipo);
        }

        public void Editar(Infraccion infraccion)
        {
            _infracciones.Update(infraccion.Codigo, infraccion.CodViejo, infraccion.CodEditado, infraccion.Descripcion, infraccion.Importe, (int)infraccion.Tipo);
        }

        public void Eliminar(int codigo)
        {
            _infracciones.Delete(codigo);
        }

        public List<Infraccion> GetAllInfracciones()
        {
            var dataTable = _infracciones.GetAllInfracciones();

            return (from DataRow row in dataTable.Rows
                    select new Infraccion(row.Field<int>("Codigo"),
                        row.Field<string>("Descripcion"),
                        row.Field<decimal>("Importe"),
                        (TipoInfraccion)row.Field<int>("Tipo")
                    ))
                .ToList();
        }   


    }
}