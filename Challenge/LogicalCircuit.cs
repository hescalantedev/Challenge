using System.Net;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class LogicalCircuit
    {
        [FunctionName("LogicalCircuit")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "LogicalCircuit/{firstbinary}/{secondbinary}")]
            HttpRequestMessage req, 
            int firstbinary, int secondbinary, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");
            if((firstbinary != 0 && firstbinary != 1) || (secondbinary != 0 && secondbinary != 1))
            {
                return req.CreateResponse(HttpStatusCode.OK, "Be careful!!! Some of the parameters is not binary");
            }
            else
            {
                if (firstbinary == 1 && secondbinary == 1)
                {
                    return req.CreateResponse(HttpStatusCode.OK, "True");
                }

                if (firstbinary == 0 && secondbinary == 0)
                {
                    return req.CreateResponse(HttpStatusCode.OK, "False");
                }

                if ((firstbinary == 1 || secondbinary == 0) || (firstbinary == 0 || secondbinary == 1))
                {
                    return req.CreateResponse(HttpStatusCode.OK, "False");
                }
            }
            return req.CreateResponse(HttpStatusCode.BadRequest, "Bad Request");
            // Fetching the name from the path parameter in the request URL
        }
    }
}
