using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio1;

namespace Practica2_Eventos
{
    public partial class AutoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                //Carga combo SIEMPRE primero
                ddlColores.Items.Clear();
                ddlColores.Items.Add("Blanco");
                ddlColores.Items.Add("Azul");
                ddlColores.Items.Add("Rojo");
                ddlColores.Items.Add("Negro");

                
                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"]);

                    AutoNegocio negocio = new AutoNegocio();
                    Auto a = negocio.buscarPorId(id);

                    txtId.Text = a.Id.ToString();
                    TxtModelo.Text = a.Modelo;
                    TxtDescripcion.Text = a.Descripcion;

                    //validar antes de asignar
                    if (ddlColores.Items.FindByValue(a.Color) != null)
                        ddlColores.SelectedValue = a.Color;

                    TxtFecha.Text = a.Fecha.ToString("yyyy-MM-dd");
                    chkUsado.Checked = a.Usado;
                    RdbImportado.Checked = a.Importado;
                    RdbNacional.Checked = !a.Importado;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Auto a = new Auto();

            if (Request.QueryString["id"] != null)
                a.Id = int.Parse(txtId.Text);

            a.Modelo = TxtModelo.Text;
            a.Descripcion = TxtDescripcion.Text;
            a.Color = ddlColores.SelectedValue;
            a.Fecha = DateTime.Parse(TxtFecha.Text);
            a.Usado = chkUsado.Checked;
            a.Importado = RdbImportado.Checked;

            AutoNegocio negocio = new AutoNegocio();

            if (Request.QueryString["id"] != null)
                negocio.modificar(a);
            else
                negocio.agregar(a);

            Response.Redirect("Default.aspx");
        }
    }
}