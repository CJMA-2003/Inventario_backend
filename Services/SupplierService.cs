using Inventario.Data;
using Inventario.Dtos;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Services
{
    public class SupplierService
    {
        private readonly ApplicationDbContext _context;
        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Supplier> Insert(SupplierDto dto)
        {
            var obj_insert = new Supplier
            {
                IdentificationNumber = dto.identification_number,
                Name = dto.name,
                CompanyId = dto.company_id ?? 0
            };

            _context.Supplier.Add(obj_insert);
            await _context.SaveChangesAsync();

            return obj_insert;
        }


        public async Task<Supplier> Update(int id, SupplierDto dto)
        {
            var item = _context.Supplier.Find(id);
            if (!string.IsNullOrEmpty(dto.name))
            {
                item.Name = dto.name;
            }

            if (!string.IsNullOrEmpty(dto.identification_number))
            {
                item.IdentificationNumber = dto.identification_number;
            }
            if (dto.company_id.HasValue)
            {
                item.CompanyId = dto.company_id.Value;
            }

            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(int id)
        {

            var item = _context.Supplier.Find(id);
            _context.Supplier.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Object> List(SupplierDto dto)
        {
            var query = _context.Supplier.AsQueryable();

            if (dto.paginate)
            {
                var total = await query.CountAsync();

                var list = await query
                    .Skip((dto.page - 1) * dto.perPage)
                    .Take(dto.perPage)
                    .ToListAsync();

                return new
                {
                    data = list,
                    current_page = dto.page,
                    per_page = dto.perPage,
                    total = total,
                    to = Math.Min(dto.page * dto.perPage, total)
                };
            }
            else
            {
                var list = await query.ToListAsync();
                return new
                {
                    data = list
                };
            }
        }
    }
}