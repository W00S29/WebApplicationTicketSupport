using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplicationTicketSupport
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
                CargarDatos();
            }
        }

        private void CargarUsuarios()
        {
            using (var db = new Soporte_V5Entities1())
            {
                var usuarios = db.Soporte_Usuarios.ToList();
                gvUsuarios.DataSource = usuarios;
                gvUsuarios.DataBind();
            }
        }
        private void CargarDatos()
        {
            using (var db = new Soporte_V5Entities1())
            {
                var roles = db.Soporte_Roles.ToList();

                int idAdministrador = roles.FirstOrDefault(r => r.nombre == "Administrador")?.id_rol ?? 0;
                int idTecnico = roles.FirstOrDefault(r => r.nombre == "Tecnico")?.id_rol ?? 0;
                int idCliente = roles.FirstOrDefault(r => r.nombre == "Cliente")?.id_rol ?? 0;

                lblAdministradores.Text = db.Soporte_Usuarios.Count(t => t.id_rol == idAdministrador).ToString();
                lblTecnicos.Text = db.Soporte_Usuarios.Count(t => t.id_rol == idTecnico).ToString();
                lblClientes.Text = db.Soporte_Usuarios.Count(t => t.id_rol == idCliente).ToString();
            }
        }

        protected void btnAmarillo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarTA.aspx");
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EliminarUsuario")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);

                // Lógica para eliminar el usuario de la base de datos
                EliminarUsuario(idUsuario);

                // Recargar el GridView
                CargarUsuarios();
            }
            else if (e.CommandName == "ActualizarUsuario")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);
                //Aquí puedes redirigir a una página de edición, o hacer que el GridView sea editable.
                //Ejemplo de redirección.
                Response.Redirect($"ActualizarUsuarios.aspx?id={idUsuario}");
            }
        }

        private void EliminarUsuario(int idUsuario)
        {
            using (var db = new Soporte_V5Entities1())
            {
                Soporte_Usuarios usuario = db.Soporte_Usuarios.Find(idUsuario);

                if (usuario != null)
                {
                    db.Soporte_Usuarios.Remove(usuario);
                    db.SaveChanges();
                }
            }
        }

        


    }
}