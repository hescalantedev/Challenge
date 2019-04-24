using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class Multiply
    {
        [FunctionName("Multiply")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Multiply/{number}/{anothernumber}")]
            HttpRequestMessage req, 
            double number, double anothernumber, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");
            var result = number * anothernumber;
            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, "Result is " + result);
        }
    }
}
