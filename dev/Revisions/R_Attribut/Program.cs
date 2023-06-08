using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace R_Attribut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string caption = "Hello";
            string text = "Exemple de dll Import";
            Test.ShowMessageBox(0, text, caption, 0);
            Console.ReadLine();
        }
    }
    public static class Test
    {
        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int ShowMessageBox(int hwnd, string text, string caption, uint type);
    }
}
