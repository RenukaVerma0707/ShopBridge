using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBridge.Infrastrusture.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}

