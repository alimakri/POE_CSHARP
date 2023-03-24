using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLTD1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c = new CoffreFort();
            c.Password = "abc";
            var x = c.Code;
            c.Code = "456";

            Console.WriteLine(x);
            Console.ReadLine();
        }
    }
    public class CoffreFort
    {
        public string Password;
        private string code="123456";

        //public string GetCode()
        //{
        //    if (Password == "abc") return code;
        //    return null;
        //}
        public string Code
        {
            get
            {
                if (Password == "abc") return code;
                return null;
            }
            set
            {
                if (Password == "xyz") code = value;
            }
        }
    }
}
