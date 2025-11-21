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

        public DbSet<Company> Company { get; set; }
        public DbSet<Store> Store{ get; set; }
        public DbSet<Storage> Storage{ get; set; }
    }
}
