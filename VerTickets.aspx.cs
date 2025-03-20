using System;
using System.Linq;

namespace WebApplicationTicketSupport
{
    public partial class VerTickets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTickets();
                MostrarOcultarControlesPorRol();
            }
        }

        private void MostrarOcultarControlesPorRol()
        {
            string rol = Session["rol"] as string;

            if (rol == "Cliente")
            {
                gvTickets.Columns[6].Visible = false; // Ocultar columna de estado para clientes
                gvTickets.Columns[9].Visible = true; // Ocultar columna de eliminar para clientes
            }
            else if (rol == "Tecnico" || rol == "Administrador")
            {
                gvTickets.Columns[6].Visible = true; // Mostrar columna de estado para técnicos y administradores
                gvTickets.Columns[9].Visible = true; // Mostrar columna de eliminar para técnicos y administradores
            }
            else
            {
                gvTickets.Columns[6].Visible = false;
                gvTickets.Columns[9].Visible = false;
            }
        }

        private void CargarTickets()
        {
            string rol = Session["rol"] as string;

            if (rol == "Cliente")
            {
                int idUsuarioActual = Convert.ToInt32(Session["id_usuario"]);

                using (var db = new Soporte_V5Entities1())
                {
                    var tickets = db.Soporte_Tickets
                        .Where(t => t.id_usuario == idUsuarioActual)
                        .ToList();

                    gvTickets.DataSource = tickets;
                    gvTickets.DataBind();
                }


            }
            else
            {

                using (var db = new Soporte_V5Entities1())
                {
                    var tickets = db.Soporte_Tickets.ToList();
                    gvTickets.DataSource = tickets;
                    gvTickets.DataBind();
                }
            }
        }

        protected void gvTickets_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idTicket = Convert.ToInt32(gvTickets.DataKeys[Convert.ToInt32(e.CommandArgument)].Value);

                using (var db = new Soporte_V5Entities1())
                {
                    var ticket = db.Soporte_Tickets.Find(idTicket);
                    if (ticket != null)
                    {
                        db.Soporte_Tickets.Remove(ticket);
                        db.SaveChanges();
                        CargarTickets(); // Recargar la lista de tickets
                    }
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cliente.aspx");
        }
    }
}