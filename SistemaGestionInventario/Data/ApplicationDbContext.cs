using Microsoft.EntityFrameworkCore;
using SistemaGestionInventario.Models;

namespace SistemaGestionInventario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<SistemaGestionInventario.Models.Categoria> Categoria { get; set; } = default!;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; } = default!;
    }
}