using Inventario.Data;
using Inventario.Models;
using Inventario.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Services
{

    public class StoreService
    {

        private readonly ApplicationDbContext _context;

        public StoreService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Store> Insert(StoreDto dto)
        {
            var obj_insert = new Store
            {
                Code = dto.code,
                Description = dto.description,
                CompanyId = dto.company_id ?? 0,
            };
            _context.Store.Add(obj_insert);
            await _context.SaveChangesAsync();

            return obj_insert;
        }


        public async Task<object> List(StoreDto dto)
        {
            var query = _context.Store.Include(s => s.Company).AsQueryable();
            if (dto.paginate)
            {
                var total = await query.CountAsync();

                var companies = await query
                    .Skip((dto.page - 1) * dto.perPage)
                    .Take(dto.perPage)
                    .ToListAsync();

                return new
                {
                    data = companies,
                    current_page = dto.page,
                    per_page = dto.perPage,
                    total = total,
                    to = Math.Min(dto.page * dto.perPage, total)
                };
            }

            var allCompanies = await query.ToListAsync();
            return new
            {
                data = allCompanies
            };
        }


        public async Task<bool> Delete(int id)
        {
            // Busca el registro
            var item = await _context.Store.FindAsync(id);

            if (item == null)
                return false; // No existe

            // Elimina
            _context.Store.Remove(item);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<Store> Update(int id, StoreDto dto)
        {
            var item = _context.Store.Find(id);

            if (!string.IsNullOrEmpty(dto.code))
            {
                item.Code = dto.code;
            }

            if (!string.IsNullOrEmpty(dto.description))
            {
                item.Description = dto.description;
            }

            if (dto.company_id.HasValue)
            {
                item.CompanyId = dto.company_id.Value;
            }

            await _context.SaveChangesAsync();

            return item;
        }
    }
}