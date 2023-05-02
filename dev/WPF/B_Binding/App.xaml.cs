using B_Binding.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace B_Binding
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var f1 = new MainWindow();
            f1.Show();
            var f2 = new FormMagasin();
            f2.Show();
        }
    }
}
