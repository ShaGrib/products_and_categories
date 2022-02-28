using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace products_and_categories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Must have a name")]
        [MinLength(2, ErrorMessage = "Name must be at last 2 characters")]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Association> Products { get; set; }
    }
}