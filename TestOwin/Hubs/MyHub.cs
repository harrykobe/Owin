using Microsoft.AspNet.SignalR;

namespace TestOwin
{
    public class MyHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.addMessage(message); //
        }
    }
}