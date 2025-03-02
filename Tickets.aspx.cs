using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTicketSupport
{
    public partial class Tickets : System.Web.UI.Page
    {
        private int ObtenerIdUsuario()
        {
            if (Session["id_usuario"] != null)
            {
                return (int)Session["id_usuario"];
            }
            else
            {
                throw new Exception("El ID del usuario no se encuentra en la sesión.");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTickets();
                MostrarOcultarControlesPorRol(); // Nueva función para manejar roles
            }
        }

        private void MostrarOcultarControlesPorRol()
        {
            string rol = Session["rol"] as string;

            if (rol == "Cliente")
            {
                btnAgregar.Visible = true; // Mostrar botón para clientes
                gvTickets.Columns[5].Visible = false; // Ocultar columna de estado para clientes
            }
            else if (rol == "Tecnico")
            {
                btnAgregar.Visible = false; // Ocultar botón para técnicos
                gvTickets.Columns[5].Visible = true; // Mostrar columna de estado para técnicos
            }
            else if (rol == "Administrador")
            {
                btnAgregar.Visible = true; // Mostrar botón para administradores
                gvTickets.Columns[5].Visible = true; // Mostrar columna de estado para administradores
            }
            else
            {
                btnAgregar.Visible = false;
                gvTickets.Columns[5].Visible = false;
            }
        }

        private void CargarTickets()
        {
            using (var db = new Soporte_V5Entities1())
            {
                var tickets = db.Soporte_Tickets.ToList();
                gvTickets.DataSource = tickets;
                gvTickets.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var db = new Soporte_V5Entities1())
            {
                int usuarioId = ObtenerIdUsuario();

                Soporte_Tickets nuevoTicket = new Soporte_Tickets
                {
                    id_usuario = usuarioId,
                    asunto = txtAsunto.Text,
                    descripcion = txtDescripcion.Text,
                    prioridad = txtPrioridad.Text,
                    categoria = txtCategoria.Text,
                    estado = ddlEstado.SelectedValue,
                    fecha_creacion = DateTime.Now,
                    fecha_cierre = DateTime.Now
                };

                db.Soporte_Tickets.Add( nuevoTicket);
                db.SaveChanges();


            }

            txtAsunto.Text = "";
            txtDescripcion.Text = "";
            txtPrioridad.Text = "";
            txtCategoria.Text = "";
            CargarTickets();
        }

        protected void gvTickets_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTickets.EditIndex = e.NewEditIndex;
            CargarTickets();
        }

        protected void gvTickets_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTickets.EditIndex = -1;
            CargarTickets();
        }

        protected void gvTickets_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(gvTickets.DataKeys[e.RowIndex].Value);

            using (var db = new Soporte_V5Entities1())
            {
                Soporte_Tickets ticket = db.Soporte_Tickets.Find(id);

                if (ticket != null)
                {
                    GridViewRow row = gvTickets.Rows[e.RowIndex];

                    ticket.asunto = (row.Cells[1].Controls[0] as TextBox).Text;
                    ticket.descripcion = (row.Cells[2].Controls[0] as TextBox).Text;
                    ticket.prioridad = (row.Cells[3].Controls[0] as TextBox).Text;
                    ticket.categoria = (row.Cells[4].Controls[0] as TextBox).Text;
                    ticket.estado = (row.Cells[5].Controls[0] as TextBox).Text;

                    db.SaveChanges();
                }
            }

            gvTickets.EditIndex = -1;
            CargarTickets();
        }

        protected void gvTickets_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvTickets.DataKeys[e.RowIndex].Value);

            using (var db = new Soporte_V5Entities1())
            {
                Soporte_Tickets ticket = db.Soporte_Tickets.Find(id);

                if (ticket != null)
                {
                    db.Soporte_Tickets.Remove(ticket);
                    db.SaveChanges();
                }
            }

            CargarTickets();
        }
    }
}

