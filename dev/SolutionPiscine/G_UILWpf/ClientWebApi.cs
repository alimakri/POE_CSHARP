using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace G_UILWpf
{
    internal class ClientWebApi
    {
        private WebClient Client = new WebClient();
        internal Dictionary<string, object> GetPiscines(string regex)
        {
            Client.Headers.Add("Content-Type", "application/json");
            var s = Client.UploadString($"http://localhost:57974/api/piscine/?cache=nocache", "POST", "\"" + regex.Replace("\"", @"\""") + "\"");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(s);
        }
    }
}
