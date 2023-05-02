using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_AdvWorks.ViewModels
{
    public class MainWindowViewModel
    {
        private AdvContext Context = new AdvContext();
        public MainWindowViewModel()
        {
            Categories = Context.ProductCategories.ToList();
        }

        public List<ProductCategory> Categories
        {
            get { return categories; }
            set { categories = value; }
        }
        private List<ProductCategory> categories;
        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }
        private List<Product> products;
        public ProductCategory CurrentCategory
        {
            get { return currentCategory; }
            set
            {
                currentCategory = value;
                Products = Context.Products.Where(x => x.ProductSubcategory.ProductCategory.ProductCategoryID == currentCategory.ProductCategoryID).ToList();
            }
        }
        private ProductCategory currentCategory;

    }
}
