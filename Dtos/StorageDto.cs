namespace Inventario.Dtos
{
    public class StorageDto
    {
        public string? name { get; set; }
        public string? address { get; set; }
        public int? store_id { get; set; }
        public bool paginate { get; set; } = false;
        public int perPage { get; set; } = 10;
        public int page { get; set; } = 1;
    }
}