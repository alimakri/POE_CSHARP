using A_ContratWCF;
using A_Service1WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace A_HostWCF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host1 = new ServiceHost(typeof(Service1));
            //host1.AddServiceEndpoint(
            //    typeof(IService1),
            //    new NetTcpBinding(),
            //    "net.tcp://localhost:1234/serviceMajuscule");
            //host1.AddServiceEndpoint(
            //    typeof(IService1),
            //    new BasicHttpBinding(),
            //    "http://localhost:8080/serviceMajuscule");
            host1.Open();
           
            Console.WriteLine("Je suis prêt");
            Console.ReadLine();

            host1.Close();
        }
    }
}
