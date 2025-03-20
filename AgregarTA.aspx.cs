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
    public partial class AgregarTA : System.Web.UI.Page
    {
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            using (var db = new Soporte_V5Entities1())
            {
                if (db.Soporte_Usuarios.Any(u => u.correo == txtCorreo.Text))
                {
                    lblMensaje.Text = "El correo ya está registrado.";
                    return;
                }

                int rolId = int.Parse(ddlRol.SelectedValue); // Obtener el id_rol seleccionado

                Soporte_Usuarios nuevoUsuario = new Soporte_Usuarios
                {
                    nombre = txtNombre.Text,
                    correo = txtCorreo.Text,
                    contraseña = HashPassword(txtContraseña.Text),
                    id_rol = rolId, // Asignar el id_rol
                    fecha_registro = DateTime.Now,
                };

                db.Soporte_Usuarios.Add(nuevoUsuario);
                db.SaveChanges();

                // Manejar especialidades si el rol es Técnico
                if (rolId == ObtenerIdRolTecnico(db)) // Reemplaza ObtenerIdRolTecnico con tu lógica
                {
                    GuardarEspecialidadesTecnico(nuevoUsuario.id_usuario, txtEspecialidad.Text, db);
                }

                lblMensaje.Text = "Registro exitoso.";
                Response.Redirect("Usuarios.aspx");
            }
        }

        private void GuardarEspecialidadesTecnico(int usuarioId, string especialidades, Soporte_V5Entities1 db)
        {
            if (string.IsNullOrEmpty(especialidades)) return; // No hacer nada si no hay especialidades

            string[] especialidadesArray = especialidades.Split(',');

            foreach (string especialidadNombre in especialidadesArray)
            {
                string especialidadTrim = especialidadNombre.Trim();

                // Verificar si la especialidad ya existe
                Soporte_Especialidades especialidadExistente = db.Soporte_Especialidades.FirstOrDefault(e => e.descripcion == especialidadTrim);

                int especialidadId;

                if (especialidadExistente == null)
                {
                    // Crear nueva especialidad si no existe
                    Soporte_Especialidades nuevaEspecialidad = new Soporte_Especialidades { descripcion = especialidadTrim };
                    db.Soporte_Especialidades.Add(nuevaEspecialidad);
                    db.SaveChanges();
                    especialidadId = nuevaEspecialidad.id_especialidad;
                }
                else
                {
                    especialidadId = especialidadExistente.id_especialidad;
                }

                // Crear la relación en EspecialidadesTecnicos
                Soporte_EspecialidadesTecnicos et = new Soporte_EspecialidadesTecnicos { id_usuario = usuarioId, id_especialidad = especialidadId };
                db.Soporte_EspecialidadesTecnicos.Add(et);
            }

            db.SaveChanges();
        }

        private int ObtenerIdRolTecnico(Soporte_V5Entities1 db)
        {
            //Debe obtener el id del rol de tecnico de la base de datos.
            Soporte_Roles rolTecnico = db.Soporte_Roles.FirstOrDefault(r => r.nombre == "Tecnico"); //Asumiendo que el nombre del rol es "Tecnico"
            if (rolTecnico != null)
            {
                return rolTecnico.id_rol;
            }
            else
            {
                throw new Exception("Rol Tecnico no encontrado.");
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

        protected void ddlRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rolId = int.Parse(ddlRol.SelectedValue);
            panelEspecialidad.Visible = rolId == ObtenerIdRolTecnico(new Soporte_V5Entities1()); //Reemplazar por el contexto de la pagina.
        }
    }
}