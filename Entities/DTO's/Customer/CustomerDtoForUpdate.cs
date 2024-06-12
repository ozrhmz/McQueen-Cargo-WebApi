using System.ComponentModel.DataAnnotations;


namespace Entities.DTO_s
{
    public record CustomerDtoForUpdate : CustomerDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
