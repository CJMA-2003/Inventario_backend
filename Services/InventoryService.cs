using Inventario.Data;
using Inventario.Dtos;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Services
{
    public class InventoryService
    {
        private readonly ApplicationDbContext _context;
        public InventoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        /*public async Task<Inventory> Insert()
        {

        }*/

    }
}