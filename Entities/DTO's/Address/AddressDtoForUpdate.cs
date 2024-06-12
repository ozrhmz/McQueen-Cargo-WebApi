using System.ComponentModel.DataAnnotations;

namespace Entities.DTO_s
{
    public record AddressDtoForUpdate : AddressDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
