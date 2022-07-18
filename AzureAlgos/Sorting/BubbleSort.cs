using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureAlgos.Models.Input;
using AzureAlgos.Models.Output;

namespace AzureAlgos.Sorting
{
    public static class BubbleSort
    {
        [FunctionName("BubbleSort")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "BubbleSort")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Bubble sort is processing a request...");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var integerArrayRequest = JsonConvert.DeserializeObject<IntegerArrayRequest>(requestBody);
            var array = integerArrayRequest.Data;

            for (int i = 0; i < array.Count; i++)
            {
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (array[i] > array[j])
                    {
                        int swapMe = array[i];

                        array[i] = array[j];
                        array[j] = swapMe;
                    }
                }
            }

            var result = new GenericResult
            {
                Data = array,
                SpaceComplexity = "O(1)",
                TimeComplexity = "O(n^2)"
            };

            return new OkObjectResult(result);
        }
    }
}
