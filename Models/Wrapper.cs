using System.Collections.Generic;

namespace products_and_categories.Models
{
    public class Wrapper
    {
        public List<Product> AllProducts { get; set; }
        public Product Product { get; set; }
        public List<Category> AllCategories { get; set; }
        public Category Category { get; set; }
        public List<Association> AllAssociations { get; set; }
        public Association Association { get; set; }
    }
}
