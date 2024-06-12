using System.ComponentModel.DataAnnotations;

namespace Entities.DTO_s.CustomerMobil
{
    public record CustomerMobilDtoForUpdate : CustomerMobilDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
