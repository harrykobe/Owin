using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace TestOwin.Helper
{
    public class LoggingMiddleware:OwinMiddleware
    {
        public LoggingMiddleware(OwinMiddleware next) : base(next)
        {

        }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server running on {0}", ex.ToString());
                //throw new NotImplementedException();
            }
        }
    }
}
