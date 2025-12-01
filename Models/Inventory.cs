using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models
{
    [Table("inventorys")]
    public class Inventory
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("movement_date")]
        public DateTime MovementDate { get; set; }

        [Column("movement_type")]
        public MovementTypeEnum MovementType { get; set; }

        [Column("document_type")]
        public DocumentTypeEnum DocumentType { get; set; }

        [Column("storage_id")]
        public int? StorageId { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("supplier_id")]
        public int? SupplierId { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("freight_price")]
        public decimal FreightPrice { get; set; }

        [Column("customer_id")]
        public int? CustomerId { get; set; }

        [Column("invoice_number")]
        public string InvoiceNumber { get; set; }
    }
}