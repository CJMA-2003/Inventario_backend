using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("identification_number")]
        public string IdentificationNumber { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}