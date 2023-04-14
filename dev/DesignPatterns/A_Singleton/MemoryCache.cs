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
        private static MemoryCache Cache = new();
        public static MemoryCache Instance => Cache;
        private MemoryCache() => CacheObjects = new();

        public void Add(string key, object valeur) => CacheObjects.Add(key, valeur);
        public object? Get(string key)
        {
            if (CacheObjects.ContainsKey(key)) return CacheObjects[key];
            return null;
        }
    }
    public class MemoryCacheSimple
    {
        private Personne P = new Personne();
        private static MemoryCacheSimple Cache = new MemoryCacheSimple();
        private MemoryCacheSimple()
        {
        }
        public static MemoryCacheSimple Get() { return Cache; }
        public Personne GetPersonne() { return P; }
    }
    public static class MemoryCacheSimplisime
    {
        public static Personne P = new Personne();
    }
    public class Personne
    {

    }
}
