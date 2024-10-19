using NSubstitute;
using Xunit;

namespace Raffle.Infrastructure.Test
{
    /*public class MasterLocalizaOnPremiseServiceTests
    {
        private readonly IMicroClientService _mockMicroClientService;
        private readonly IConfigProvider _mockConfigProvider;
        private readonly MasterLocalizaOnPremiseService _service;

        public MasterLocalizaOnPremiseServiceTests()
        {
            _mockMicroClientService = Substitute.For<IMicroClientService>();
            _mockConfigProvider = Substitute.For<IConfigProvider>();
            _service = new MasterLocalizaOnPremiseService(_mockMicroClientService, _mockConfigProvider);
        }

        [Fact]
        public async Task GetPreBillingProcessIsExecutedAsync_ReturnsTrue_WhenProcessIsExecuted()
        {
            // Arrange
            var uri = "http://example.com/prebilling";
            _mockConfigProvider.GetPreBillingProcessPath.Returns(uri);
            _mockMicroClientService.GetTokenMicroServiceAsync().Returns("token");
            _mockMicroClientService.GetDataAsync<object>(uri, "token").Returns(true);

            // Act
            var result = await _service.GetPreBillingProcessIsExecutedAsync();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetPreBillingProcessIsExecutedAsync_ReturnsFalse_WhenProcessIsNotExecuted()
        {
            // Arrange
            var uri = "http://example.com/prebilling";
            _mockConfigProvider.GetPreBillingProcessPath.Returns(uri);
            _mockMicroClientService.GetTokenMicroServiceAsync().Returns("token");
            _mockMicroClientService.GetDataAsync<object>(uri, "token").Returns(false);

            // Act
            var result = await _service.GetPreBillingProcessIsExecutedAsync();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task GetActiveAgenciesAsync_ReturnsListOfAgencies()
        {
            // Arrange
            var uri = "http://example.com/activeagencies";
            _mockConfigProvider.GetActiveAgenciesPath.Returns(uri);
            _mockMicroClientService.GetTokenMicroServiceAsync().Returns("token");
            List<AgencyDto> expectedAgencies = [new AgencyDtoBuilder().Build()];
            _mockMicroClientService.GetDataAsync<List<AgencyDto>>(uri, "token").Returns(expectedAgencies);

            // Act
            var result = await _service.GetActiveAgenciesAsync();

            // Assert
            Assert.Equal(expectedAgencies, result);
        }

        [Fact]
        public async Task GetMinumBilliableValueAsync_ReturnsCorrectValue()
        {
            // Arrange
            var uri = "http://example.com/minumbilliablevalue";
            var expectedValue = 100.0m;
            _mockConfigProvider.GetMinimumBilliableValuePath.Returns(uri);
            _mockMicroClientService.GetTokenMicroServiceAsync().Returns("token");
            _mockMicroClientService.GetDataAsync<object>(uri, "token").Returns(expectedValue.ToString());

            // Act
            var result = await _service.GetMinimumBilliableValueAsync();

            // Assert
            Assert.Equal(expectedValue, result);
        }
    }*/
}
