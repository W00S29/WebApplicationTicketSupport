using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTicketSupport
{
    public partial class ActualizarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosUsuario();
                CargarRoles();
            }
        }

        private void CargarDatosUsuario()
        {
            int idUsuario = Convert.ToInt32(Request.QueryString["id"]);

            using (var db = new Soporte_V5Entities1())
            {
                Soporte_Usuarios usuario = db.Soporte_Usuarios.Find(idUsuario);

                if (usuario != null)
                {
                    txtNombre.Text = usuario.nombre;
                    txtCorreo.Text = usuario.correo;
                    ddlRol.SelectedValue = usuario.id_rol.ToString(); // Establece el rol seleccionado
                }
            }
        }

        private void CargarRoles()
        {
            using (var db = new Soporte_V5Entities1())
            {
                ddlRol.DataSource = db.Soporte_Roles.ToList();
                ddlRol.DataTextField = "nombre";
                ddlRol.DataValueField = "id_rol";
                ddlRol.DataBind();
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(Request.QueryString["id"]);

            using (var db = new Soporte_V5Entities1())
            {
                Soporte_Usuarios usuario = db.Soporte_Usuarios.Find(idUsuario);

                if (usuario != null)
                {
                    usuario.nombre = txtNombre.Text;
                    usuario.correo = txtCorreo.Text;
                    usuario.fecha_registro = DateTime.Now;
                    usuario.id_rol = Convert.ToInt32(ddlRol.SelectedValue); // Actualiza el rol

                    // Hashear la contraseña antes de guardarla
                    usuario.contraseña = HashPassword(txtContraseña.Text);

                    db.SaveChanges();
                    Response.Redirect("Usuarios.aspx");
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
