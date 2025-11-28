using Inventario.Data;
using Inventario.Models;
using Inventario.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Inventario.Services

{
    public class StorageService
    {

        private readonly ApplicationDbContext _context;

        public StorageService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Storage> Insert(StorageCreateDto dto)
        {
            var obj_insert = new Storage
            {
                Name = dto.name,
                Address = dto.address,
                StoreId = dto.store_id,
            };

            _context.Storage.Add(obj_insert);
            await _context.SaveChangesAsync();
            return obj_insert;
        }


        public async Task<object> List(StorageFilterDto dto)
        {
            var query = _context.Storage.AsQueryable();
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

            var stores = await query.ToListAsync();
            return new
            {
                data = stores
            };
        }

        public async Task<Storage> Update(int id,StorageUpdateDto dto)
        {
            var storage = _context.Storage.Find(id);
            if(!string.IsNullOrEmpty(dto.name))
            {
                storage.Name = dto.name;
            }

            if(!string.IsNullOrEmpty(dto.address))
            {
                storage.Address = dto.address;
            }

            if(dto.store_id.HasValue){
                storage.StoreId = dto.store_id.Value;
            }
            await _context.SaveChangesAsync();
            return storage;
        }

        public async Task<bool> Delete(int id)
        {
            // Busca el registro
            var registro = await _context.Storage.FindAsync(id);

            if (registro == null)
                return false; // No existe
            // Elimina
            _context.Storage.Remove(registro);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}