using caracterizacion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<EntidadesXCampana> EntidadesXCampana { get; set; }
        public DbSet<Entidad> Entidad { get; set; }
        public DbSet<Selector_Detail> Selector_Detail { get; set; }
        public DbSet<Validacion> Validacion { get; set; }
        public DbSet<ProfesionalesXCampana> ProfesionalesXCampana { get; set; }
        public DbSet<Anla> Anla { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<Log_Auditoria> Log_Auditoria { get; set; }
        public DbSet<Rastro> Rastro { get; set; }
        public DbSet<Revision_Ajuste> Revision_Ajuste { get; set; }


    }
}