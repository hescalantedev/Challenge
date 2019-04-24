using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class Div
    {
        [FunctionName("Div")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Div/{firstnumber}/{secondnumber}")]
             HttpRequestMessage req, 
            double firstnumber, double secondnumber, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");
            if(secondnumber == 0)
            {
                return req.CreateResponse(HttpStatusCode.OK, "Warning!!! You can not divide by zero");
            }
            else
            {
                var result = firstnumber / secondnumber;
                // Fetching the name from the path parameter in the request URL
                return req.CreateResponse(HttpStatusCode.OK, "Result is " + result);
            }
        }
    }
}
