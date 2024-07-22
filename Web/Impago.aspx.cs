using Business.Models;
using System;
using System.Web.UI;
using System.IO;

namespace Web
{
    public partial class Impago : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var vehiculo = (Vehiculo)Session["Vehiculo"];

                cargarInfraccionesImpagas(vehiculo);
            }
        }

        protected void cargarInfraccionesImpagas(Vehiculo vehiculo)
        {
            var sistema = (SistemaInfracciones)Session["Sistema"];

            ListBoxInfraccionesImpagas.DataSource = sistema.GetRegistrosPendientes(vehiculo.Dominio);
            ListBoxInfraccionesImpagas.DataTextField = "InfraccionID";
            ListBoxInfraccionesImpagas.DataValueField = "ID";

            ListBoxInfraccionesImpagas.DataBind();
        }

        protected void ButtonGenerarPDF_Click(object sender, EventArgs e)
        {

            if (ListBoxInfraccionesImpagas.SelectedItem != null)
            {
                var sistema = (SistemaInfracciones)Session["Sistema"];

                int id = int.Parse(ListBoxInfraccionesImpagas.SelectedItem.Value);

                using (var memoryStream = new MemoryStream())
                {
                    // Generar el PDF en el MemoryStream
                    sistema.DescargarPDF(id, memoryStream);

                    // Configurar la respuesta para descargar el PDF
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment; filename=OrdenPago-" + id + ".pdf");
                    Response.Buffer = true;
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    memoryStream.WriteTo(Response.OutputStream);
                    Response.End();
                }

            }
            else
            {
                LabelMensaje.ForeColor = System.Drawing.Color.Red;
                LabelMensaje.Text = "Debe seleccionar una infracción impaga.";
            }
        }
    }
}
