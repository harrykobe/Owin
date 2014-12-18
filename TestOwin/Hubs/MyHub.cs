using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;

namespace TestOwin.Hubs
{
    public class MyHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public override Task OnConnected()
        {
            //string name = Context.User.Identity.Name;
            int n = new Random().Next(1000) + 1;
            string name = Convert.ToString(n);
            Console.WriteLine("{0} is Connect...", name);
            _connections.Add(name, Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;
            _connections.Remove(name, Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;
            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }
            return base.OnReconnected();
        }

        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }

        public void SendChatMessage(string who, string message)
        {
            //string name = Context.User.Identity.Name;
            foreach (var connectionId in _connections.GetConnections(who))
            {
                Clients.Client(connectionId).addMessage(message);
            }
        }
    }
}