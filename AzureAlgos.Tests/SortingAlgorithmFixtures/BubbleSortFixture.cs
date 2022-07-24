using AzureAlgos.Algorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AzureAlgos.Tests.SortingAlgorithmFixtures
{
    [TestClass]
    public class BubbleSortFixture
    {
        private BubbleSort _bubbleSort;

        [TestInitialize]
        public void Initialize()
        {
            _bubbleSort = new BubbleSort();
        }

        [TestMethod]
        public void BubbleSort_SortsCorrectly()
        {
            //Arrange
            var array = new List<int> { 3, 1, 7, 4, 5, 2, 8 };

            //Act
            List<int> sortedArray = _bubbleSort.Sort(array);

            //Assert
            Assert.IsNotNull(sortedArray);
            Assert.AreEqual(1, sortedArray[0]);
            Assert.AreEqual(2, sortedArray[1]);
            Assert.AreEqual(3, sortedArray[2]);
            Assert.AreEqual(4, sortedArray[3]);
            Assert.AreEqual(5, sortedArray[4]);
            Assert.AreEqual(7, sortedArray[5]);
            Assert.AreEqual(8, sortedArray[6]);
        }
    }
}
