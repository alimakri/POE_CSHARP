﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Jessy
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            while(i < 1000000000)
            {
                using (var g = new Gros())
                {
                    // ----
                    //GC.Collect();
                }
            }

        }
    }
    class Gros : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
