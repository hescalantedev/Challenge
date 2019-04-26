using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Challenge
{
    public static class Article_Details
    {
        [FunctionName("Article_Details")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Article_Details/{article_name}/{unit_price}/{quantity}/{perception}")]
            HttpRequestMessage req, 
            string article_name, double unit_price, int quantity, int perception, TraceWriter log)
        {
            //log.Info("You have to separate the values with slash '/' and the order of parameters is => article_name/unit_price/quantity/perception");
            //log.Info("The perception is tax recharge apart from the IVA");

            double final_perception = 21 + perception;
            double subtotal = unit_price * quantity;
            double perception_percent = final_perception / 100 + 1;
            double total = subtotal * perception_percent;

            var details = "Article: " + article_name + "\n\n" +
                          "Unit Price: " + unit_price + "\n\n" +
                          "Quantity: " + quantity + "\n\n" +
                          "Perception + IVA: " + perception + "% + 21% => " + final_perception + "\n\n" +
                          "------------------------------------------------" + "\n\n" +
                          "Subtotal  $" + subtotal + "\n\n" +
                          "Total $" + total;

            //var stream = new FileStream(@"http://localhost:7071\index.html", FileMode.Open);

            //var response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StreamContent(stream);
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            //return response;


            // Fetching the name from the path parameter in the request URL
            return req.CreateResponse(HttpStatusCode.OK, details);
        }
    }
}
