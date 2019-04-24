using System;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class SquareRoot
    {
        [FunctionName("SquareRoot")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "SquareRoot/{number}")]
            HttpRequestMessage req, 
            double number, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");
            if(number < 0)
            {
                return req.CreateResponse(HttpStatusCode.OK, "Pay attention!!! The square root of a negative number belongs to the set of imaginary numbers");
            }
            else
            {
                var result = Math.Sqrt(number);
                // Fetching the name from the path parameter in the request URL
                return req.CreateResponse(HttpStatusCode.OK, "Result is " + result);
            }
        }
    }
}
