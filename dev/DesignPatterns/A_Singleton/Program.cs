using A_Singleton;

var cache1 = MemoryCache.Instance;
var cache2 = MemoryCache.Instance;

cache1.Add("test", DateTime.Now);
var d = cache2.Get("test");

Console.WriteLine(d);
Console.WriteLine(Object.ReferenceEquals(cache2, cache1));


