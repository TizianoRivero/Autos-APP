using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio1;

namespace Practica2_Eventos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario user = negocio.Login(txtEmail.Text, txtPassword.Text);

            if (user != null)
            {
                Session["usuario"] = user;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblError.Text = "Email o contraseña incorrectos";
                lblError.Visible = true;
            }
        }
    }
}