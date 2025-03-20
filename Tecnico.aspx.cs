using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTicketSupport
{
    public partial class Tecnico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTicketsAsignados();
            }
        }

        private void CargarTicketsAsignados()
        {
            if (Session["id_usuario"] != null)
            {
                int idTecnico = (int)Session["id_usuario"];

                using (var db = new Soporte_V5Entities1())
                {
                    var tickets = db.Soporte_Tickets.Where(t => t.id_tecnico == idTecnico).ToList();
                    gvTicketsAsignados.DataSource = tickets;
                    gvTicketsAsignados.DataBind();
                }
            }
            else
            {
                // Manejar el caso en que el ID del técnico no esté en la sesión (por ejemplo, redirigir a la página de inicio de sesión)
            }
        }

        protected void gvTicketsAsignados_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTicketsAsignados.EditIndex = e.NewEditIndex;
            CargarTicketsAsignados();

        }

        protected void gvTicketsAsignados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTicketsAsignados.EditIndex = -1;
            CargarTicketsAsignados();

        }

        protected void gvTicketsAsignados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                int idTicket = Convert.ToInt32(gvTicketsAsignados.DataKeys[e.RowIndex].Value);
                string asunto = ((TextBox)gvTicketsAsignados.Rows[e.RowIndex].FindControl("txtAsunto")).Text;
                string descripcion = ((TextBox)gvTicketsAsignados.Rows[e.RowIndex].FindControl("txtDescripcion")).Text;
                string prioridad = ((DropDownList)gvTicketsAsignados.Rows[e.RowIndex].FindControl("ddlPrioridad")).SelectedValue;
                string categoria = ((TextBox)gvTicketsAsignados.Rows[e.RowIndex].FindControl("txtCategoria")).Text;
                string estado = ((DropDownList)gvTicketsAsignados.Rows[e.RowIndex].FindControl("ddlEstado")).SelectedValue;

                // Actualizar el ticket en la base de datos
                ActualizarTicket(idTicket, asunto, descripcion, prioridad, categoria, estado);
                CargarTicketsAsignados();
                gvTicketsAsignados.EditIndex = -1;
               
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar el ticket: " + ex.Message;
            }
        }

        protected void gvTicketsAsignados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idTicket = Convert.ToInt32(gvTicketsAsignados.DataKeys[e.RowIndex].Value);

                // Eliminar el ticket de la base de datos
                EliminarTicket(idTicket);
                CargarTicketsAsignados();


            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar el ticket: " + ex.Message;
            }
        }

        

        private void ActualizarTicket(int idTicket, string asunto, string descripcion, string prioridad, string categoria, string estado)
        {
            using (var db = new Soporte_V5Entities1()) // Reemplaza Soporte_V5Entities1 con tu contexto de EF
            {
                Soporte_Tickets ticket = db.Soporte_Tickets.Find(idTicket);

                if (ticket != null)
                {
                    ticket.asunto = asunto;
                    ticket.descripcion = descripcion;
                    ticket.prioridad = prioridad;
                    ticket.categoria = categoria;
                    ticket.estado = estado;
                    
                    db.SaveChanges();
                    Response.Redirect("Tecnico.aspx");
                }
               
            }
        }

        private void EliminarTicket(int idTicket)
        {
            using (var db = new Soporte_V5Entities1()) // Reemplaza Soporte_V5Entities1 con tu contexto de EF
            {
                Soporte_Tickets ticket = db.Soporte_Tickets.Find(idTicket);

                if (ticket != null)
                {
                    db.Soporte_Tickets.Remove(ticket);
                    db.SaveChanges();
                }
            }
        }



    }
}