using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models
{
    [Table("suppliers")]
    public class Supplier
    {

        [Column("id")]
        public int Id { get; set; }
        [Column("company_id")]
        public int CompanyId { get; set; }
        [Column("identification_number")]
        public string IdentificationNumber { get; set; }

        [Column("name")]
        public string Name { get; set; }

    }
}