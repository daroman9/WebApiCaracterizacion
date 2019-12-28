using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using caracterizacion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace WebApiPaises.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            : base(options)
        {
            
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Campo> Campos { get; set; }
        public DbSet<Formato> Formatos { get; set; }
    }
}
