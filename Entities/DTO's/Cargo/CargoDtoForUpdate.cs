using System.ComponentModel.DataAnnotations;

namespace Entities.DTO_s.Cargo
{
    public record CargoDtoForUpdate : CargoDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
