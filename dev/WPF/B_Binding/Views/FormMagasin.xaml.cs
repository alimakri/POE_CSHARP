using B_Binding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
