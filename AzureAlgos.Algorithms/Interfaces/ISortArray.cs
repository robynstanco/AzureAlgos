using System.Collections.Generic;

namespace AzureAlgos.Algorithms.Interfaces
{
    public interface ISortArray
    {
        /// <summary>
        /// Sort an array of integers.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <returns>The sorted array.</returns>
        List<int> Sort(List<int> array);
    }
}
