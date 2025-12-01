using Inventario.Data;
using Inventario.Dtos;
using Inventario.Models;
using Microsoft.EntityFrameworkCore;


namespace Inventario.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Insert(ProductDto dto)
        {
            var object_insert = new Product
            {
                Code = dto.code,
                Name = dto.name,
                CategorizationId = dto.categorization_id ?? 0
            };

            _context.Product.Add(object_insert);
            await _context.SaveChangesAsync();

            return object_insert;
        }


        public async Task<Product> Update(int id, ProductDto dto)
        {
            var item = _context.Product.Find(id);
            if (!string.IsNullOrEmpty(dto.code))
            {
                item.Code = dto.code;
            }

            if (!string.IsNullOrEmpty(dto.name))
            {
                item.Name = dto.name;
            }

            if (dto.categorization_id.HasValue)
            {
                item.CategorizationId = dto.categorization_id.Value;
            }
            await _context.SaveChangesAsync();
            return item;
        }


        public async Task<bool> Delete(int id)
        {
            var item = _context.Product.Find(id);
            _context.Product.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<Object> List(ProductDto dto)
        {
            var query = _context.Product
            .Include(x => x.categorization)
            .ThenInclude(c => c.Parent)
            .AsQueryable();

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