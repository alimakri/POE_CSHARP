using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F_Binding
{
    public class MyData
    {
        public MyData()
        {
            ColorName = "Green";
            Description = "Button background color";
            ForeColorName = "Orange";
        }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public string ForeColorName { get; set; }
    }
}
