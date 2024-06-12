using System.ComponentModel.DataAnnotations;

namespace Entities.DTO_s.Employee
{
    public record EmployeeDtoForManipulation
    {
        public int Id { get; init; }
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; init; }
        [Required(ErrorMessage = "Surname is a required field.")]
        public string Surname { get; init; }
        [Required(ErrorMessage = "TcNo is a required field.")]
        public string TcNo { get; init; }
        [Required(ErrorMessage = "NumberPhone is a required field.")]
        public string NumberPhone { get; init; }

        public string Password { get; init; }
        [Required(ErrorMessage = "EmployeesType is a required field.")]
        public int EmployeesTypeId { get; init; }
        public int BranchId { get; init; }
    }
}
