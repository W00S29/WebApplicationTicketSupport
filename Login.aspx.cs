using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using WebApplicationTicketSupport.Modelos;

namespace WebApplicationTicketSupport
{
  
        public partial class Login : System.Web.UI.Page
        {
            protected void btnLogin_Click(object sender, EventArgs e)
            {
                using (var db = new ApplicationDbContext())
                {
                    string correo = txtCorreo.Text;
                    string contraseña = HashPassword(txtContraseña.Text);

                    Usuario usuario = db.Usuarios.FirstOrDefault(u => u.correo == correo && u.contraseña == contraseña);

                    if (usuario != null)
                    {
                        // Guardar sesión
                        Session["id_usiario"] = usuario.id_usuario;
                        Session["nombre"] = usuario.nombre;
                        Session["rol"] = usuario.rol;

                    // Redirigir a la página principal
                    if (usuario.rol == "Cliente")
                        Response.Redirect("Tickets.aspx");
                    else if (usuario.rol == "Tecnico")
                        Response.Redirect("Tickets.aspx");
                    else if (usuario.rol == "Administrador")
                        Response.Redirect("Tickets.aspx");
                }
                    else
                    {
                        lblMensaje.Text = "Correo o contraseña incorrectos.";
                    }
                }
            }

            private string HashPassword(string password)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                    StringBuilder builder = new StringBuilder();
                    foreach (byte b in bytes)
                    {
                        builder.Append(b.ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }
 }

