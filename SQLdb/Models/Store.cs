using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLdb.Models
{
    [Table("stores")]
    public class Store
    {
        [Key, Column("id")]
        public int Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        public List<Product> Products { get; } = new List<Product>();
        
        public List<Customer> Customers { get; } = new List<Customer>();
    }
}