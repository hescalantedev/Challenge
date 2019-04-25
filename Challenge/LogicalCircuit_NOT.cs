using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class LogicalCircuit_NOT
    {
        [FunctionName("LogicalCircuit_NOT")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]
            HttpRequestMessage req, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string binary = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "binary", true) == 0)
                .Value;

            if (binary == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                binary = data?.binary;
            }
            else
            {
                if(binary != "1" && binary != "0")
                {
                    return binary == null
                                        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                                        : req.CreateResponse(HttpStatusCode.OK, "The input is not a binary number");
                }
                else
                {
                    if (binary == "1")
                    {
                        return binary == null
                                        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                                        : req.CreateResponse(HttpStatusCode.OK, "Result of the logic gate NOT is False");
                    }
                    else
                    {
                        return binary == null
                    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                    : req.CreateResponse(HttpStatusCode.OK, "Result of the logic gate NOT is True");
                    }
                }               
            }
            return null;
        }
    }
}
