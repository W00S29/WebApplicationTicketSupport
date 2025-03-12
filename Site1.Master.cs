using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTicketSupport
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_usuario"] == null)
            {
                // El usuario no ha iniciado sesión, ocultar el menú
                menuDesplegable.Visible = false;
                
            }
            else
            {
                // El usuario ha iniciado sesión, mostrar el menú
                menuDesplegable.Visible = true;
                
            }
        }
    }
}