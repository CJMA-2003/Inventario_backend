using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models
{
    public class Storage
    {
        public int id { get; set; }

        public string name { get; set; }
        public string address { get; set; }

        // Foreign Key
        [Column("store_id")]
        public int StoreId{ get; set; }

        // Navegación
        [ForeignKey(nameof(StoreId))]
        public Store Store { get; set; }
    }
}
