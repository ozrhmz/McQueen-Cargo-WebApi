using System.ComponentModel.DataAnnotations;


namespace Entities.DTO_s.CustomerAddress
{
    public record CustomerAddressDtoForUpdate : CustomerDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
