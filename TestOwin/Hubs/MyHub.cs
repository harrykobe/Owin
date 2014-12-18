using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace TestOwin.Hubs
{
    public class MyHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        //public override Task OnConnected()
        //{
        //    string name = Context.User.Identity.Name;

        //    _connections.Add(name, Context.ConnectionId);

        //    return base.OnConnected();
        //}
        public void Send(string message)
        {
            Clients.All.addMessage(message); //
        }
    }
}