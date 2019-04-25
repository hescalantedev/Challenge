using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class LogicalCircuit_XOR
    {
        [FunctionName("LogicalCircuit_XOR")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]
            HttpRequestMessage req, TraceWriter log)
        {
            //log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string binary1 = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "binary1", true) == 0)
                .Value;

            string binary2 = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "binary2", true) == 0)
                .Value;

            if (binary1 == null || binary2 == null)
            {
                // Get request body
                dynamic data1 = await req.Content.ReadAsAsync<object>();
                binary1 = data1?.binary1;
                // Get request body
                dynamic data2 = await req.Content.ReadAsAsync<object>();
                binary2 = data2?.binary2;
            }
            else
            {
                if ((binary1 != "1" && binary1 != "0") || (binary2 != "1" && binary2 != "0"))
                {
                    return binary1 == null
                                        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                                        : req.CreateResponse(HttpStatusCode.OK, "The input is not a binary number");
                }
                else
                {
                    if (binary1 == "1" || binary2 == "1")
                    {
                        return binary1 == null
                                        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                                        : req.CreateResponse(HttpStatusCode.OK, "Result of the logic gate XOR is False");
                    }

                    if (binary1 == "0" || binary2 == "0")
                    {
                        return binary1 == null
                                        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                                        : req.CreateResponse(HttpStatusCode.OK, "Result of the logic gate XOR is False");
                    }

                    if ((binary1 == "1" || binary2 == "0") || (binary1 == "0" || binary2 == "1"))
                    {
                        return binary1 == null
                                        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                                        : req.CreateResponse(HttpStatusCode.OK, "Result of the logic gate XOR is True");
                    }
                }
            }
            return null;
        }
    }
}
