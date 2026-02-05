using Dominio1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica2_Eventos
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public int CantidadUsados { get; set; }
        public int CantidadNuevos { get; set; }
        public int CantidadImportados { get; set; }
        public int CantidadNacionales { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEstadisticas();
                CargarActividad();
            }
        }

        private void CargarActividad()
        {
            HistorialAutoNegocio negocio = new HistorialAutoNegocio();
            rptActividad.DataSource = negocio.listarUltimos(5);
            rptActividad.DataBind();
        }

        private void CargarEstadisticas()
        {
            AutoNegocio negocio = new AutoNegocio();
            List<Auto> autos = negocio.listar();

            CantidadUsados = autos.Count(a => a.Usado);
            CantidadNuevos = autos.Count(a => !a.Usado);
            CantidadImportados = autos.Count(a => a.Importado);
            CantidadNacionales = autos.Count(a => !a.Importado);

            lblTotalAutos.Text = autos.Count.ToString();
            lblUsados.Text = CantidadUsados.ToString();
            lblNuevos.Text = CantidadNuevos.ToString();
            lblImportados.Text = CantidadImportados.ToString();
            lblNacionales.Text = CantidadNacionales.ToString();
        }
    }
}