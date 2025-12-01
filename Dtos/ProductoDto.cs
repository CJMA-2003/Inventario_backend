namespace Inventario.Dtos
{
    public class ProductDto
    {
        /*
            INSERCIONES EN LA BASE DE DATOS
        */
        public string? code { get; set; }
        public string? name { get; set; }
        public int? categorization_id { get; set; }

        /*
            parametros para hacer peticiones GET
        */
        public bool paginate { get; set; } = false;
        public int perPage { get; set; } = 10;
        public int page { get; set; } = 1;
    }
}