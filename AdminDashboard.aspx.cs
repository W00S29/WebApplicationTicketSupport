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
                CargarTicketsSinAsignar();
                CargarTicketsAbierto();
                CargarTicketsEnprogrso();
                CargarTicketsResuelto();
                CargarTicketsCerrado();



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

        private void CargarTicketsEnprogrso()
        {
            using (var db = new Soporte_V5Entities1())
            {
                var tickets = db.Soporte_Tickets
                    .Where(t => t.estado == "En Progreso")
                    .ToList();

                TicketsEnprogreso.DataSource = tickets;
                TicketsEnprogreso.DataBind();
            }
        }

        private void CargarTicketsResuelto()
        {
            using (var db = new Soporte_V5Entities1())
            {
                var tickets = db.Soporte_Tickets
                    .Where(t => t.estado == "resuelto")
                    .ToList();

                TicketsResuelto.DataSource = tickets;
                TicketsResuelto.DataBind();
            }
        }

        private void CargarTicketsCerrado()
        {
            using (var db = new Soporte_V5Entities1())
            {
                var tickets = db.Soporte_Tickets
                    .Where(t => t.estado == "cerrado")
                    .ToList();

                TicketsCerrado.DataSource = tickets;
                TicketsCerrado.DataBind();
            }
        }

        private void CargarTicketsAbierto()
        {
            using (var db = new Soporte_V5Entities1())
            {
                var tickets = db.Soporte_Tickets
                    .Where(t => t.estado == "abierto")
                    .ToList();

                TicketsAbierto.DataSource = tickets;
                TicketsAbierto.DataBind();
            }
        }






        private void CargarTicketsSinAsignar()
        {
            using (var db = new Soporte_V5Entities1())
            {
                var tickets = db.Soporte_Tickets.Where(t => t.id_tecnico == null).ToList();
                gvTickets.DataSource = tickets;
                gvTickets.DataBind();

                foreach (GridViewRow row in gvTickets.Rows)
                {
                    DropDownList ddlTecnicos = (DropDownList)row.FindControl("ddlTecnicos");
                    if (ddlTecnicos != null)
                    {
                        CargarTecnicos(ddlTecnicos);
                    }
                }
            }
        }

        private void CargarTecnicos(DropDownList ddlTecnicos)
        {
            using (var db = new Soporte_V5Entities1())
            {
                var tecnicos = db.Soporte_Usuarios.Where(u => u.id_rol == 2).ToList(); // Asumiendo que 2 es el rol de técnico
                ddlTecnicos.DataSource = tecnicos;
                ddlTecnicos.DataTextField = "nombre";
                ddlTecnicos.DataValueField = "id_usuario";
                ddlTecnicos.DataBind();
            }
        }

        protected void gvTickets_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Asignar")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvTickets.Rows[rowIndex];
                int idTicket = Convert.ToInt32(gvTickets.DataKeys[rowIndex].Value);
                DropDownList ddlTecnicos = (DropDownList)row.FindControl("ddlTecnicos");
                int idTecnico = Convert.ToInt32(ddlTecnicos.SelectedValue);

                using (var db = new Soporte_V5Entities1())
                {
                    var ticket = db.Soporte_Tickets.Find(idTicket);
                    if (ticket != null)
                    {
                        ticket.id_tecnico = idTecnico;
                        db.SaveChanges();
                        lblMensaje.Text = "Ticket asignado correctamente.";
                    }
                    else
                    {
                        lblMensaje.Text = "Error al asignar el ticket.";
                    }
                }

                CargarTicketsSinAsignar(); // Recargar la lista de tickets
            }

        }
    }
}
    
