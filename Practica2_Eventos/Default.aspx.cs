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
<<<<<<< HEAD
        private bool HayFiltrosActivos()
        {
            return
                !string.IsNullOrWhiteSpace(txtFiltro.Text) ||
                !string.IsNullOrWhiteSpace(ddlColorFiltro.SelectedValue) ||
                !string.IsNullOrWhiteSpace(ddlOrigenFiltro.SelectedValue);
        }
        private void ActualizarMensajeResultados(int total)
        {
            // 🚫 Si NO hay filtros → no muestro nada
            if (!HayFiltrosActivos())
            {
                lblResultados.Visible = false;
                return;
            }

            // 🚫 Si hay filtros pero no hay resultados
            if (total == 0)
            {
                lblResultados.Visible = true;
                return;
            }

            int desde = dgvAutos.PageIndex * dgvAutos.PageSize + 1;
            int hasta = Math.Min(desde + dgvAutos.PageSize - 1, total);

            lblResultados.Text = $"Mostrando {desde} a {hasta} de {total} autos filtrados";
            lblResultados.Visible = true;
        }
=======
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add

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
<<<<<<< HEAD
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                var btnPrev = (LinkButton)e.Row.FindControl("btnPrev");
                var btnNext = (LinkButton)e.Row.FindControl("btnNext");

                if (btnPrev != null)
                    btnPrev.Enabled = dgvAutos.PageIndex > 0;

                if (btnNext != null)
                    btnNext.Enabled = dgvAutos.PageIndex < dgvAutos.PageCount - 1;
            }
=======

>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
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
<<<<<<< HEAD
            int nuevoIndex = e.NewPageIndex;

            if (nuevoIndex < 0)
                nuevoIndex = 0;

            if (nuevoIndex >= dgvAutos.PageCount)
                nuevoIndex = dgvAutos.PageCount - 1;

            dgvAutos.PageIndex = nuevoIndex;
=======
            dgvAutos.PageIndex = e.NewPageIndex;
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
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

<<<<<<< HEAD
            dgvAutos.PageIndex = 0;
            lblVacio.Visible = false;
            CargarListaFiltrada();
=======
            lblVacio.Visible = false;
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
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

<<<<<<< HEAD
            int pageCount = (int)Math.Ceiling((double)lista.Count / dgvAutos.PageSize);
            if (dgvAutos.PageIndex >= pageCount)
            {
                dgvAutos.PageIndex = 0;
            }

=======
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
            dgvAutos.DataSource = lista;
            dgvAutos.DataBind();

            lblVacio.Visible = lista.Count == 0;
<<<<<<< HEAD

            ActualizarMensajeResultados(lista.Count);

            if (!HayFiltrosActivos())
            {
                lblResultados.Visible = false;
            }
=======
>>>>>>> d307e7339e7e932130540a6fe9099db4c9d69add
        }
    }
}