using B_Binding.MagasinViewModels;
using System.Windows;

namespace B_Binding.Views
{
    /// <summary>
    /// Logique d'interaction pour FormMagasin.xaml
    /// </summary>
    public partial class FormMagasin : Window
    {
        public FormMagasin()
        {
            InitializeComponent();
            DataContext = new FormMagasinViewModel();
        }
    }
}
