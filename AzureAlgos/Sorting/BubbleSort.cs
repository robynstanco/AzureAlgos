using AzureAlgos.Models.Input;
using AzureAlgos.Models.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace AzureAlgos.Sorting
{
    /// <summary>
    /// The Bubble Sort function used to demonstrate easy sorting technique with long time complexity.
    /// </summary>
    public class BubbleSort
    {
        [FunctionName("BubbleSort")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "BubbleSort")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Bubble sort is processing a request...");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var integerArrayRequest = JsonConvert.DeserializeObject<IntegerArrayRequest>(requestBody);

            var array = integerArrayRequest.Data;

            for (int i = 0; i < array.Count; i++)
            {
                for (int j = i + 1; j < array.Count; j++)
                {
                    //Must swap
                    if (array[i] > array[j])
                    {
                        (array[j], array[i]) = (array[i], array[j]);
                    }
                }
            }

            var result = new GenericResult
            {
                Data = array,
                SpaceComplexity = Constants.Constant,
                TimeComplexity = Constants.NSquared
            };

            log.LogInformation("Bubble sort has completed a request...");

            return new OkObjectResult(result);
        }
    }
}
