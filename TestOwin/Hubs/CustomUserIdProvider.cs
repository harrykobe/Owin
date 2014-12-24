using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace TestOwin.Hubs
{
    class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            //var userId = MyCustomUserClass.FindUserId(request.User.Identity.Name);
            return "Fuck";
        }
    }
}
