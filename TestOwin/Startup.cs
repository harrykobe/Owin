using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.FileSystems;
using Owin;
using Microsoft.AspNet.SignalR;
using TestOwin.Config;

namespace TestOwin
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            //config.MapHttpAttributeRoutes();

            RouteConfig.RegisterRoutes(config.Routes);


            appBuilder.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubConfiguration = new HubConfiguration{};
                map.RunSignalR(hubConfiguration);
            });

            string exeFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string webFolder = Path.Combine(exeFolder, "Web");
            appBuilder.UseStaticFiles(new Microsoft.Owin.StaticFiles.StaticFileOptions()
            {
                RequestPath = new PathString(""),
                FileSystem = new PhysicalFileSystem(webFolder)
            });


            appBuilder.UseCors(CorsOptions.AllowAll);
            appBuilder.MapSignalR();
            appBuilder.UseWebApi(config);

        }
    }

    public class MyHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.addMessage(message);
        }
    }
}
