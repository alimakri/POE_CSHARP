using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Threading;
using System.Web;

namespace W_Cache
{
    public class Repository
    {
        public Repository()
        {
            MemoryCache.Default.AddOrGetExisting("MesData", Get(), DateTime.Now.AddSeconds(30));
        }

        private string[] Get()
        {
            Thread.Sleep(5000);
            return File.ReadAllLines(@"d:\test1.txt");
        }

        public object GetCache()
        {
            return MemoryCache.Default.Get("MesData");
        }
    }
}