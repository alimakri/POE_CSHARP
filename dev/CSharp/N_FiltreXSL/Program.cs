using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace N_FiltreXSL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var transformer = new XslCompiledTransform();
            transformer.Load(@"..\..\books.xslt");
            transformer.Transform(@"..\..\books.xml", @"..\..\books.html");
        }
    }
}
