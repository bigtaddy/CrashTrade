using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ResourceMetadata.API.Infrastructure
{

    public class ResponseHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.Headers.Contains("Access-Control-Allow-Headers") && !response.Headers.Contains("Access-Control-Allow-Origin"))
            {
                response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with,authorization,content-type");
                response.Headers.Add("Access-Control-Allow-Origin", "*");
            }

            return response;
        }
    }
}