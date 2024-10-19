using System.Globalization;
using Raffle.Domain.DTO_s.AssignedNumber;
using Raffle.Domain.Entities.AssignedNumber;
using Raffle.Domain.Exceptions;
using Raffle.Domain.Helpers;
using Raffle.Domain.IService;
using Raffle.Domain.Ports;
using Raffle.Raffle.Domain.Exceptions;

namespace Raffle.Domain.Service
{
    [DomainService]
    public class AssignedNumberService : IAssignedNumberService
    {
        private readonly IRepository<AssignedNumberEntity> _repository;

        private static readonly Random _random = new Random();

        private const string FIVE_DIGIT_FORMAT = "D5";
        private const int MINIMUM_NUMBER = 1;
        private const int MAXIMUM_NUMBER = 99999;

        public AssignedNumberService(
            IRepository<AssignedNumberEntity> repository
        )
        {
            _repository = repository;
        }

        public async Task<AssignedNumberEntity> CreateAssignedNumberAsync(
            AssignedNumberCreateRequestDto request
        )
        {
            request.ProductId.CheckValidGuid();
            request.UserId.CheckValidGuid();

            try
            {
                var assignedNumber = await GenerateUniqueNumberAsync(request.ProductId);
                var newAssignedNumber = new AssignedNumberEntity
                {
                    Number = assignedNumber,
                    UserId = request.UserId,
                    ProductId = request.ProductId
                };

                return await AddAssignedNumberAsync(newAssignedNumber);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException(MessagesExceptions.NoAvailableNumbers);
            }
            catch (Exception)
            {
                throw new RestClientException(MessagesExceptions.CreateAssignedNumberError);
            }
        }

        private async Task<IEnumerable<string>> GetAssignedNumbersAsync(Guid productId) =>
            (await _repository.GetAsync(assignedNumber => assignedNumber.ProductId == productId))
            .Select(assignedNumber => assignedNumber.Number) ?? [];

        private static bool HasEqualConsecutiveDigits(string numberString)
        {
            return Enumerable.Range(0, numberString.Length - 2).Any(
                i => numberString[i] == numberString[i + 1] && 
                    numberString[i + 1] == numberString[i + 2]
            );
        }


        private async Task<string> GenerateUniqueNumberAsync(Guid productId)
        {
            var assignedNumbers = await GetAssignedNumbersAsync(productId);
            var availableNumbers = Enumerable.Range(MINIMUM_NUMBER, MAXIMUM_NUMBER - MINIMUM_NUMBER + 1)
                .Select(numbers => numbers.ToString(FIVE_DIGIT_FORMAT))
                .Where(numbers => !assignedNumbers.Contains(numbers) && !HasEqualConsecutiveDigits(numbers))
                .ToList();

            if (availableNumbers.Count == 0)
                throw new InvalidOperationException(MessagesExceptions.NoAvailableNumbers);

            int randomIndex = _random.Next(availableNumbers.Count);
            return availableNumbers[randomIndex];
        }

        private async Task<AssignedNumberEntity> AddAssignedNumberAsync(AssignedNumberEntity assignedNumber)
        {
            assignedNumber.ValidateNullObject(string.Format(
                CultureInfo.InvariantCulture,
                MessagesExceptions.ArgumentNullOrEmpty,
                nameof(assignedNumber)
            ));

            return await _repository.AddAsync(assignedNumber);
        }
    }
}
