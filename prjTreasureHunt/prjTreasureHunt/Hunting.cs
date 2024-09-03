using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace prjTreasureHunt
{
    public class Hunting
    {
        private readonly ILogger _logger;

        public Hunting(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Hunting>();
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }

        [Function("Submit")]
        [Table("Findings")]
        public IActionResult Submission([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            string[] findings = new string[] //CHANGE LATER FOR TABLES
            {
                "fidning1",
                "finding2",
                "finding3"
            };

            //this will extract data from azure tables 
            
            return new OkObjectResult(findings);

        }

        public async Task<List<Products>> GetAllProdsAsync() //extracts all products and their details
        {
            var prods = new List<Products>();
            await foreach (var prod in _prodTableClient.QueryAsync<Products>())
            {
                prods.Add(prod);
            }
            return prods;
        }
    }
}
