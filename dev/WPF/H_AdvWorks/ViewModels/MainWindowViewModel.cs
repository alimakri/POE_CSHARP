using H_AdvWorks.CommunViewModels;
using H_AdvWorks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_AdvWorks.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Repository Repo = new Repository();
        public MainWindowViewModel()
        {
            Categories = Repo.GetCategories();
        }

        public List<CategorieViewModel> Categories
        {
            get { return categories; }
            set { categories = value; }
        }
        private List<CategorieViewModel> categories;
        public List<ProduitViewModel> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged("Products"); }
        }
        private List<ProduitViewModel> products;
        public CategorieViewModel CurrentCategory
        {
            get { return currentCategory; }
            set
            {
                currentCategory = value;
                Products = Repo.GetProducts(currentCategory.Id);
            }
        }
        private CategorieViewModel currentCategory;

        //public ProduitViewModel CurrentProduct;

        public ProduitViewModel CurrentProduct
        {
            get { return currentProduct; }
            set
            {
                currentProduct = value;
                CurrentIndexOnglet = 1;
            }
        }
        private ProduitViewModel currentProduct;

        //public ProduitViewModel CurrentProduct { get; set; }


        public int CurrentIndexOnglet
        {
            get { return currentIndexOnglet; }
            set { currentIndexOnglet = value; OnPropertyChanged("CurrentIndexOnglet"); }
        }
        private int currentIndexOnglet;
    }

    public class CategorieViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
    }

    public class ProduitViewModel
    {

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int id;
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        private string nom;
        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }
        private string reference;
        public byte[] Vignette
        {
            get { return vignette; }
            set { vignette = value; }
        }
        private byte[] vignette;

    }
}
