using AzureAlgos.Algorithms.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace AzureAlgos.Algorithms.Sorting
{
    /// <summary>
    /// The Quick Sort recursive Algorithm used to demonstrate a medium difficulty sorting technique with good time complexity.
    /// </summary>
    public class QuickSort : IQuickSort
    {
        /// <summary>
        /// Sort an array of integers.
        /// </summary>
        /// <param name="array">The array to sort.</param>
        /// <returns>The sorted array.</returns>
        public List<int> Sort(List<int> array)
        {
            return QuickSortHelper(array.ToArray(), 0, array.Count - 1).ToList();
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
