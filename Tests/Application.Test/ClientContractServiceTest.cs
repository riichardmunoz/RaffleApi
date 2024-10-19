using System.Linq.Expressions;
using NSubstitute;

namespace Application.Test
{
    public class ClientContractServiceTest
    {
        /*private readonly IClientContractRepository _mockRepository;
        private readonly IContractService _mockContractService;
        private readonly IRcClientService _mockRcClientService;
        private readonly IClientTypeService _mockClientTypeService;
        private readonly IConfigProvider _mockConfigProvider;
        private readonly IMapper _mockMapper;
        private readonly ClientContractService _service;

        public ClientContractServiceTest()
        {
            _mockRepository = Substitute.For<IClientContractRepository>();
            _mockContractService = Substitute.For<IContractService>();
            _mockRcClientService = Substitute.For<IRcClientService>();
            _mockClientTypeService = Substitute.For<IClientTypeService>();
            _mockConfigProvider = Substitute.For<IConfigProvider>();
            _mockMapper = new MapperConfiguration(cfg => cfg.AddProfile<InsertClientContractProfile>()).CreateMapper();

            _service = new ClientContractService(
                _mockRepository,
                _mockContractService,
                _mockRcClientService,
                _mockClientTypeService,
                _mockConfigProvider,
                _mockMapper
            );
        }

        [Fact]
        public async Task InsertClientContractAsync_ThrowsArgumentNullException_Error()
        {
            // Arrange
            var insertList = new List<InsertClientContractDto>
            {
                new InsertClientContractDtoBuilder().Build()
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _service.InsertClientContractAsync(insertList, null!));
        }

        [Fact]
        public async Task InsertClientContractAsync_DoesNotAdd_WhenListIsEmpty()
        {
            // Arrange
            var contractNumber = "123456";
            var insertList = new List<InsertClientContractDto>();

            // Act
            await _service.InsertClientContractAsync(insertList, contractNumber);

            // Assert
            await _mockRepository.DidNotReceive()
                .AddAsync(Arg.Any<ClientContractEntity>());
        }

        [Fact]
        public async Task InsertClientContractAsync_AddsClientContract_Ok()
        {
            // Arrange
            var contractNumber = "123456";
            var contract = new ContractEntityBuilder()
                .WithSectorCode(SectorCode.RE.ToString())
                .Build();
            var rcClientEntity = new RcClientEntityBuilder().Build();
            var clientTypeEntity = new ClientTypeEntityBuilder().Build();
            var insertList = new List<InsertClientContractDto>
            {
                new InsertClientContractDtoBuilder()
                    .WithLocalizaClientId("112233")
                    .WithClientType(ClientType.ClientContract)
                    .Build(),
                new InsertClientContractDtoBuilder()
                    .WithLocalizaClientId("445566")
                    .WithClientType(ClientType.UserContract)
                    .Build(),
                new InsertClientContractDtoBuilder()
                    .WithLocalizaClientId("778899")
                    .WithClientType(ClientType.ClientVoucher)
                    .Build(),
            };

            _mockContractService
                .FindContractByContractNumberAsync(contractNumber)
                .Returns(contract);
            _mockRcClientService
                .GetRcClientByLocalizaClientIdAsync(Arg.Any<string>())
                .Returns(rcClientEntity);
            _mockClientTypeService
                .GetClientTypeByClientTypeDescriptionAsync(Arg.Any<string>())
                .Returns(clientTypeEntity);

            // Act
            await _service.InsertClientContractAsync(insertList, contractNumber);

            // Assert
            await _mockRepository.Received(3)
                .AddAsync(Arg.Any<ClientContractEntity>());
        }

        [Fact]
        public async Task InsertClientContractAsync_AddClientContract_WithClientContractLogInvoiceTrue_Ok()
        {
            // Arrange
            var contractNumber = "123456";
            var contract = new ContractEntityBuilder()
                .WithSectorCode(SectorCode.RE.ToString())
                .Build();
            var rcClientEntity = new RcClientEntityBuilder().Build();
            var clientTypeEntity = new ClientTypeEntityBuilder().Build();
            var insertList = new List<InsertClientContractDto>
            {
                new InsertClientContractDtoBuilder()
                    .WithLocalizaClientId("112233")
                    .WithClientType(ClientType.ClientContract)
                    .Build(),
                new InsertClientContractDtoBuilder()
                    .WithLocalizaClientId("445566")
                    .WithClientType(ClientType.UserContract)
                    .Build()
            };

            _mockContractService
                .FindContractByContractNumberAsync(contractNumber)
                .Returns(contract);
            _mockRcClientService
                .GetRcClientByLocalizaClientIdAsync(Arg.Any<string>())
                .Returns(rcClientEntity);
            _mockClientTypeService
                .GetClientTypeByClientTypeDescriptionAsync(Arg.Any<string>())
                .Returns(clientTypeEntity);

            // Act
            await _service.InsertClientContractAsync(insertList, contractNumber);

            // Assert
            await _mockRepository.Received(2)
                .AddAsync(Arg.Any<ClientContractEntity>());
        }

        [Fact]
        public async Task InsertClientContractAsync_UpdateClientContract_Ok()
        {
            // Arrange
            var contractNumber = "123456";
            var contract = new ContractEntityBuilder()
                .WithSectorCode(SectorCode.RE.ToString())
                .Build();
            var rcClientEntity = new RcClientEntityBuilder()
                .Build();
            var clientTypeEntity = new ClientTypeEntityBuilder()
                .Build();
            var clientContractEntity = new ClientContractEntityBuilder()
                .WithLocalizaClientId("112233")
                .Build();
            var insertList = new List<InsertClientContractDto>
            {
                new InsertClientContractDtoBuilder()
                    .WithLocalizaClientId("112233")
                    .WithClientType(ClientType.ClientContract)
                    .Build()
            };

            _mockContractService
                .FindContractByContractNumberAsync(contractNumber)
                .Returns(contract);
            _mockRcClientService
                .GetRcClientByLocalizaClientIdAsync(Arg.Any<string>())
                .Returns(rcClientEntity);
            _mockClientTypeService
                .GetClientTypeByClientTypeDescriptionAsync(Arg.Any<string>())
                .Returns(clientTypeEntity);
            _mockRepository.FindByAlternateKeyAsync(
                Arg.Any<Expression<Func<ClientContractEntity, bool>>>(),
                includeProperties: Arg.Any<string>()
            ).Returns(clientContractEntity);

            // Act
            await _service.InsertClientContractAsync(insertList, contractNumber);

            // Assert
            await _mockRepository.Received(1)
                .UpdateAsync(Arg.Any<ClientContractEntity>());
        }*/
    }
}
