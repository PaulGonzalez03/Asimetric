using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginAsimetricoSi.Models
{
    public class UsuarioDos
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public byte[] Contrasena { get; set; }
        public string LlavePrivada { get; set; }

        public class DBContext : DbContext
        {
            public DbSet<UsuarioDos> UsuarioDos { get; set; }
        }
    }
}