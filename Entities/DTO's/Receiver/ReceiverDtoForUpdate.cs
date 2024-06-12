using System.ComponentModel.DataAnnotations;

namespace Entities.DTO_s.Receiver
{
    public record ReceiverDtoForUpdate : ReceiverDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
