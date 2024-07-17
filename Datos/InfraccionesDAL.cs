using System.Data;
using System.Data.OleDb;
using System.Net;

namespace DAL
{
    public class InfraccionesDAL : BaseDAL
    {
        public InfraccionesDAL() : base("Infracciones")
        {
        }

        public DataTable GetAllInfracciones()
        {
            return GetAll();
        }

        public void Insert(int codigo, string descripcion, decimal importe, int tipo)
        {
        

            if (Exists(new OleDbParameter("Codigo", codigo)))
            {
                throw new DuplicateNameException("Ya existe una infracción con ese código");
            }

            Insert(new OleDbParameter("Codigo", codigo),
                               new OleDbParameter("Descripcion", descripcion),
                                              new OleDbParameter("Importe", importe),
                                                             new OleDbParameter("Tipo", tipo));
        }

        public void Delete(int codigo)
        {
            OleDbParameter[] parameters = new OleDbParameter[]
            {
                new OleDbParameter("Codigo", codigo)
            };

            Delete("Codigo = ?", parameters);
        }

        public void Update(int codigo, bool codEditado, string descripcion, decimal importe, int tipo)
        {
            if(codEditado == true)
            {
                if (Exists(new OleDbParameter("Codigo", codigo)))
                {
                    throw new DuplicateNameException("Ya existe una infracción con ese código");
                }
            }

            var setParameters = new OleDbParameter[]
            {
                new OleDbParameter("Descripcion", descripcion),
                new OleDbParameter("Importe", importe),
                new OleDbParameter("Tipo", tipo)
            };

            var whereClause = "Codigo = ?";

            var whereParameters = new OleDbParameter[]
            {
                new OleDbParameter("Codigo", codigo)
            };

            Update(setParameters, whereClause, whereParameters);
        }
    }
}