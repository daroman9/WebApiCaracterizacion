using caracterizacion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApiCaracterizacion.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Campo> Campo { get; set; }
        public DbSet<Formulario> Formulario { get; set; }
        public DbSet<Plantilla> Plantilla { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<Registro_Tabla> Registros_Tabla { get; set; }
        public DbSet<Selector> Selector { get; set; }
        public DbSet<Tablas_Campo> Tablas_Campo { get; set; }
        public DbSet<Ficha> Ficha { get; set; }
        public DbSet<EntidadesXCampana> EntidadesXCampana { get; set; }
        public DbSet<Entidad> Entidad { get; set; }
        public DbSet<Profesionales> Profesionales { get; set; }
        public DbSet<Selector_Detail> Selector_Detail { get; set; }
        public DbSet<Validacion> Validacion { get; set; }
        public DbSet<ProfesionalesXCampana> ProfesionalesXCampana { get; set; }

    }
}