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
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.SignalR;
using TestOwin.Config;
using TestOwin.Hubs;

namespace TestOwin
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("")
            });

            var idProvider = new CustomUserIdProvider();
            GlobalHost.DependencyResolver.Register(typeof(IUserIdProvider), () => idProvider);

            //设置默认文件夹为“Web”文件夹
            string exeFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (exeFolder != null){
                appBuilder.UseStaticFiles(new Microsoft.Owin.StaticFiles.StaticFileOptions()
                {
                    RequestPath = new PathString(""),
                    FileSystem = new PhysicalFileSystem(Path.Combine(exeFolder, "Web"))
                });
            }

            //配置Hub出错时的处理Handling
            GlobalHost.HubPipeline.AddModule(new ErrorHandlingPipelineModule());
            appBuilder.MapSignalR();

            //设置跨域并启动signalR功能
            //appBuilder.Map("/signalr", map =>
            //{
            //    map.UseCors(CorsOptions.AllowAll);
            //    var hubConfiguration = new HubConfiguration { };
            //    map.RunSignalR(hubConfiguration);
            //});

            //创建Http配置文件
            var config = new HttpConfiguration();

            //配置http路由
            config.MapHttpAttributeRoutes();
            RouteConfig.RegisterRoutes(config.Routes);

            //应用Http配置
            appBuilder.UseWebApi(config);

        }
    }
}
