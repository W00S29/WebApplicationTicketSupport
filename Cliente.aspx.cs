using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTicketSupport
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarTicket_Click(object sender, EventArgs e)
        {
            // Redirige a la página para agregar un nuevo ticket
            Response.Redirect("AgregarTickets.aspx");
        }

        protected void btnVerTickets_Click(object sender, EventArgs e)
        {
            // Redirige a la página para ver los tickets del usuario
            Response.Redirect("VerTickets.aspx");
        }
    }
}