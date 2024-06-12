using System.ComponentModel.DataAnnotations;

namespace Entities.DTO_s.Employee
{
    public record EmployeeDtoForUpdate : EmployeeDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
