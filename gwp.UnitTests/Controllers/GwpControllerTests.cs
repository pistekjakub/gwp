using gwp.Controllers;
using gwp.Models;
using gwp.Services;
using Microsoft.AspNetCore.Mvc;

namespace gwp.Tests.Controllers
{
    public class GwpControllerTests
    {
        private readonly GwpController _sut;
        private readonly Mock<IAvgService> _avgServiceMock = new Mock<IAvgService>();

        public GwpControllerTests()
        {
            _sut = new GwpController(_avgServiceMock.Object);
        }

        [Fact]
        public void Avg_ReturnsOkIfFound()
        {
            // 1. Arrange
            _avgServiceMock.Setup(s => s.GetAvgItems(It.IsAny<string>(), It.IsAny<List<string>>())).Returns(new Dictionary<string, double>());

            // 2. Act
            var result = _sut.Avg(new AvgRequest { Country = "", Lob = new List<string>() });

            // 3. Assert
            _avgServiceMock.Verify(v => v.GetAvgItems(It.IsAny<string>(), It.IsAny<List<string>>()), Times.Once);
            Assert.IsType<OkObjectResult>(result.Result);
        }

    }
}
