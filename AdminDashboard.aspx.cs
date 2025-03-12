using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTicketSupport
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
               
            }
        }

        private void CargarDatos()
        {
            using (var db = new Soporte_V5Entities1()) // Reemplaza con tu contexto de base de datos
            {
                lblAbiertos.Text = db.Soporte_Tickets.Count(t => t.estado == "Abierto").ToString();
                lblEnProgreso.Text = db.Soporte_Tickets.Count(t => t.estado == "En Progreso").ToString();
                lblResueltos.Text = db.Soporte_Tickets.Count(t => t.estado == "Resuelto").ToString();
                lblCerrados.Text = db.Soporte_Tickets.Count(t => t.estado == "Cerrado").ToString();
            }
        }
       
    }
}
    
