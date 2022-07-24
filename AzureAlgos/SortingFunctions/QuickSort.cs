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
    /// The Quick Sort recursive function used to demonstrate a medium difficulty sorting technique with good time complexity.
    /// </summary>
    public class QuickSort
    {
        private readonly IQuickSort _quickSort;
        public QuickSort(IQuickSort quickSort)
        {
            _quickSort = quickSort ?? throw new ArgumentNullException(nameof(quickSort));
        }

        [FunctionName("QuickSort")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("Quick sort is processing a request...");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var integerArrayRequest = JsonConvert.DeserializeObject<IntegerArrayRequest>(requestBody);

            var array = integerArrayRequest.Data;

            array = _quickSort.Sort(array);

            var result = new GenericResult
            {
                Data = array,
                SpaceComplexity = Constants.LogN,
                TimeComplexity = Constants.NLogN
            };

            log.LogInformation("Quick sort has completed a request...");

            return new OkObjectResult(result);
        }
    }
}
