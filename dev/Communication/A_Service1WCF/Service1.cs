using A_ContratWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Service1WCF
{
    public class Service1 : IService1
    {
        public string Majuscule(string s)
        {
            return s.ToUpper();
        }
    }
}
