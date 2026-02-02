using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio1;

namespace Practica2_Eventos
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                AutoNegocio negocio = new AutoNegocio();
                var lista = negocio.listar();

                dgvAutos.DataSource = lista;
                dgvAutos.DataBind();

                lblVacio.Visible = lista.Count == 0;
            }

        }

        protected void dgvAutos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Auto auto = (Auto)e.Row.DataItem;

                Label lblUsado = (Label)e.Row.FindControl("lblUsado");
                lblUsado.Text = auto.Usado ? "Nuevo" : "Usado";
                lblUsado.CssClass = auto.Usado
                    ? "badge bg-success"
                    : "badge bg-secondary";

                Label lblOrigen = (Label)e.Row.FindControl("lblOrigen");
                lblOrigen.Text = auto.Importado ? "Importado" : "Nacional";
                lblOrigen.CssClass = auto.Importado
                    ? "badge bg-warning text-dark"
                    : "badge bg-info text-dark";
            }

        }

        protected void dgvAutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var x = dgvAutos.SelectedRow.Cells[0];
            var Id = dgvAutos.SelectedDataKey.Value.ToString();
            Response.Redirect("AutoForm.aspx?id=" + Id);
        }

        protected void dgvAutos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(dgvAutos.DataKeys[e.RowIndex].Value.ToString());

            AutoNegocio negocio = new AutoNegocio();
            negocio.eliminar(id);

            dgvAutos.DataSource = negocio.listar();
            dgvAutos.DataBind();
        }

        protected void dgvAutos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvAutos.PageIndex = e.NewPageIndex;
            CargarListaFiltrada();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            dgvAutos.PageIndex = 0;
            CargarListaFiltrada();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = "";
            ddlColorFiltro.SelectedIndex = 0;
            ddlOrigenFiltro.SelectedIndex = 0;

            AutoNegocio negocio = new AutoNegocio();
            dgvAutos.DataSource = negocio.listar();
            dgvAutos.DataBind();

            lblVacio.Visible = false;
        }

        private void CargarListaFiltrada()
        {
            AutoNegocio negocio = new AutoNegocio();
            List<Auto> lista = negocio.listar();

            // Texto (modelo)
            if (!string.IsNullOrEmpty(txtFiltro.Text))
            {
                lista = lista
                    .Where(a => a.Modelo
                    .ToLower()
                    .Contains(txtFiltro.Text.ToLower()))
                    .ToList();
            }

            // Color
            if (!string.IsNullOrEmpty(ddlColorFiltro.SelectedValue))
            {
                lista = lista
                    .Where(a => a.Color == ddlColorFiltro.SelectedValue)
                    .ToList();
            }

            // Origen
            if (!string.IsNullOrEmpty(ddlOrigenFiltro.SelectedValue))
            {
                bool importado = ddlOrigenFiltro.SelectedValue == "Importado";
                lista = lista
                    .Where(a => a.Importado == importado)
                    .ToList();
            }

            dgvAutos.DataSource = lista;
            dgvAutos.DataBind();

            lblVacio.Visible = lista.Count == 0;
        }
    }
}