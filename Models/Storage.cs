using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models
{
    [Table("storages")]
    public class Storage
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("address")]
        public string Address { get; set; }

        // Foreign Key
        [Column("store_id")]
        public int StoreId { get; set; }

        // Navegaci�n
        [ForeignKey(nameof(StoreId))]
        public Store Store { get; set; }
    }
}
