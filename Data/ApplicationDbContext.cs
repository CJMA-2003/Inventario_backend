using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Ejemplo tabla Productos
        public DbSet<Company> Company { get; set; }
    }
}
