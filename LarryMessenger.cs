using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Larry.Messenger.Services;

namespace Larry.Messenger
{
    public static class LarryMessenger
    {
        [FunctionName("LarryMessenger")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var responseService = new ResponseService(log);
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            var message = data?.message.ToString() ?? "";

            //TODO: send the response as a separate async request to the frontend client with a slight delay
            log.LogInformation($"Message recieved: {message}");
            var responseMessage = responseService.GetResponse(message);

            return new OkObjectResult(responseMessage);
        }
    }

}
