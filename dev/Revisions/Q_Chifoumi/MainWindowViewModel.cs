using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Q_Chifoumi
{
    public class MainWindowViewModel
    {
        #region Bindings
        public ICommand PierreCommand { get; set; }
        public ICommand FeuilleCommand { get; set; }
        public ICommand CiseauCommand { get; set; }
        public int Points { get; set; }
        public string Message { get; set; }
        public string MessageCouleur { get; set; }
        public ChoixViewModel ChoixMachine { get; set; }
        #endregion
    }
    public class ChoixViewModel
    {
        public string Image { get; set; }
        public string Texte { get; set; }
    }
}
