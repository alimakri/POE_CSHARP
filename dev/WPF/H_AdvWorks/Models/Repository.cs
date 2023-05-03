using H_AdvWorks.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace H_AdvWorks.Models
{
    public class Repository
    {
        private AdvContext Context = new AdvContext();
        public List<CategorieViewModel> GetCategories()
        {
            return Context.ProductCategories.Select(x => new CategorieViewModel
            {
                Id = x.ProductCategoryID,
                Nom = x.Name
            }).ToList();
        }

        public List<ProduitViewModel> GetProducts(int productCategoryID)
        {
            var produits = Context.Products
                .Where(x => x.ProductSubcategory.ProductCategory.ProductCategoryID == productCategoryID);
            return produits.Select(x => new ProduitViewModel
            {
                Id = x.ProductID,
                Nom = x.Name,
                Reference = x.ProductNumber,
                Vignette = x.ProductProductPhotoes.FirstOrDefault() == null ? null : x.ProductProductPhotoes.FirstOrDefault().ProductPhoto.ThumbNailPhoto
            }).ToList();
        }
    }
}
