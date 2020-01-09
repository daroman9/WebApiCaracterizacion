using caracterizacion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCaracterizacion.Models;

namespace WebApiCaracterizacion.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Campo> Campos { get; set; }
        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<Plantilla> Plantillas { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Registro_Tabla> Registros_Tablas { get; set; }
        public DbSet<Selector> Selectores { get; set; }
        public DbSet<Tablas_Campo> Tablas_Campos { get; set; }
        public DbSet<Ficha> Ficha { get; set; }
        public DbSet<WebApiCaracterizacion.Models.Selector_Detail> Selector_Detail { get; set; }

    }
}
