using System;
using System.Linq;
using System.Threading;
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
            //string name = Context.User.Identity.Name;
            //_connections.Remove(name, Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            //string name = Context.User.Identity.Name;
            //if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            //{
            //    _connections.Add(name, Context.ConnectionId);
            //}
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


        public void Echo(String data)
        {
            Clients.Caller.Echo(data);
        }

        public void UpdateState(String name, int val)
        {
            Clients.Caller.name = val;
        }

        public void TriggerError()
        {
            throw new HubException("Dummy error");
        }

        public void JoinGroup(String groupName)
        {
            this.Groups.Add(Context.ConnectionId, groupName);
        }

        public void LeaveGroup(String groupName)
        {
            this.Groups.Remove(Context.ConnectionId, groupName);
        }

        public void SendMessageToGroup(String groupName, String message)
        {
            this.Clients.Group(groupName).echo(message);
        }

        public String WaitAndReturn(int seconds)
        {
            Thread.Sleep(seconds * 1000);

            return "Done!";
        }


        public string HeaderData(String headerName)
        {
            return Context.Headers[headerName];
        }
    }
}