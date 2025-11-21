using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Models
{
    [Table("company")]
    public class Company
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("identidad")]
        public string Identidad{ get; set; }
        [Column("nombre")]
        public string Nombre{ get; set; }
        [Column("direccion")]
        public string Direccion{ get; set; }
    }
}