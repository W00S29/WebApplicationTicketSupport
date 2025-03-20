using System;
using System.Linq;

namespace WebApplicationTicketSupport
{
    public partial class AgregarTickets : System.Web.UI.Page
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
                    prioridad = ddlPrioridad.SelectedValue,
                    categoria = txtCategoria.Text,
                    estado = ddlEstado.SelectedValue,
                    fecha_creacion = DateTime.Now,
                    fecha_cierre = DateTime.Now
                };

                db.Soporte_Tickets.Add(nuevoTicket);
                db.SaveChanges();
                Response.Redirect("Cliente.aspx");
            }

            txtAsunto.Text = "";
            txtDescripcion.Text = "";
           
            txtCategoria.Text = "";
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }
    }
}