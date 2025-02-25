using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationTicketSupport.Modelos;


namespace WebApplicationTicketSupport
{
    public partial class Tickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTickets();
            }
        }

        private void CargarTickets()
        {
            using (var db = new ApplicationDbContext())
            {
                var Tickets = db.Tickets.ToList();
                gvTickets.DataSource = Tickets;
                gvTickets.DataBind();
            }
        }

       // ✅ Crear un nuevo ticket
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                Ticket nuevoTicket = new Ticket
                {
                   
                    asunto = txtAsunto.Text,
                    descripcion = txtDescripcion.Text,
                    prioridad = txtPrioridad.Text,
                    categoria = txtCategoria.Text,
                    estado = ddlEstado.SelectedValue,
                    fecha_creacion = DateTime.Now,
                    fecha_cierre = DateTime.Now
                };

                db.Tickets.Add(nuevoTicket);
                db.SaveChanges();
            }

            txtAsunto.Text = "";
            txtDescripcion.Text = "";
            txtPrioridad.Text = "";
            txtCategoria.Text = "";
            CargarTickets();
        }

        // ✅ Editar un ticket (activar modo edición)
        protected void gvTickets_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTickets.EditIndex = e.NewEditIndex;
            CargarTickets();
        }

        // ✅ Cancelar edición
        protected void gvTickets_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTickets.EditIndex = -1;
            CargarTickets();
        }

        // ✅ Actualizar ticket
        protected void gvTickets_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvTickets.DataKeys[e.RowIndex].Value);

            using (var db = new ApplicationDbContext())
            {
                Ticket ticket = db.Tickets.Find(id);

                if (ticket != null)
                {
                    GridViewRow row = gvTickets.Rows[e.RowIndex];

                    ticket.asunto = (row.Cells[1].Controls[0] as TextBox).Text;
                    ticket.descripcion = (row.Cells[2].Controls[0] as TextBox).Text;
                    ticket.prioridad = (row.Cells[2].Controls[0] as TextBox).Text;
                    ticket.categoria = (row.Cells[2].Controls[0] as TextBox).Text;
                    ticket.estado = (row.Cells[3].Controls[0] as TextBox).Text;

                    db.SaveChanges();
                }
            }

            gvTickets.EditIndex = -1;
            CargarTickets();
        }

        // ✅ Eliminar ticket
        protected void gvTickets_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvTickets.DataKeys[e.RowIndex].Value);

            using (var db = new ApplicationDbContext())
            {
                Ticket ticket = db.Tickets.Find(id);

                if (ticket != null)
                {
                    db.Tickets.Remove(ticket);
                    db.SaveChanges();
                }
            }

            CargarTickets();
        }
    }
}
    
