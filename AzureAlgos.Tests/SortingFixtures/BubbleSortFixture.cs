using AzureAlgos.Sorting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Text;
using System.Threading.Tasks;

namespace AzureAlgos.Tests.SortingFixtures
{
    [TestClass]
    public class BubbleSortFixture
    {
        private BubbleSort _bubbleSort;

        private Mock<HttpRequest> _httpRequestMock;
        private Mock<ILogger> _loggerMock;

        [TestInitialize]
        public void Initialize()
        {
            //Arrange
            _httpRequestMock = new Mock<HttpRequest>();
           
            _loggerMock = new Mock<ILogger>();

            _bubbleSort = new BubbleSort();
        }

        [TestMethod]
        public async Task BubbleSort_SortsArrayCorrectly()
        {
            //Arrange
            var bytes = Encoding.ASCII.GetBytes("{\"Data\": [3,1,2]}");

            var stream = new System.IO.MemoryStream(bytes);

            _httpRequestMock.Setup(http => http.Body).Returns(stream);

            //Act
            var result = await _bubbleSort.Run(_httpRequestMock.Object, _loggerMock.Object);

            dynamic resultData = (result as OkObjectResult).Value;

            //Assert
            Assert.IsNotNull(resultData);
            Assert.AreEqual(1, resultData.Data[0]);
            Assert.AreEqual(2, resultData.Data[1]);
            Assert.AreEqual(3, resultData.Data[2]);
            Assert.AreEqual(Constants.Constant, resultData.SpaceComplexity);
            Assert.AreEqual(Constants.NSquared, resultData.TimeComplexity);
        }
    }
}
