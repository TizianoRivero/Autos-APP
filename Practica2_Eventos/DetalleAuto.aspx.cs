using Dominio1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica2_Eventos
{
    public partial class DetalleAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {               
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"]);
                        CargarDetalle(id);
                        CargarHistorial(id);
                    }
                }            
        }
        private void CargarDetalle(int id)
        {
            AutoNegocio negocio = new AutoNegocio();
            Auto auto = negocio.listar().Find(a => a.Id == id);

            lblModelo.Text = auto.Modelo;
            lblDescripcion.Text = auto.Descripcion;
            lblColor.Text = auto.Color;
            lblFecha.Text = auto.Fecha.ToShortDateString();
            lblUsado.Text = auto.Usado ? "Usado" : "Nuevo";
            lblOrigen.Text = auto.Importado ? "Importado" : "Nacional";
        }
        private void CargarHistorial(int idAuto)
        {
            HistorialAutoNegocio negocio = new HistorialAutoNegocio();
            rptHistorial.DataSource = negocio.listarPorAuto(idAuto);
            rptHistorial.DataBind();
        }
    }
}