using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class Abs
    {
        [FunctionName("Abs")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Abs/{number}")]
            HttpRequestMessage req, 
            double number, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");
            if(number < 0)
            {
                return req.CreateResponse(HttpStatusCode.OK, number * -1);
            }
            else
            {
                return req.CreateResponse(HttpStatusCode.OK, number);
            }
            // Fetching the name from the path parameter in the request URL
            
        }
    }
}
