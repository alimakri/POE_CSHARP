using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZA_WebSocket
{
    public class ChatHub : Hub
    {
        public void Envoyer(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
    }
}