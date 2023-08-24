using gwp.Models.Database;
using gwp.Repositories;

namespace gwp.Tests.Repositories
{
    public class LobRepositoryTests
    {
        [Fact]
        public void GetAvgItems_Returns_Correct_Result() 
        {
            // 1. Arrange
            var database = new MockDatabase();
            database.Records = new List<Models.Database.Record> { new Models.Database.Record { Country = "us", Lob = "test_lob", Y2000 = 666 } };
            var sut = new LobRepository(database);

            // 2. Act
            var result = sut.GetLobItems("us", "test_lob");

            // 3. Assert
            Assert.NotNull(result);
            Assert.Equal(16, result?.Count);
            Assert.Equal(666, result?[0]);
            Assert.Equal(0, result?[1]);
        }

        [Fact]
        public void GetLobItems_NotFound_ShouldThrowKeyNotFoundException()
        {
            // 1. Arrange
            var database = new MockDatabase();
            database.Records = new List<Models.Database.Record> { new Models.Database.Record { Country = "cz", Lob = "test_lob", Y2000 = 666 } };
            var sut = new LobRepository(database);

            // 2. 3. Act & Assert
            Assert.Throws<KeyNotFoundException>(() => sut.GetLobItems("us", "test_lob"));
        }



    }
}
