using System.Data;
using System.Data.OleDb;

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

        public void Insert(string descripcion, decimal importe, int tipo)
        {
            Insert(new OleDbParameter("Descripcion", descripcion),
                new OleDbParameter("Importe", importe),
                new OleDbParameter("Tipo", tipo));
        }

        public void Delete(int id)
        {
            Delete("ID = ?", new OleDbParameter("ID", id));
        }

        public void Update(int id, string descripcion, decimal importe, int tipo)
        {
            var setParameters = new[]
            {
                new OleDbParameter("Descripcion", descripcion),
                new OleDbParameter("Importe", importe),
                new OleDbParameter("Tipo", tipo)
            };

            Update(setParameters, "ID = ?", new OleDbParameter("ID", id));
        }
    }
}