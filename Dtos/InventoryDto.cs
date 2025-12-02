using Inventario.Models;

namespace Inventario.Dtos
{
    public class InventarioDto
    {
        public DateTime? movement_date { get; set; }
        public MovementTypeEnum? movement_type { get; set; }
        public DocumentTypeEnum? document_type { get; set; }
        public int? storage_id { get; set; }
        public int? product_id { get; set; }
        public int? supplier_id { get; set; }
        public decimal? amount { get; set; }
        public decimal? price { get; set; }
        public decimal? freight_price { get; set; }
        public int? customer_id { get; set; }
        public string? invoice_number { get; set; }
    }
}