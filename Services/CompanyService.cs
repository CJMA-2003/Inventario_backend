using Inventario.Data;
using Inventario.Dtos;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Services
{
    public class CompanyService
    {
        private readonly ApplicationDbContext _context;
        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Company> Insert(CompanyDto dto)
        {
            var obj_insert = new Company
            {
                Identidad = dto.identidad,
                Nombre = dto.nombre,
                Direccion = dto.direccion
            };

            _context.Company.Add(obj_insert);
            await _context.SaveChangesAsync();

            return obj_insert;
        }


        public async Task<Company> Update(int id, CompanyDto dto)
        {
            var item = _context.Company.Find(id);
            if (!string.IsNullOrEmpty(dto.identidad))
            {
                item.Identidad = dto.identidad;
            }

            if (!string.IsNullOrEmpty(dto.nombre))
            {
                item.Nombre = dto.nombre;
            }

            if (!string.IsNullOrEmpty(dto.direccion))
            {
                item.Direccion = dto.direccion;
            }
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> Delete(int id)
        {

            var item = _context.Company.Find(id);
            _context.Company.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Object> List(CompanyDto dto)
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