namespace Inventario.Dtos
{
    public class StoreFilterDto
    {
        public bool paginate { get; set; } = false;
        public int perPage { get; set; } = 10;
        public int page { get; set; } = 1;
    }
}