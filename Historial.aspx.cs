using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTicketSupport
{


    public partial class Historial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarHistorial();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdTicket.Text = string.Empty;
            txtFechaDesde.Text = string.Empty;
            txtFechaHasta.Text = string.Empty;
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            using (var db = new Soporte_V5Entities1())
            {
                var historial = db.Historial_Tickets.AsQueryable();

                // Filtro por ID de ticket
                if (!string.IsNullOrEmpty(txtIdTicket.Text))
                {
                    int idTicket = Convert.ToInt32(txtIdTicket.Text);
                    historial = historial.Where(h => h.id_ticket == idTicket);
                }

                // Filtro por fecha de creación
                if (!string.IsNullOrEmpty(txtFechaDesde.Text) && !string.IsNullOrEmpty(txtFechaHasta.Text))
                {
                    DateTime fechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
                    DateTime fechaHasta = Convert.ToDateTime(txtFechaHasta.Text).AddDays(1).AddSeconds(-1); // Incluye el último segundo del día
                    historial = historial.Where(h => h.fecha_creacion >= fechaDesde && h.fecha_creacion <= fechaHasta);
                }

                gvHistorial.DataSource = historial.ToList();
                gvHistorial.DataBind();
            }
        }






    }
}