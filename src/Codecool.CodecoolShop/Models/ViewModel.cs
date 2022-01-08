using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class ViewModel
    {
        public List<Product> products { get; set; }
        public List<ProductCategory> categories { get; set; }
        public List<Supplier> suppliers { get; }

        public ViewModel(List<Product> products, List<ProductCategory> categories, List<Supplier> suppliers)
        {
            this.categories = categories;
            this.products = products;
            this.suppliers = suppliers;
        }

    }
    
    
}