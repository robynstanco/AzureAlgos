using AzureAlgos.Models.Input;
using AzureAlgos.Models.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzureAlgos.Sorting
{
    /// <summary>
    /// The Quick Sort recursive function used to demonstrate a medium difficulty sorting technique with good time complexity.
    /// </summary>
    public static class QuickSort
    {
        [FunctionName("QuickSort")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("Quick sort is processing a request...");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var integerArrayRequest = JsonConvert.DeserializeObject<IntegerArrayRequest>(requestBody);

            var array = integerArrayRequest.Data;

            array = QuickSortHelper(array.ToArray(), 0, array.Count - 1).ToList();

            var result = new GenericResult
            {
                Data = array,
                SpaceComplexity = Constants.LogN,
                TimeComplexity = Constants.NLogN
            };

            log.LogInformation("Quick sort has completed a request...");

            return new OkObjectResult(result);
        }

        public static int[] QuickSortHelper(int[] array, int left, int right)
        {
            //Initialize pointers and pivot value.
            var i = left;
            var j = right;
            var pivot = array[left];

            //Base case, already sorted or length 1 array.
            if (i >= j)
            {
                return array;
            }

            //While left <= right
            while (i <= j)
            {
                //Move pointers accordingly
                while (array[i] < pivot)
                {
                    i++;
                }
                while (array[j] > pivot)
                {
                    j--;
                }

                //Must swap values and move pointers
                if (i <= j)
                {
                    (array[j], array[i]) = (array[i], array[j]);

                    i++;
                    j--;
                }
            }

            //Recursively sort sub arrays
            if (left < j)
            {
                QuickSortHelper(array, left, j);
            }

            if (i < right)
            {
                QuickSortHelper(array, i, right);
            }

            return array;
        }
    }
}
