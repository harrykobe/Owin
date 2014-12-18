using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
