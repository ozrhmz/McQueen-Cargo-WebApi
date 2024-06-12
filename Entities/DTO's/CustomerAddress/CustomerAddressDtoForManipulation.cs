using System.ComponentModel.DataAnnotations;

namespace Entities.DTO_s.CustomerAddress
{
    public record CustomerAddressDtoForManipulation
    {
        public int? CustomerId { get; init; }
        public int? CustomerMobilId { get; init; }
        public int? BranchId { get; init; }

        [Required(ErrorMessage = "AddressId is a required field.")]
        public int AddressId { get; init; }

    }
}
