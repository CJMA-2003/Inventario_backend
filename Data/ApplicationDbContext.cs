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
        public DbSet<Store> Store { get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<Categorization> Categorization { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Inventory> Inventory { get; set; }

    }
}
