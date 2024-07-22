using Business.Models;
using System;
using System.Web;
using System.Web.UI;

namespace Web
{
    public partial class Pago : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var vehiculo = (Vehiculo)Session["Vehiculo"];

                cargarInfraccionesPagas(vehiculo);
            }
        }

        protected void cargarInfraccionesPagas(Vehiculo vehiculo)
        {
            var sistema = (SistemaInfracciones)Session["Sistema"];

            ListBoxInfraccionesPagas.DataSource = sistema.GetRegistrosPagos(vehiculo.Dominio);
            ListBoxInfraccionesPagas.DataTextField = "Dominio";
            ListBoxInfraccionesPagas.DataValueField = "ID";

            ListBoxInfraccionesPagas.DataBind();
        }

    }
}
