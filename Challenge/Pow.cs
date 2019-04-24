using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class Pow
    {
        [FunctionName("Pow")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Pow/{number}/{grade}")]
            HttpRequestMessage req, 
            int number, int grade, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");
            var result = 0;
            for (int i = 1; i <= grade; i++)
            {
                if(i == 1)
                {
                    result = number;
                }
                else
                {
                    result = result * number;
                }
            }
            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, "Result is " + result);
        }
    }
}
