using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace DemoWebApi
{
    public class AccessLogDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestContent = await request.Content.ReadAsStringAsync();
            //logger.Info($"[Request Body] : {requestContent}");
            var response = await SendAsync(request, cancellationToken);

            var responseContent = await response.Content.ReadAsStringAsync();
            //logger.Info($"[Response Body] : {responseContent}");
            return response;
        }
    }
}