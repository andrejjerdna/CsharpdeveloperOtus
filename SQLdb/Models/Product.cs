using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLdb.Models
{
    [Table("products")]
    public class Product
    {
        [Key, Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        [Required]
        public string Name { get; set; }
        
        [Column("price")]
        [Required]
        public float Price { get; set; }
        
        [Column("store_id")]
        public int StoreId { get; set; }
        
        public Store StoreEntity { get; set; }
    }
}