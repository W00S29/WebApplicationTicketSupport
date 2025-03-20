using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace WebApplicationTicketSupport
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (var db = new Soporte_V5Entities1())
            {
                string correo = txtCorreo.Text;
                string contraseña = HashPassword(txtContraseña.Text);

                Soporte_Usuarios usuario = db.Soporte_Usuarios.FirstOrDefault(u => u.correo == correo && u.contraseña == contraseña);

                if (usuario != null)
                {
                    // Guardar información común en la sesión
                    Session["id_usuario"] = usuario.id_usuario;
                    Session["nombre"] = usuario.nombre;
                    Session["id_rol"] = usuario.id_rol; // Guardar el id_rol
                   
                  

                    // Obtener el nombre del rol desde la tabla Roles
                    Soporte_Roles rol = db.Soporte_Roles.FirstOrDefault(r => r.id_rol == usuario.id_rol);

                    if (rol != null)
                    {
                        Session["rol"] = rol.nombre; // Guardar el nombre del rol
                    }
                    else
                    {
                        // Manejar el caso en que no se encuentra el rol (debería ser raro)
                        lblMensaje.Text = "Rol no encontrado.";
                        return; // Detener el proceso de inicio de sesión
                    }

                    Response.Redirect("Cliente.aspx"); // Redirigir después de procesar el rol
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