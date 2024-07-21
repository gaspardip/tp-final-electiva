using Business.Enums;
using System;

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

        public Infraccion(int id, int codigo, string descripcion, decimal importe, TipoInfraccion tipo) : this(codigo, descripcion, importe, tipo)
        {
            ID = id;
        }

        public int ID { get; set; }
        public int Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Importe { get; set; }
        public TipoInfraccion Tipo { get; set; }
    }
}