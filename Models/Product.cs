using System.ComponentModel.DataAnnotations.Schema;


namespace Inventario.Models
{

    [Table("products")]
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        public string Code { get; set; }

        [Column("name")]
        public string Name { get; set; }
        [Column("stock")]
        public decimal Stock { get; set; }
        // Foreign Key
        [Column("categorization_id")]
        public int CategorizationId { get; set; }

        [ForeignKey(nameof(CategorizationId))]
        public Categorization categorization { get; set; }

    }
}