using System;
using System.Linq;

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
    }
}