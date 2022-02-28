using System;
using System.ComponentModel.DataAnnotations;

namespace products_and_categories.Models
{
    public class Association
    {
        [Key]
        public int AssociationId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}