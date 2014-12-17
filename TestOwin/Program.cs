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

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                //var response = client.GetAsync(baseAddress + "/api/values").Result;

                //Console.WriteLine(response);
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("Server running on {0}", baseAddress);
                Console.ReadLine();
            }

            
        }
    }
}
