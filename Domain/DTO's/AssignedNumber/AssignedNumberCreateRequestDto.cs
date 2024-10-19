namespace Raffle.Domain.DTO_s.AssignedNumber
{
    public class AssignedNumberCreateRequestDto
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
