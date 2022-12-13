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

namespace AZFnctSAProxy
{
    public static class GetFile
    {
        [FunctionName("GetFile")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "{name}")] HttpRequest req,
           [Blob("samples/{name}", FileAccess.Read, Connection = "AzureWebJobsStorage")] byte[] myBlob, 
           string name,
            ILogger log)
        {
            log.LogInformation($"File name: {name}");

            return new FileContentResult(myBlob, "application/octet-stream") { FileDownloadName = name };
        }
    }
}
