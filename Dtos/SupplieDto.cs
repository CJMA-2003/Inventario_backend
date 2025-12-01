namespace Inventario.Dtos
{
    public class SupplierDto
    {
        /*
           INSERCIONES EN LA BASE DE DATOS
        */
        public string? identification_number { get; set; }
        public string? name { get; set; }
        public int? company_id { get; set; }

        /*
            parametros para hacer peticiones GET
        */
        public bool paginate { get; set; } = false;
        public int perPage { get; set; } = 10;
        public int page { get; set; } = 1;
    }
}