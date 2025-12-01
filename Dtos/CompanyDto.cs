namespace Inventario.Dtos
{
    public class CompanyDto
    {
        public string? identidad { get; set; }
        public string? nombre { get; set; }
        public string? direccion { get; set; }
        public bool paginate { get; set; } = false;
        public int perPage { get; set; } = 10;
        public int page { get; set; } = 1;
    }

}