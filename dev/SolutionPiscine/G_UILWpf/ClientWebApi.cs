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
        internal Dictionary<string, object> CallAspnetApi(string regexName, string regex)
        {
            Client.Headers.Add("Content-Type", "application/json");
            var s = Client.UploadString($"http://localhost:57974/api/piscine/?cache=nocache&cle={regexName}", "POST", "\"" + regex.Replace("\"", @"\""") + "\"");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(s);
        }

        internal Dictionary<string, object> CallNodejsApi(string nom)
        {
            Client.Headers.Add("Content-Type", "application/json");
            var s = Client.UploadString($"http://localhost:8081/{nom}", "GET");
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(s);
        }
    }
}
