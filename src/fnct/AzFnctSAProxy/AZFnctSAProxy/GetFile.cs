using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Queues.Models;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AZFnctSAProxy
{
    public static class GetConfig
    {
        [FunctionName("GetConfig")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "{name}")] HttpRequest req,
           [Blob("configs/{name}", FileAccess.Read, Connection = "AzureWebJobsStorage")] byte[] config, 
           string name,
            ILogger log)
        {
            log.LogInformation($"File name: {name}");

            if(config == null)
            {
                return new ObjectResult(JsonConvert.SerializeObject(new {error ="Not found." })) { StatusCode = 404 };
            }

            return new FileContentResult(config, "application/json") { FileDownloadName = name };
        }
    }
}
