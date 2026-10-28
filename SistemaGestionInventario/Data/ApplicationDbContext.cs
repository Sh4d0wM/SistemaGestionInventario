using Microsoft.EntityFrameworkCore;
using SistemaGestionInventario.Models;

namespace SistemaGestionInventario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; } = default!;
    }
}