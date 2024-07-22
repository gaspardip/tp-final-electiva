using System;
using System.Web.UI;
using Business.Models;

namespace Web
{
    public partial class Pago : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            var sistema = (SistemaInfracciones)Session["Sistema"];
            var vehiculo = (Vehiculo)Session["Vehiculo"];

            if (sistema == null || vehiculo == null)
            {
                Response.Redirect("Login.aspx");
            }

            CargarInfraccionesPagas(vehiculo);
        }

        protected void CargarInfraccionesPagas(Vehiculo vehiculo)
        {
            var sistema = (SistemaInfracciones)Session["Sistema"];

            ListBoxInfraccionesPagas.DataSource = sistema.GetRegistrosPagos(vehiculo.Dominio);
            ListBoxInfraccionesPagas.DataTextField = "Descripcion";
            ListBoxInfraccionesPagas.DataValueField = "ID";

            ListBoxInfraccionesPagas.DataBind();
        }
    }
}