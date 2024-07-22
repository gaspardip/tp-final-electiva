using System;
using System.Drawing;
using System.Web.UI;
using Business.Models;

namespace Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) return;

            var sistema = (SistemaInfracciones)Session["Sistema"];
            var vehiculo = (Vehiculo)Session["Vehiculo"];

            if (sistema == null || vehiculo == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ButtonImpago_Click(object sender, EventArgs e)
        {
            var sistema = (SistemaInfracciones)Session["Sistema"];
            var vehiculo = (Vehiculo)Session["Vehiculo"];


            if (sistema.GetRegistrosPendientes(vehiculo.Dominio) != null)
            {
                Response.Redirect("Impago.aspx");
            }
            else
            {
                LabelMensaje.ForeColor = Color.Red;
                LabelMensaje.Text = "El vehículo no tiene infracciones sin pagar.";
            }
        }

        protected void ButtonPago_Click(object sender, EventArgs e)
        {
            var sistema = (SistemaInfracciones)Session["Sistema"];
            var vehiculo = (Vehiculo)Session["Vehiculo"];

            if (sistema.GetRegistrosPagos(vehiculo.Dominio) != null)
            {
                Response.Redirect("Pago.aspx");
            }
            else
            {
                LabelMensaje.ForeColor = Color.Red;
                LabelMensaje.Text = "El vehículo no tiene infracciones pagas.";
            }
        }
    }
}