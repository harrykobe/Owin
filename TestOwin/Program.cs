using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using TestOwin.Helper;

namespace TestOwin
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://*:9007";
            INetFwManger.NetFwGetPorts(33065, "TCP");
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Server running on {0}", baseAddress);
                Console.ReadLine();
                //INetFwManger.NetFwDelPorts(9007, "TCP");
            }

            
        }
    }
}
