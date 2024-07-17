using Business.Enums;

namespace Business.Models
{
    public class Infraccion
    {
        public Infraccion(int codigo, string descripcion, decimal importe, TipoInfraccion tipo)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Importe = importe;
            Tipo = tipo;
        }

        // Constructor que utilizo para editar una infracción, ya que necesito saber si el codigo fue editado o no para hacer la validación correspondiente en la base de datos.
        public Infraccion(int codigo, int codViejo, bool codEditado, string descripcion, decimal importe, TipoInfraccion tipo) : this(codigo, descripcion, importe, tipo)
        {
            CodEditado = codEditado;
            CodViejo = codViejo;
        }

        public int CodViejo { get; set; }
        public bool CodEditado { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public TipoInfraccion Tipo { get; set; }
    }
}