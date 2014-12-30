using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.ErrorHandling;

namespace TestOwin.Helper
{
    class RethrowStatusCodeHandler:IStatusCodeHandler
    {
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            throw new NotImplementedException();
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            throw new NotImplementedException();
        }
    }
}
