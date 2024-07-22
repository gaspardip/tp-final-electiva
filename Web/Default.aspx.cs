using Business.Models;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Web.UI;


namespace Web
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
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
                LabelMensaje.ForeColor = System.Drawing.Color.Red;
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
                LabelMensaje.ForeColor = System.Drawing.Color.Red;
                LabelMensaje.Text = "El vehículo no tiene infracciones pagas.";
            }
        }   

    }

}