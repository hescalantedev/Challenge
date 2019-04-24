using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class Subtract
    {
        [FunctionName("Subtract")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Subtract/{firstnumber}/{secondnumber}")]
            HttpRequestMessage req, 
            double firstnumber, double secondnumber, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");
            var result = firstnumber - secondnumber;
            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, "Result is " + result);
        }
    }
}
