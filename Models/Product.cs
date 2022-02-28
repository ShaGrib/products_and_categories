using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace products_and_categories.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Must have a name")]
        [MinLength(2, ErrorMessage = "Name must be at last 2 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Must have a description")]
        [MinLength(2, ErrorMessage = "Description must be at least 2 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Must have a price")]
        [DataType(DataType.Currency)]
        [Range(1,(double) decimal.MaxValue, ErrorMessage = "Price must be at least 1 dollar")]
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Association> Categories { get; set; }
    }
}