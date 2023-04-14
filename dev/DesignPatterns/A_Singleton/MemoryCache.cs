using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Singleton
{
    public class MemoryCache
    {
        private Dictionary<string, object> CacheObjects;
        private static MemoryCache Cache = new MemoryCache();
        public static MemoryCache Instance => Cache;
        //{
        //    get
        //    {
        //        return Cache;
        //    }
        //}
        private MemoryCache()
        {
            CacheObjects = new ();
        }
        public void Add(string key, object valeur)
        {
            CacheObjects.Add(key, valeur);
        }
        public object? Get(string key)
        {
            if (CacheObjects.ContainsKey(key)) return CacheObjects[key];
            return null;
        }
    }
}
