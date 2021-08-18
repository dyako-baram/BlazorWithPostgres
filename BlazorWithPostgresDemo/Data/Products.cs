using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorWithPostgresDemo.Data
{   [Table("Products")]
    public class Products
    {
        [Key]
        public Guid Id { get; set; }
        [Column("product_name")]
        [MaxLength(255)]
        public string ProductName { get; set; }
        [Column("date_bought")]
        public DateTime DateBought { get; set; }
    }
}