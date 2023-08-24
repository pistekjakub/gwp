using gwp.Controllers;
using gwp.Models;
using gwp.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace gwp.Tests.Controllers
{
    public class GwpControllerTests
    {
        private readonly GwpController _sut;
        private readonly Mock<IAvgService> _mockAwgService = new Mock<IAvgService>();

        public GwpControllerTests()
        {
            _sut = new GwpController(_mockAwgService.Object);
        }

        [Fact]
        public void Avg_ReturnsOkIfFound()
        {
            _mockAwgService.Setup(s => s.GetAvgItems(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(new Dictionary<string,double>());

            var result = _sut.Avg(It.IsAny<AvgRequest>());

            _mockAwgService.Verify(v => v.GetAvgItems(It.IsAny<string>(), It.IsAny<List<string>>()), Times.Once);
            Assert.IsType<OkObjectResult>(result);
        }

    }
}
