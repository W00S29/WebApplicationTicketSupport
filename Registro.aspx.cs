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
    public partial class Registro : System.Web.UI.Page
    {
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (var db = new ApplicationDbContext())
            {
                if (db.Usuarios.Any(u => u.correo == txtCorreo.Text))
                {
                    lblMensaje.Text = "El correo ya está registrado.";
                    return;
                }

                Usuario nuevoUsuario = new Usuario
                {
                    nombre = txtNombre.Text,
                    correo = txtCorreo.Text,
                    contraseña = HashPassword(txtContraseña.Text),
                    rol = ddlRol.SelectedValue,
                    fecha_registro = DateTime.Now,
                };

                db.Usuarios.Add(nuevoUsuario);
                db.SaveChanges();

               // lblMensaje.ForeColor = System.Drawing.Color.Green;
                //lblMensaje.Text = "Usuario registrado con éxito.";

                AsignarRol(nuevoUsuario.id_usuario, nuevoUsuario.rol, db);

                lblMensaje.Text = "Registro exitoso.";
                Response.Redirect("Login.aspx");

            }
        }


        private void AsignarRol(int usuarioId, string rol, ApplicationDbContext db)
        {
            if (rol == "Cliente")
            {
                db.Clientes.Add(new Clientes { id_usuario = usuarioId });
            }
            else if (rol == "Técnico")
            {
                db.Tecnicos.Add(new Tecnicos { id_usuario = usuarioId, especialidades = txtEspecialidad.Text });
            }
            else if (rol == "Administrador")
            {
                db.Administrador.Add(new Administrador { id_usuario = usuarioId });
            }

            db.SaveChanges();
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

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelEspecialidad.Visible = ddlRol.SelectedValue == "Técnico";
        }
    }
}
