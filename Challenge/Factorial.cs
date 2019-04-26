using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class Factorial
    {
        [FunctionName("Factorial")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "Factorial/{number}")]
            HttpRequestMessage req, int number, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");

            var result = 1;

            string serie = "1.";

            for (int i = 1; i <= number; i++)
            {
                if(i != 1)
                {
                    if(i == number)
                    {
                        serie += i;
                    }
                    else
                    {
                        serie += i + ".";
                    }
                }
                result = result * i;
            }
            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, "!" + number + " = " + serie + " = " + result);
        }
    }
}
