using System;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;

namespace TestOwin
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://*:9007";
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Server running on {0}", baseAddress);
                Console.ReadLine();
            }

            
        }
    }
}
