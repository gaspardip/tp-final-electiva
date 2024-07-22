using Business.Models;
using System;
using System.Web;
using System.Web.UI;

namespace Web
{
    public partial class Login : Page
    {
        private readonly SistemaInfracciones _sistema = new SistemaInfracciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Si el usuario ya está autenticado, redirigir a la página principal
            if (User.Identity.IsAuthenticated)
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
            string dominio = TextBoxUsername.Text;
            string password = TextBoxPassword.Text;

            var usuario = _sistema.BuscarVehiculo(dominio);

            if (usuario != null && password == "12345")
            {

                // Autenticación exitosa
                Session["Vehiculo"] = usuario;

                // Crea la cookie de autenticación
                System.Web.Security.FormsAuthentication.SetAuthCookie(dominio, false);

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
