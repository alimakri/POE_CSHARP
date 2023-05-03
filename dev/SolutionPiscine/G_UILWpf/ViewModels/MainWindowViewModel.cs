using Piscine_BOL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_UILWpf.ViewModels
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Metier.Init();
            Metier.GetPiscines(new ArrayList { 0 });
        }
        public List<PiscineViewModel> Piscines { get; set; }
    }
    public class PiscineViewModel
    {
    }
}
