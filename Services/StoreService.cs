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


        public async Task<Store> Insert(StoreCreateDto data)
        {
            var obj_insert = new Store
            {
                Code = data.code,
                Description = data.description,
                CompanyId = data.company_id,
            };
            _context.Store.Add(obj_insert);
            await _context.SaveChangesAsync();

            return obj_insert;
        }


        public async Task<object> List(StoreFilterDto filtros)
        {
            var query = _context.Store.Include(s => s.Company).AsQueryable();
            if (filtros.paginate)
            {
                var total = await query.CountAsync();

                var companies = await query
                    .Skip((filtros.page - 1) * filtros.perPage)
                    .Take(filtros.perPage)
                    .ToListAsync();

                return new
                {
                    data = companies,
                    current_page = filtros.page,
                    per_page = filtros.perPage,
                    total = total,
                    to = Math.Min(filtros.page * filtros.perPage, total)
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
            var store = await _context.Store.FindAsync(id);

            if (store == null)
                return false; // No existe

            // Elimina
            _context.Store.Remove(store);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<Store> Update(int id, StoreUpdateDto dto)
        {
            var store = _context.Store.Find(id);

            if (!string.IsNullOrEmpty(dto.code))
            {
                store.Code = dto.code;
            }

            if (!string.IsNullOrEmpty(dto.description))
            {
                store.Description = dto.description;
            }

            if (dto.company_id.HasValue)
            {
                store.CompanyId = dto.company_id.Value;
            }

            await _context.SaveChangesAsync();

            return store;
        }
    }
}