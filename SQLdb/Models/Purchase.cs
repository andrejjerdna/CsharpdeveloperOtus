using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLdb.Models
{
    [Table("purchases")]
    public class Purchase
    {
        [Key, Column("id")]
        public int Id { get; set; }
        
        [Column("date")]
        [Required]
        public DateTime Date { get; set; }
        
        [Column("customer_id")]
        public int CustomerId { get; set; }
        
        public Customer CustomerEntity { get; set; }
    }
}