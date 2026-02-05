using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Data.SqlClient;
=======
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
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
<<<<<<< HEAD
                ddlColores.Items.Add("Gris");
                ddlColores.Items.Add("Amarillo");


=======

                
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
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
<<<<<<< HEAD
            lblError.Visible = false;

=======
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
            Auto a = new Auto();

            if (Request.QueryString["id"] != null)
                a.Id = int.Parse(txtId.Text);

            a.Modelo = TxtModelo.Text;
            a.Descripcion = TxtDescripcion.Text;
            a.Color = ddlColores.SelectedValue;
<<<<<<< HEAD
            DateTime fecha;

            if (!DateTime.TryParse(TxtFecha.Text, out fecha))
            {
                // Fecha inválida o vacía
                lblError.Text = "⚠️ Debe ingresar una fecha válida";
                lblError.Visible = true;
                return;
            }

            a.Fecha = fecha;
=======
            a.Fecha = DateTime.Parse(TxtFecha.Text);
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
            a.Usado = chkUsado.Checked;
            a.Importado = RdbImportado.Checked;

            AutoNegocio negocio = new AutoNegocio();

<<<<<<< HEAD
            int idAuto;

            if (Request.QueryString["id"] != null)
            {
                negocio.modificar(a);
                idAuto = a.Id; // ya existe
            }
            else
            {
                idAuto = negocio.agregar(a); // 👈 ACÁ VA
            }

            HistorialAutoNegocio historialNegocio = new HistorialAutoNegocio();

            historialNegocio.agregar(new HistorialAuto
            {
                IdAuto = idAuto,
                Fecha = DateTime.Now,
                Accion = Request.QueryString["id"] != null ? "Modificación" : "Alta",
                Descripcion = Request.QueryString["id"] != null
                    ? "Se modificaron los datos del vehículo"
                    : "Se dio de alta el vehículo"
            });
=======
            if (Request.QueryString["id"] != null)
                negocio.modificar(a);
            else
                negocio.agregar(a);
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add

            Response.Redirect("Default.aspx");
        }
    }
}