using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models
{
    [Table("store")] // nombre real en la BD
    public class Store
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("code")]
        public string Code { get; set; }
        
        [Column("description")]
        public string Description{ get; set; }
        
        [Column("company_id")]
        public int CompanyId{ get; set; }
        
        [ForeignKey(nameof(CompanyId))]
        public Company Company{ get; set; }
    }
}