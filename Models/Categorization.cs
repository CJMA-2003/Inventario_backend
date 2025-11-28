using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models
{
    [Table("categorization")]
    public class Categorization
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("parent_id")]
        public int ParentId { get; set; }

        [Column("value")]
        public string Value { get; set; }
    }
}