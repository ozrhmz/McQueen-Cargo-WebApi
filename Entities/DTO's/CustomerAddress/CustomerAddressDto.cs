
namespace Entities.DTO_s.CustomerAddress
{
    public record CustomerAddressDto
    {
        public int Id { get; init; }
        public int AddressId { get; init; }
        public int? CustomerId { get; init; }
        public int? CustomerMobilId { get; init; }
        public int? BranchId { get; init; }
    }
}
