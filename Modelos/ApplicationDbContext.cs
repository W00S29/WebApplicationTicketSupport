using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplicationTicketSupport.Modelos
{


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=conexion") { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Tecnicos> Tecnicos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
    }

    public class Usuario
    {
        [Key]
        public int id_usuario { get; set; }
       
        public string nombre { get; set; }
        [Required, StringLength(100)]
        public string correo { get; set; }
        [Required]
        public string contraseña { get; set; }
        [Required]
        public string rol { get; set; } // cliente, técnico, administrador
        public DateTime fecha_registro { get; set; } // cliente, técnico, administrador
    }
    [Table("Administrador")] // Evita la pluralización automática
    public class Administrador
    {
        [Key]
        public int id_admin { get; set; }
        
        public int id_usuario { get; set; }
       
    }
    public class Tecnicos
    {
        [Key]
        public int id_tecnico { get; set; }
       
        public int id_usuario { get; set; }
       
        public string especialidades { get; set; }
       
    }
    public class Clientes
    {
        [Key]
        public int id_cliente { get; set; }
        
        public int id_usuario { get; set; }
       
    }

    public class Ticket
    {
        [Key]
        public int id_ticket { get; set; }

        public int id_admin { get; set; }
        [ForeignKey("id_admin")]
        public virtual Administrador Administrador { get; set; }

        public int id_cliente { get; set; }
        [ForeignKey("id_cliente")]
        public virtual Clientes Cliente { get; set; }

        public int id_tecnico { get; set; }
        [ForeignKey("id_tecnico")]
        public virtual Tecnicos Tecnico { get; set; }

        public string asunto { get; set; }
        public string descripcion { get; set; }
        public string prioridad { get; set; }
        public string categoria { get; set; }
        public string estado { get; set; } // abierto, en progreso, resuelto, cerrado
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_cierre { get; set; } // Nullable para tickets abiertos
    }


}