using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTicketSupport
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void lnkSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            // Deshabilita el almacenamiento en caché del navegador
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            Response.AppendHeader("Pragma", "no-cache");

            // Redirige a la página de inicio de sesión
            Response.Redirect("Login.aspx");
        }


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


            // Verificar qué página está activa para mostrar u ocultar la sidebar
            string currentPage = Path.GetFileName(Request.PhysicalPath).ToLower();

            string rolUsuario = Session["rol"] as string;


            // Ocultar sidebar en páginas de login y registro
            if (currentPage == "login.aspx" || currentPage == "registro.aspx" || rolUsuario == "Cliente")
            {
                SidebarPanel.Visible = false;
                // Aplicar clase al MainContent para ocupar toda la pantalla

            }
            else if (rolUsuario == "Tecnico")
            { 
              AdminLink.Visible= false;
              UsuariosLink.Visible= false;
              HistorialLink.Visible = false;  
            
            }
            else
                {
                    SidebarPanel.Visible = true;
                // Aplicar clase al MainContent para dejar espacio a la sidebar
                
                }
            
        }
    }
}