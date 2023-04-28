using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace O_ExoXsl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var transformer = new XslCompiledTransform();
            transformer.Load(@"..\..\piscine.xslt");
            transformer.Transform(@"..\..\piscine.html", @"..\..\piscine.xml");
        }
    }
}
