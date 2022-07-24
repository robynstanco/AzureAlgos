using AzureAlgos.Algorithms.Interfaces;
using System.Collections.Generic;

namespace AzureAlgos.Algorithms.Sorting
{
    /// <summary>
    /// The Bubble Sort Algorithm used to demonstrate easy sorting technique with long time complexity.
    /// </summary>
    public class BubbleSort : IBubbleSort
    {
        /// <summary>
        /// Sort an array of integers.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <returns>The sorted array.</returns>
        public List<int> Sort(List<int> array)
        {
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

            return array;
        }
    }
}
