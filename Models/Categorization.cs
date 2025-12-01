using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models
{
    [Table("categorizations")]
    public class Categorization
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("company_id")]
        public int CompanyId { get; set; }

        [Column("parent_id")]
        public int? ParentId { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }


        [ForeignKey(nameof(ParentId))]
        public Categorization Parent { get; set; }

        public ICollection<Categorization> Children { get; set; }


    }
}