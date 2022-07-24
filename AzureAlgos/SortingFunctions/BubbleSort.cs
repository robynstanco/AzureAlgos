using AzureAlgos.Algorithms.Interfaces;
using AzureAlgos.Models.Input;
using AzureAlgos.Models.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AzureAlgos.SortingFunctions
{
    /// <summary>
    /// The Bubble Sort function used to demonstrate easy sorting technique with long time complexity.
    /// </summary>
    public class BubbleSort
    {
        private readonly IBubbleSort _bubbleSort;
        public BubbleSort(IBubbleSort bubbleSort)
        {
            _bubbleSort = bubbleSort ?? throw new ArgumentNullException(nameof(bubbleSort));
        }

        [FunctionName("BubbleSort")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "BubbleSort")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Bubble sort is processing a request...");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var integerArrayRequest = JsonConvert.DeserializeObject<IntegerArrayRequest>(requestBody);

            var array = integerArrayRequest.Data;

            array = _bubbleSort.Sort(array);

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
