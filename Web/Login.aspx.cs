using System;
using System.Web.Security;
using System.Web.UI;
using Business.Models;

namespace Web
{
    public partial class Login : Page
    {
        private readonly SistemaInfracciones _sistema = new SistemaInfracciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            var sistema = Session["Sistema"];
            var vehiculo = Session["Vehiculo"];

            // Si el usuario ya está autenticado, redirigir a la página principal
            if (User.Identity.IsAuthenticated && sistema != null && vehiculo != null)
            {
                Response.Redirect("Default.aspx");
            }


            if (!IsPostBack)
            {
                Session["Sistema"] = _sistema;
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            var dominio = TextBoxUsername.Text;
            var password = TextBoxPassword.Text;

            var usuario = _sistema.BuscarVehiculo(dominio);

            if (usuario != null && password == "12345")
            {
                // Autenticación exitosa
                Session["Vehiculo"] = usuario;

                // Crea la cookie de autenticación
                FormsAuthentication.SetAuthCookie(dominio, false);

                // Redirige a la página predeterminada después del login
                Response.Redirect("Default.aspx");
            }
            else
            {
                // Autenticación fallida
                LabelMessage.Text = "Dominio o contraseña incorrectos.";
            }
        }
    }
}