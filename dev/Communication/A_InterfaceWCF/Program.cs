using A_ContratWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace A_InterfaceWCF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "Ali Makri";

            IService1 svc1;

            // Demande d'instance à WCF équivalent svc1=new Service1().
            var canal = new ChannelFactory<IService1>(new NetTcpBinding(), "net.tcp://localhost:1234/serviceMajuscule");
            svc1 = canal.CreateChannel(); 

            string t = svc1.Majuscule(s);


            Console.WriteLine(t);
            Console.ReadLine();
        }
    }
}
