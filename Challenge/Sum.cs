using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class Sum
    {
        [FunctionName("Sum")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Sum/{firstnumber}/{secondnumber}")]
            HttpRequestMessage req, 
            double firstnumber, double secondnumber,TraceWriter log)
        {
            var result = firstnumber + secondnumber;
            //log.Info("C# HTTP trigger function processed a request.");

            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, "Result is " + result);
        }
    }
}
