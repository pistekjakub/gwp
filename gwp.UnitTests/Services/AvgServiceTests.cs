using gwp.Repositories;
using gwp.Services;

namespace gwp.Tests.Services
{
    public class AvgServiceTests
    {
        private IAvgService _sut;

        private readonly Mock<ILobRepository> _lobRepositoryMock = new Mock<ILobRepository>();
        private readonly Mock<ICacheService> _cacheServiceMock = new Mock<ICacheService>();

        public AvgServiceTests()
        {
            _sut = new AvgService(_lobRepositoryMock.Object, _cacheServiceMock.Object);
        }

        [Fact]
        public void GetAvgItems_Returns_Correct_Result()
        {
            // 1. Arrange
            _lobRepositoryMock.Setup(s => s.GetLobItems(It.IsAny<string>(), It.IsAny<string>())).Returns(new List<double> { 200, 1000, 400 });
            _cacheServiceMock.Setup(m => m.SetValue(It.IsAny<string>(), It.IsAny<object>()));

            // 2. Act
            var result = _sut.GetAvgItems(It.IsAny<string>(), new List<string> { "test_lob", "test_lob2" });

            // 3. Assert
            _lobRepositoryMock.Verify(v => v.GetLobItems(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            _cacheServiceMock.Verify(v => v.GetValue<double?>(It.IsAny<string>()), Times.Exactly(2));
            Assert.NotNull(result);
            Assert.Equal(2,result.Count);
            Assert.Equal(100, result["test_lob"]);
            Assert.Equal(100, result["test_lob2"]);
        }
    }
}
