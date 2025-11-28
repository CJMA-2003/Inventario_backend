using Inventario.Data;
using Inventario.Dtos;
using Inventario.Models;

namespace Inventario.Services
{

    public class CategorizationService
    {
        private readonly ApplicationDbContext _context;

        public CategorizationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Categorization> Insert(CategorizationDto dto)
        {
            var obj_insert = new Categorization
            {
                Value = dto.value,
                ParentId = dto.parent_id ?? 0
            };

            _context.Categorization.Add(obj_insert);
            await _context.SaveChangesAsync();
            return obj_insert;
        }

        public async Task<Categorization> Update(int id, CategorizationDto dto)
        {
            var item = _context.Categorization.Find(id);
            if (!string.IsNullOrEmpty(dto.value))
            {
                item.Value = dto.value;
            }

            if (dto.parent_id.HasValue)
            {
                item.ParentId = dto.parent_id.Value;
            }
            await _context.SaveChangesAsync();
            return item;
        }

    }
}