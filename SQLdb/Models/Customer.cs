using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLdb.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key, Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        [Required]
        public string Name { get; set; }
        
        [Column("address")]
        [Required]
        public string Address { get; set; }
        
        [Column("store_id")]
        public int StoreId { get; set; }
        
        public Store StoreEntity { get; set; }
        
        public List<Purchase> Purchases { get; } = new List<Purchase>();
    }
}