using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIGatewayTest
{
    class MockHttpContext
    {
        public static IHttpContextAccessor GetHttpContext(string incomingRequestUrl, string host)
        {
            var context = new DefaultHttpContext();
            context.Request.Path = incomingRequestUrl;
            context.Request.Host = new HostString(host);
            context.Request.Scheme = "http";
            
            var obj = new HttpContextAccessor();
            obj.HttpContext = context;
            return obj;
        }
    }
}
