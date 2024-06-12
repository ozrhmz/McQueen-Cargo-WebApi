using System.ComponentModel.DataAnnotations;

namespace Entities.DTO_s.CallCourier
{
    public record CallCourierDtoForUpdate : CallCourierDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
